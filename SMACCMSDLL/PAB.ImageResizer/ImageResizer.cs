using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace PAB.ImageResizer
{
	public class ImageResizer
	{
		private int _imgQuality;

		private int _maxHeight;

		private int _maxWidth;

		private ImageFormat _outputFormat;

		public int ImgQuality
		{
			get
			{
				return this._imgQuality;
			}
			set
			{
				if (value < 2 || value > 100)
				{
					this._imgQuality = 80;
				}
				else
				{
					this._imgQuality = value;
				}
			}
		}

		public int MaxHeight
		{
			get
			{
				return this._maxHeight;
			}
			set
			{
				this._maxHeight = value;
			}
		}

		public int MaxWidth
		{
			get
			{
				return this._maxWidth;
			}
			set
			{
				this._maxWidth = value;
			}
		}

		public ImageFormat OutputFormat
		{
			get
			{
				return this._outputFormat;
			}
			set
			{
				this._outputFormat = value;
			}
		}

		public ImageResizer()
		{
			this._maxWidth = 800;
			this._maxHeight = 800;
			this._imgQuality = 80;
			this._outputFormat = ImageFormat.Jpeg;
		}

		public ImageResizer(int maxWidth, int maxHeight, int imgQuality)
		{
			this._maxWidth = 800;
			this._maxHeight = 800;
			this._imgQuality = 80;
			this._outputFormat = ImageFormat.Jpeg;
			this._maxHeight = maxHeight;
			this._maxWidth = maxWidth;
			this._imgQuality = imgQuality;
		}

		internal System.Drawing.Image Resize(System.Drawing.Image sourceImage)
		{
			System.Drawing.Image image = new Bitmap(sourceImage);
			int num = sourceImage.Width;
			int num2 = sourceImage.Height;
			if (num > this.MaxWidth)
			{
				num2 = num2 * this.MaxWidth / num;
				num = this.MaxWidth;
			}
			if (num2 > this.MaxHeight)
			{
				num = num * this.MaxHeight / num2;
				num2 = this.MaxHeight;
			}
			if (num != sourceImage.Width || num2 != sourceImage.Height)
			{
				image = new Bitmap(image, num, num2);
			}
			return image;
		}

		public void Resize(string imagePath)
		{
			this.Resize(imagePath, imagePath);
		}

		public byte[] Resize(HttpPostedFile postedFile)
		{
			byte[] result;
			if (postedFile.ContentLength == 0)
			{
				result = new byte[0];
			}
			else
			{
				System.Drawing.Image image = System.Drawing.Image.FromStream(postedFile.InputStream);
				System.Drawing.Image image2 = this.Resize(image);
				image.Dispose();
				EncoderParameters encoderParameters = new EncoderParameters(1);
				encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)this.ImgQuality);
				ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders()[(int)this.OutputFormat];
				MemoryStream memoryStream = new MemoryStream();
				image2.Save(memoryStream, encoder, encoderParameters);
				byte[] buffer = memoryStream.GetBuffer();
				image2.Dispose();
				memoryStream.Close();
				result = buffer;
			}
			return result;
		}

		public void Resize(string originalImagePath, string resizedImagePath)
		{
			System.Drawing.Image image;
			try
			{
				image = System.Drawing.Image.FromFile(originalImagePath);
			}
			catch
			{
				if (!File.Exists(originalImagePath))
				{
					throw new Exception("File " + originalImagePath + " doesn't exist; resize failed.");
				}
				throw new Exception("File " + originalImagePath + " is not a valid image file or No read permission on the file; resize failed.");
			}
			System.Drawing.Image image2 = this.Resize(image);
			image.Dispose();
			EncoderParameters encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)this.ImgQuality);
			ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders()[(int)this.OutputFormat];
			try
			{
				image2.Save(resizedImagePath, encoder, encoderParameters);
			}
			catch (Exception ex)
			{
				string text;
				try
				{
					text = Environment.UserName;
				}
				catch
				{
					text = null;
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "'ASPNET' or 'Network Service'";
				}
				text += " windows account";
				throw new Exception(string.Concat(new string[]
				{
					"Could not save resized image to ",
					resizedImagePath,
					"; resize failed.\r\n",
					ex.Message,
					"\nTry the following:\r\n1. Ensure that ",
					resizedImagePath,
					" is a valid file path.\r\n2. Ensure that the file ",
					resizedImagePath,
					" is not already being used by another process.\r\n3. Ensure that ",
					text,
					" has write/modify permission on ",
					resizedImagePath,
					" file.\r"
				}));
			}
			finally
			{
				image2.Dispose();
			}
		}

		public void Resize(HttpPostedFile postedFile, string resizedImagePath)
		{
			postedFile.SaveAs(resizedImagePath);
			this.Resize(resizedImagePath);
		}

		public string UploadMutilImageResize(HttpPostedFile fileupload, int MaxWidth, int MaxHeight, int ImgQuality, string path)
		{
			HttpContext current = HttpContext.Current;
			if (!Directory.Exists(current.Server.MapPath("~/" + path)))
			{
				Directory.CreateDirectory(current.Server.MapPath("~/" + path));
			}
			string str = current.Server.MapPath("~/" + path + "/");
			string text = DateTime.Now.Ticks.ToString();
			byte[] bytes = new ImageResizer
			{
				MaxWidth = MaxWidth,
				MaxHeight = MaxHeight,
				ImgQuality = ImgQuality,
				OutputFormat = ImageFormat.Jpeg
			}.Resize(fileupload);
			File.WriteAllBytes(str + text + ".jpg", bytes);
			return path + "/" + text + ".jpg";
		}

		public string UploadMutilImageResize(HttpPostedFile fileupload, int MaxWidth, int MaxHeight, int ImgQuality, string filename, string path)
		{
			HttpContext current = HttpContext.Current;
			if (!Directory.Exists(current.Server.MapPath("~/" + path)))
			{
				Directory.CreateDirectory(current.Server.MapPath("~/" + path));
			}
			string str = current.Server.MapPath("~/" + path + "/");
			byte[] bytes = new ImageResizer
			{
				MaxWidth = MaxWidth,
				MaxHeight = MaxHeight,
				ImgQuality = ImgQuality,
				OutputFormat = ImageFormat.Jpeg
			}.Resize(fileupload);
			File.WriteAllBytes(str + filename + ".jpg", bytes);
			return filename + ".jpg";
		}

		public string UploadImageResize(FileUpload fileupload, int MaxWidth, int MaxHeight, int ImgQuality, string path)
		{
			HttpContext current = HttpContext.Current;
			if (!Directory.Exists(current.Server.MapPath("~/" + path)))
			{
				Directory.CreateDirectory(current.Server.MapPath("~/" + path));
			}
			string str = current.Server.MapPath("~/" + path + "/");
			string result = "";
			if (fileupload.HasFile)
			{
				string text = DateTime.Now.Ticks.ToString();
				byte[] bytes = new ImageResizer
				{
					MaxWidth = MaxWidth,
					MaxHeight = MaxHeight,
					ImgQuality = ImgQuality,
					OutputFormat = ImageFormat.Jpeg
				}.Resize(fileupload.PostedFile);
				File.WriteAllBytes(str + text + ".jpg", bytes);
				result = path + "/" + text + ".jpg";
			}
			return result;
		}
	}
}
