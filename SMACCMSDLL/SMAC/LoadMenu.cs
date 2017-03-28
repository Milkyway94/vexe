using System;
using System.Data;
using System.Text;
using System.Web;

namespace SMAC 
{
	public class LoadMenu
	{
		public static string GetMnLeft(string f, int cp)
		{
			HttpContext current = HttpContext.Current;
			StringBuilder stringBuilder = new StringBuilder();
			string text = "SELECT * FROM tbl_Mod WHERE lang=" + current.Session["vlang"] + " AND Mod_Status=1";
			text += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menuleft' AND lang=",
				current.Session["vlang"],
				")) ORDER BY Mod_Pos"
			});
			DataSet dataSet = UpdateData.UpdateBySql(text);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			for (int i = 0; i < rows.Count; i++)
			{
				int num = Convert.ToInt32(rows[i]["Mod_ID"]);
				string text2 = rows[i]["Mod_Name"].ToString();
				string text3 = rows[i]["Mod_Code"].ToString();
				string text4 = CMSfunc.VietnameseConvert.ChuyenTVKhongDau(text2.Replace(" ", "-"));
				string text5 = VirtualPathUtility.ToAbsolute(string.Concat(new object[]
				{
					"~/",
					text3,
					"/",
					num,
					"/",
					num,
					"/",
					text4,
					".aspx"
				}));
				stringBuilder.Append("<div class='Menuleft' onMouseOut=\"this.className='Menuleft';\" onmouseover=\"this.className='Menuleftov';\" " + text5 + ">");
				stringBuilder.Append(string.Concat(new string[]
				{
					"<a title=\"",
					text2,
					"\" href='",
					text5,
					"'>",
					text2,
					"</a></div>"
				}));
			}
			return stringBuilder.ToString();
		}

		public static string GetMnFooter()
		{
			HttpContext current = HttpContext.Current;
			string text = "SELECT * FROM tbl_Mod WHERE lang=" + current.Session["vlang"] + " AND Mod_Status=1";
			text += " AND Mod_ID in (SELECT Mod_ID FROM tbl_ModBox WHERE";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				" Box_ID in(SELECT Box_ID FROM tbl_Box WHERE Box_Code='Menufooter' AND lang=",
				current.Session["vlang"],
				"))"
			});
			text += " ORDER BY Mod_Pos";
			DataSet dataSet = UpdateData.UpdateBySql(text);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < rows.Count; i++)
			{
				int num = Convert.ToInt32(rows[i]["Mod_ID"]);
				string text2 = rows[i]["Mod_Name"].ToString();
				string text3 = rows[i]["Mod_Code"].ToString();
				string text4 = CMSfunc.VietnameseConvert.ChuyenTVKhongDau(CMSfunc._Replate(text2));
				string text5;
				if (text3 == "Home")
				{
					text5 = VirtualPathUtility.ToAbsolute("~/Default.aspx");
				}
				else
				{
					text5 = VirtualPathUtility.ToAbsolute(string.Concat(new string[]
					{
						"~/",
						text3,
						"/",
						text4,
						".aspx"
					})) + "?p=" + num;
				}
				stringBuilder.Append(string.Concat(new string[]
				{
					"<a title=\"",
					text2,
					"\" href='",
					text5,
					"'>",
					text2,
					"</a>"
				}));
				if (i < rows.Count - 1)
				{
					stringBuilder.Append("&nbsp;&nbsp; <a href='#'>|</a> &nbsp;&nbsp;");
				}
			}
			return stringBuilder.ToString();
		}
	}
}
