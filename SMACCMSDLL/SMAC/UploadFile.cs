using System;
using System.IO;
using System.Web.UI.HtmlControls;

namespace SMAC
{
	public class UploadFile
	{
		private string strFileContent;

		private string strFileSize;

		private string strFileName;

		protected void checkPath(string path)
		{
			if (!Directory.Exists(path))
			{
				try
				{
					Directory.CreateDirectory(path);
				}
				finally
				{
				}
			}
		}

		public static bool CheckFile(string path)
		{
			bool result = true;
			if (path.IndexOf(".exe") != -1 || path.IndexOf(".asp") != -1 || path.IndexOf(".php") != -1 || path.IndexOf(".aspx") != -1 || path.IndexOf(".js") != -1 || path.IndexOf(".htm") != -1 || path.IndexOf(".cgi") != -1)
			{
				result = false;
			}
			return result;
		}

		public UploadFile(HtmlInputFile fileInput, string MyPath)
		{
			this.checkPath(MyPath);
			string fileName = fileInput.PostedFile.FileName;
			this.strFileName = Path.GetFileName(fileName);
			fileInput.PostedFile.SaveAs(MyPath + this.strFileName);
			this.strFileContent = fileInput.PostedFile.ContentType.ToString();
			this.strFileSize = fileInput.PostedFile.ContentLength.ToString();
		}

		public string getContentType()
		{
			return this.strFileContent;
		}

		public string getFileName()
		{
			return this.strFileName;
		}

		public string getFileSize()
		{
			return this.strFileSize + " bytes";
		}
	}
}
