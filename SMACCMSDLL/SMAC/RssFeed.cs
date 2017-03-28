using System;
using System.Xml;

namespace SMAC
{
	public class RssFeed
	{
		public string en = Environment.NewLine;

		public XmlTextWriter WriteRSSPrologue(XmlTextWriter writer, string page)
		{
			writer.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + this.en);
			writer.WriteRaw("<?xml-stylesheet type=\"text/xsl\" href=\"rss.xsl\" media=\"screen\"?>");
			writer.WriteRaw("<rss version=\"2.0\">" + this.en);
			writer.WriteRaw("\t<channel>" + this.en);
			writer.WriteRaw("\t\t<title>RSS Feed for Dieutri</title>" + this.en);
			writer.WriteRaw("\t\t<link>http://www.dieutri.vn</link>" + this.en);
			writer.WriteRaw("\t\t<description>Dieutri RSS Feed</description>" + this.en);
			writer.WriteRaw("\t\t<copyright>Copyright 2009 - 2011 Dieutri</copyright>" + this.en);
			return writer;
		}

		public XmlTextWriter AddRSSItem(XmlTextWriter writer, string sItemTitle, string sItemLink, string sItemDescription)
		{
			return this.AddRSSItem(writer, sItemTitle, sItemLink, sItemDescription, DateTime.Now.ToString("r"));
		}

		public XmlTextWriter AddRSSItem(XmlTextWriter writer, string sItemTitle, string sItemLink, string sItemDescription, string sPubDate)
		{
			writer.WriteRaw("\t\t<item>" + this.en);
			writer.WriteRaw("\t\t\t<title>" + this.Encode(sItemTitle) + "</title>" + this.en);
			writer.WriteRaw("\t\t\t<link>" + this.Encode(sItemLink) + "</link>" + this.en);
			writer.WriteRaw("\t\t\t<description><![CDATA[" + sItemDescription + "]]></description>" + this.en);
			writer.WriteRaw("\t\t\t<pubDate>" + sPubDate + "</pubDate>" + this.en);
			writer.WriteRaw("\t\t</item>" + this.en);
			return writer;
		}

		public XmlTextWriter WriteRSSClosing(XmlTextWriter writer)
		{
			writer.WriteRaw("\t</channel>" + this.en);
			writer.WriteRaw("</rss>");
			return writer;
		}

		private string Encode(string input)
		{
			return input.Replace("&", "&amp;");
		}
	}
}
