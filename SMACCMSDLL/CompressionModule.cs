using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web;
using System.Web.UI;

public sealed class CompressionModule : IHttpModule
{
	private const string GZIP = "gzip";

	private const string DEFLATE = "deflate";

	void IHttpModule.Dispose()
	{
	}

	void IHttpModule.Init(HttpApplication context)
	{
		context.PreRequestHandlerExecute += new EventHandler(this.context_PostReleaseRequestState);
		context.BeginRequest += new EventHandler(this.context_BeginRequest);
		context.EndRequest += new EventHandler(this.context_EndRequest);
	}

	private void context_PostReleaseRequestState(object sender, EventArgs e)
	{
		HttpApplication httpApplication = (HttpApplication)sender;
		if (httpApplication.Context is Page && httpApplication.Request["HTTP_X_MICROSOFTAJAX"] == null)
		{
			if (CompressionModule.IsEncodingAccepted("deflate"))
			{
				httpApplication.Response.Filter = new DeflateStream(httpApplication.Response.Filter, CompressionMode.Compress);
				CompressionModule.SetEncoding("deflate");
			}
			else if (CompressionModule.IsEncodingAccepted("gzip"))
			{
				httpApplication.Response.Filter = new GZipStream(httpApplication.Response.Filter, CompressionMode.Compress);
				CompressionModule.SetEncoding("gzip");
			}
		}
	}

	private static bool IsEncodingAccepted(string encoding)
	{
		HttpContext current = HttpContext.Current;
		return current.Request.Headers["Accept-encoding"] != null && current.Request.Headers["Accept-encoding"].Contains(encoding);
	}

	private static void SetEncoding(string encoding)
	{
		HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);
	}

	private void context_BeginRequest(object sender, EventArgs e)
	{
		HttpApplication httpApplication = (HttpApplication)sender;
		if (httpApplication.Request.Path.Contains("WebResource.axd"))
		{
			CompressionModule.SetCachingHeaders(httpApplication);
			if (CompressionModule.IsBrowserSupported() && httpApplication.Context.Request.QueryString["c"] == null && (CompressionModule.IsEncodingAccepted("deflate") || CompressionModule.IsEncodingAccepted("gzip")))
			{
				httpApplication.CompleteRequest();
			}
		}
	}

	private void context_EndRequest(object sender, EventArgs e)
	{
		if (CompressionModule.IsBrowserSupported() && (CompressionModule.IsEncodingAccepted("deflate") || CompressionModule.IsEncodingAccepted("gzip")))
		{
			HttpApplication httpApplication = (HttpApplication)sender;
			string text = httpApplication.Request.QueryString.ToString();
			if (httpApplication.Request.Path.Contains("WebResource.axd") && httpApplication.Context.Request.QueryString["c"] == null)
			{
				if (httpApplication.Application[text] == null)
				{
					CompressionModule.AddCompressedBytesToCache(httpApplication, text);
				}
				CompressionModule.SetEncoding((string)httpApplication.Application[text + "enc"]);
				httpApplication.Context.Response.ContentType = "text/javascript";
				httpApplication.Context.Response.BinaryWrite((byte[])httpApplication.Application[text]);
			}
		}
	}

	private static void SetCachingHeaders(HttpApplication app)
	{
		string text = "\"" + app.Context.Request.QueryString.ToString().GetHashCode().ToString() + "\"";
		string strA = app.Request.Headers["If-None-Match"];
		app.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
		app.Response.Cache.SetExpires(DateTime.Now.AddDays(30.0));
		app.Response.Cache.SetCacheability(HttpCacheability.Public);
		app.Response.Cache.SetLastModified(DateTime.Now.AddDays(-30.0));
		app.Response.Cache.SetETag(text);
		if (string.Compare(strA, text) == 0)
		{
			app.Response.StatusCode = 304;
			app.Response.End();
		}
	}

	private static bool IsBrowserSupported()
	{
		HttpContext current = HttpContext.Current;
		return current.Request.UserAgent == null || !current.Request.UserAgent.Contains("MSIE 6");
	}

	private static void AddCompressedBytesToCache(HttpApplication app, string key)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(app.Context.Request.Url.OriginalString + "&c=1");
		using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
		{
			Stream responseStream = httpWebResponse.GetResponseStream();
			using (MemoryStream memoryStream = CompressionModule.CompressResponse(responseStream, app, key))
			{
				app.Application.Add(key, memoryStream.ToArray());
			}
		}
	}

	private static MemoryStream CompressResponse(Stream responseStream, HttpApplication app, string key)
	{
		MemoryStream memoryStream = new MemoryStream();
		CompressionModule.StreamCopy(responseStream, memoryStream);
		responseStream.Dispose();
		byte[] array = memoryStream.ToArray();
		memoryStream.Dispose();
		MemoryStream memoryStream2 = new MemoryStream();
		Stream stream = null;
		if (CompressionModule.IsEncodingAccepted("deflate"))
		{
			stream = new DeflateStream(memoryStream2, CompressionMode.Compress);
			app.Application.Add(key + "enc", "deflate");
		}
		else if (CompressionModule.IsEncodingAccepted("gzip"))
		{
			stream = new GZipStream(memoryStream2, CompressionMode.Compress);
			app.Application.Add(key + "enc", "deflate");
		}
		stream.Write(array, 0, array.Length);
		stream.Dispose();
		return memoryStream2;
	}

	private static void StreamCopy(Stream input, Stream output)
	{
		byte[] array = new byte[2048];
		int num;
		do
		{
			num = input.Read(array, 0, array.Length);
			output.Write(array, 0, num);
		}
		while (num > 0);
	}
}
