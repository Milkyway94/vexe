<%@ WebHandler Language="C#" Class="captcha" %>

using System;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Web.SessionState;
public class captcha : IHttpHandler , IRequiresSessionState{

    public void ProcessRequest(HttpContext context)
    {
        string[] strArray = new string[36];
        strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        // strArray = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random autoRand = new Random();
        string strCaptchaRandom = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int j = Convert.ToInt32(autoRand.Next(0, 9));
            strCaptchaRandom += strArray[j].ToString();
        }
        HttpContext.Current.Session.Add("Captcha", strCaptchaRandom);
        Bitmap objBmp = new Bitmap(80, 33, PixelFormat.Format32bppArgb);
        Graphics objGraphics = Graphics.FromImage(objBmp);
        objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        objGraphics.Clear(Color.FromArgb(255,216,158));
        objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        Font objFont = new Font("Arial",16, System.Drawing.FontStyle.Italic);
        string strCaptcha = string.Empty;
        if (context.Session["Captcha"].ToString() != null)
        {
            strCaptcha = strCaptchaRandom;
        }
        objGraphics.DrawString(strCaptcha, objFont, Brushes.Black,4, 3);
        MemoryStream ms = new MemoryStream();
        objBmp.Save(ms, ImageFormat.Png);

        byte[] bmpBytes = ms.GetBuffer();
        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(bmpBytes);

        objBmp.Dispose();
        objFont.Dispose();
        objGraphics.Dispose();
        ms.Close();
        context.Response.End();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}