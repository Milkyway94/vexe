using System;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace SMAC
{
	public class ImageUtility
	{
		private static bool ThumbnailCallback()
		{
			return false;
		}

		public static void ScaleImage(System.Web.UI.WebControls.Image src, string strURLImage, int nThumbWidth, int nThumbHeight)
		{
			string text = HttpContext.Current.Server.MapPath(strURLImage);
			if (File.Exists(text))
			{
				string fileName = Path.GetFileName(text);
				try
				{
					Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(text);
					int arg_56_0 = (bitmap.Width > bitmap.Height) ? bitmap.Width : bitmap.Height;
					int n = bitmap.Width;
					int n2 = bitmap.Height;
					if (bitmap.Width > bitmap.Height)
					{
						if (bitmap.Width > nThumbWidth)
						{
							float num = (float)bitmap.Width / (float)bitmap.Height;
							n = nThumbWidth;
							n2 = (int)((float)nThumbWidth / num);
						}
					}
					else if (bitmap.Height > nThumbHeight)
					{
						float num = (float)bitmap.Height / (float)bitmap.Width;
						n2 = nThumbHeight;
						n = (int)((float)nThumbHeight / num);
					}
					src.ImageUrl = strURLImage;
					src.Width = n;
					src.Height = n2;
				}
				catch
				{
				}
			}
		}

		public static string GenerateThumbnail(string strAbsDestDir, string strAbsImagePath, int nThumbWidth, int nThumbHeight)
		{
			string result = string.Empty;
			if (File.Exists(strAbsImagePath))
			{
				string fileName = Path.GetFileName(strAbsImagePath);
				try
				{
					Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(strAbsImagePath);
					int arg_4B_0 = (bitmap.Width > bitmap.Height) ? bitmap.Width : bitmap.Height;
					int thumbWidth = bitmap.Width;
					int thumbHeight = bitmap.Height;
					if (bitmap.Width > bitmap.Height)
					{
						if (bitmap.Width > nThumbWidth)
						{
							float num = (float)bitmap.Width / (float)bitmap.Height;
							thumbWidth = nThumbWidth;
							thumbHeight = (int)((float)nThumbWidth / num);
						}
					}
					else if (bitmap.Height > nThumbHeight)
					{
						float num = (float)bitmap.Height / (float)bitmap.Width;
						thumbHeight = nThumbHeight;
						thumbWidth = (int)((float)nThumbHeight / num);
					}
					System.Drawing.Image thumbnailImage = bitmap.GetThumbnailImage(thumbWidth, thumbHeight, new System.Drawing.Image.GetThumbnailImageAbort(ImageUtility.ThumbnailCallback), IntPtr.Zero);
					string arg_112_0 = strAbsDestDir.EndsWith("\\") ? strAbsDestDir : (strAbsDestDir + "\\");
					thumbnailImage.Save(strAbsDestDir + fileName);
					result = strAbsDestDir + fileName;
				}
				catch
				{
				}
			}
			return result;
		}
	}
}
