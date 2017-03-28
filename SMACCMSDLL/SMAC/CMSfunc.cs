using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace SMAC
{
	public class CMSfunc
	{
		public static class VietnameseConvert
		{
			private const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";

			private const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";

			public static string ChuyenTVKhongDau(string strVietNamese)
			{
				int index;
				while ((index = strVietNamese.IndexOfAny("áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ".ToCharArray())) != -1)
				{
					int index2 = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ".IndexOf(strVietNamese[index]);
					strVietNamese = strVietNamese.Replace(strVietNamese[index], "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY"[index2]);
				}
				return strVietNamese;
			}
		}

		public static string _GetConst(string strCode)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Config_Values FROM tbl_Config WHERE Config_Code='" + strCode + "'");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0][0].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string _Title(string code)
		{
			string result;
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				HttpContext current = HttpContext.Current;
				string path = "";
				if (current.Session["vlang"].ToString() == "1")
				{
					path = "~/upload/lang/vn.xml";
				}
				if (current.Session["vlang"].ToString() == "2")
				{
					path = "~/upload/lang/en.xml";
				}
				xmlDocument.Load(HttpContext.Current.Server.MapPath(path));
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("title");
				short num = 0;
				while ((int)num < elementsByTagName.Count)
				{
					if (elementsByTagName.Item((int)num).Attributes.GetNamedItem("value").Value.ToLower() == code.ToLower())
					{
						result = elementsByTagName.Item((int)num).InnerText;
						return result;
					}
					num += 1;
				}
				result = code;
			}
			catch (Exception var_5_FC)
			{
				result = code;
			}
			return result;
		}

		public static string LoadTitleAdm(string f, string strPosition)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Title_Name FROM tbl_Title where Title_Mod='",
				f,
				"' and Title_Pos='",
				strPosition,
				"' and lang=",
				current.Session["lang"]
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0]["Title_Name"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string LoadOther(string f)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Other_Content FROM tbl_Other where Other_Status=1 and Other_Mod='",
				f,
				"' and lang=",
				current.Session["vlang"]
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = HttpContext.Current.Server.HtmlDecode(rows[0]["Other_Content"].ToString());
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string LoadOtherAdm(string f)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Other_Content FROM tbl_Other where Other_Mod='",
				f,
				"' and lang=",
				current.Session["lang"]
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0]["Other_Content"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string _adv(string Ta, string Img, int id, string Url, string vtype, string W, string H, string n)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Path.GetExtension(Img) == ".swf")
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<script type=\"text/javascript\">swf('",
					Img,
					"','",
					W,
					"','",
					H,
					"');</script>"
				}));
			}
			else if (Url != "")
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<a target=\"",
					Ta,
					"\" href=\"",
					Url,
					"\"><img src=\"",
					Img,
					"\" border=\"0\" alt=\"",
					n,
					"\" class=\"img-responsive\"></a>"
				}));
			}
			else
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<img src=\"",
					Img,
					"\" border=\"0\" alt=\"",
					n,
					"\" class=\"img-responsive\">",
					vtype
				}));
			}
			return stringBuilder.ToString();
		}

		public static string LoadSkin(string code, int p)
		{
			HttpContext current = HttpContext.Current;
			StringBuilder stringBuilder = new StringBuilder();
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Skintype_ID,Skintype_Viewtype,Skintype_Vspace,Skintype_Hspace,Skintype_Height,Skintype_Width,Skintype_Limit,Skintype_Target FROM tbl_Skintype WHERE Skintype_Status=1 AND Skintype_Code='" + code + "'");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			if (rows.Count > 0)
			{
				string text = rows[0]["Skintype_ID"].ToString();
				bool flag = Convert.ToBoolean(rows[0]["Skintype_Viewtype"]);
				string text2 = rows[0]["Skintype_Vspace"].ToString();
				string text3 = rows[0]["Skintype_Hspace"].ToString();
				int num = Convert.ToInt32(rows[0]["Skintype_Limit"]);
				string ta = rows[0]["Skintype_Target"].ToString().Trim();
				string text4 = string.Concat(new object[]
				{
					"SELECT top ",
					num,
					" Mod_ID,Skin_ID,Skin_Name,Skin_Url,Skin_Height,Skin_Width,Skin_Link FROM tbl_Skin WHERE lang=",
					current.Session["vlang"],
					" AND Skin_Status=1 AND Skintype_ID=",
					text
				});
				text4 += " ORDER BY Skin_Pos";
				string vtype = flag ? "<br />" : "";
				DataSet dataSet2 = UpdateData.UpdateBySql(text4);
				DataRowCollection rows2 = dataSet2.Tables[0].Rows;
				for (int i = 0; i < rows2.Count; i++)
				{
					int id = Convert.ToInt32(rows2[0]["Skin_ID"]);
					int num2 = Convert.ToInt32(rows2[0]["Mod_ID"]);
					string n = rows2[i]["Skin_Name"].ToString();
					string img = ApplicationSetting.URLRoot + rows2[i]["Skin_Url"].ToString();
					string h = rows2[i]["Skin_Height"].ToString();
					string w = rows2[i]["Skin_Width"].ToString();
					string url = rows2[i]["Skin_Link"].ToString();
					if (num2 == -1)
					{
						stringBuilder.Append(CMSfunc._adv(ta, img, id, url, vtype, w, h, n));
					}
					else if (num2 == p || ModControl.GetOldP(p) == num2)
					{
						stringBuilder.Append(CMSfunc._adv(ta, img, id, url, vtype, w, h, n));
					}
				}
			}
			else
			{
				stringBuilder.Append(CMSfunc.LoadOther(code));
			}
			return stringBuilder.ToString();
		}

		public static string LoadSkinP(string code, int p)
		{
			HttpContext current = HttpContext.Current;
			StringBuilder stringBuilder = new StringBuilder();
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Skintype_ID,Skintype_Viewtype,Skintype_Vspace,Skintype_Hspace,Skintype_Height,Skintype_Width,Skintype_Limit,Skintype_Target FROM tbl_Skintype WHERE Skintype_Status=1 AND Skintype_Code='" + code + "'");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			if (rows.Count > 0)
			{
				string text = rows[0]["Skintype_ID"].ToString();
				bool flag = Convert.ToBoolean(rows[0]["Skintype_Viewtype"]);
				string text2 = rows[0]["Skintype_Vspace"].ToString();
				string text3 = rows[0]["Skintype_Hspace"].ToString();
				int num = Convert.ToInt32(rows[0]["Skintype_Limit"]);
				string text4 = rows[0]["Skintype_Target"].ToString().Trim();
				string text5 = string.Concat(new object[]
				{
					"SELECT top ",
					num,
					" Skin_ID,Skin_Name,Skin_Url,Skin_Height,Skin_Width,Skin_Link FROM tbl_Skin WHERE Skin_Status=1 AND Skintype_ID=",
					text
				});
				if (p != 0)
				{
					if (ModControl.GetLevel(p) == 2)
					{
						p = ModControl.GetOldP(p);
					}
					if (ModControl.GetLevel(p) == 3)
					{
						p = ModControl.GetOldP(ModControl.GetOldP(p));
					}
					text5 = text5 + " AND Mod_ID=" + p;
				}
				else
				{
					text5 += " AND Mod_ID=-1";
				}
				text5 += " ORDER BY Skin_Pos";
				string text6 = flag ? "<br />" : "";
				DataSet dataSet2 = UpdateData.UpdateBySql(text5);
				DataRowCollection rows2 = dataSet2.Tables[0].Rows;
				for (int i = 0; i < rows2.Count; i++)
				{
					string text7 = rows2[0]["Skin_ID"].ToString();
					string text8 = rows2[i]["Skin_Name"].ToString();
					string text9 = ApplicationSetting.URLRoot + rows2[i]["Skin_Url"].ToString();
					string text10 = rows2[i]["Skin_Height"].ToString();
					string text11 = rows2[i]["Skin_Width"].ToString();
					string text12 = rows2[i]["Skin_Link"].ToString();
					if (Path.GetExtension(text9) == ".swf")
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<a target=\"",
							text4,
							"\" href=\"",
							ApplicationSetting.URLRoot,
							"aspx/SaveProcess.aspx?id=",
							text7,
							"&url=",
							text12,
							"\"><script type=\"text/javascript\">swf('",
							text9,
							"','",
							text11,
							"','",
							text10,
							"');</script></a>",
							text6
						}));
					}
					else if (flag)
					{
						if (text12 != "")
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<a target=\"",
								text4,
								"\" href=\"",
								ApplicationSetting.URLRoot,
								"aspx/SaveProcess.aspx?id=",
								text7,
								"&url=",
								text12,
								"\"><img src=\"",
								text9,
								"\" width=\"",
								text11,
								"\" height=\"",
								text10,
								"\" vspace=\"",
								text2,
								"\" border=\"0\" alt=\"",
								text8,
								"\"></a>",
								text6
							}));
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<img src=\"",
								text9,
								"\" width=\"",
								text11,
								"\" height=\"",
								text10,
								"\" border=\"0\" vspace=\"",
								text2,
								"\" alt=\"",
								text8,
								"\"><br>"
							}));
						}
					}
					else if (text12 != "")
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<a target=\"",
							text4,
							"\" href=\"",
							ApplicationSetting.URLRoot,
							"aspx/SaveProcess.aspx?id=",
							text7,
							"&url=",
							text12,
							"\"><img src=\"",
							text9,
							"\" width=\"",
							text11,
							"\" hspace=\"",
							text3,
							"\" height=\"",
							text10,
							"\" border=\"0\" alt=\"",
							text8,
							"\"></a>"
						}));
					}
					else
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<img src=\"",
							text9,
							"\" width=\"",
							text11,
							"\" height=\"",
							text10,
							"\" hspace=\"",
							text3,
							"\" border=\"0\" alt=\"",
							text8,
							"\">"
						}));
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static string CutString(string str, int sLength)
		{
			string text = str;
			if (text.Length > sLength)
			{
				string text2 = text.Substring(0, sLength);
				if (!text2.EndsWith(" ") || !text2.EndsWith(","))
				{
					int num = text2.LastIndexOf(" ");
					if (text2.LastIndexOf(",") > num)
					{
						num = text2.LastIndexOf(",");
					}
					text2 = text2.Substring(0, num + 1);
				}
				text = text2 + "..";
			}
			return text;
		}

		public static string LoadPath(int p, int id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<ul>");
			int p_From_Code = ModControl.GetP_From_Code("Home");
			stringBuilder.Append(string.Concat(new string[]
			{
				"    <li><a title=\"",
				ModControl.GetModField("Title", p_From_Code),
				"\" href=\"",
				VirtualPathUtility.ToAbsolute("~/"),
				"\">",
				CMSfunc._Title("home"),
				"</a></li>"
			}));
			if (ModControl.GetOldP(ModControl.GetOldP(p)) != 0)
			{
				int oldP = ModControl.GetOldP(ModControl.GetOldP(p));
				string text = VirtualPathUtility.ToAbsolute("~/" + ModControl.GetModCode(oldP) + ".htm");
				stringBuilder.Append(string.Concat(new string[]
				{
					"    <li><a title=\"",
					ModControl.GetModField("Name", oldP),
					"\" href=\"",
					text,
					"\">",
					ModControl.GetModField("Name", oldP),
					"</a></li>"
				}));
			}
			if (ModControl.GetOldP(p) != 0)
			{
				int oldP2 = ModControl.GetOldP(p);
				string text = VirtualPathUtility.ToAbsolute("~/" + ModControl.GetModCode(oldP2) + ".htm");
				stringBuilder.Append(string.Concat(new string[]
				{
					"<li><a title=\"",
					ModControl.GetModField("Name", oldP2),
					"\" href=\"",
					text,
					"\">",
					ModControl.GetModField("Name", oldP2),
					"</a></li>"
				}));
			}
			if (p != 0)
			{
				string text = VirtualPathUtility.ToAbsolute("~/" + ModControl.GetModCode(p) + ".htm");
				stringBuilder.Append(string.Concat(new string[]
				{
					"<li><a title=\"",
					ModControl.GetModField("Name", p),
					"\" href=\"",
					text,
					"\">",
					ModControl.GetModField("Name", p),
					"</a></li>"
				}));
			}
			stringBuilder.Append("</ul>");
			return stringBuilder.ToString();
		}

		public bool IsHasVote(string Vote_ModuleID)
		{
			string sql = "SELECT COUNT(*) FROM tbl_Vote WHERE Vote_ModuleID=" + Vote_ModuleID;
			int totalRecord = UpdateData.GetTotalRecord(sql);
			return totalRecord > 0;
		}

		public string LoadVote(string Vote_ModuleID)
		{
			HttpContext current = HttpContext.Current;
			string text = current.Session["vlang"].ToString();
			string text2 = "<script language='javascript'>\r\n\t\t\t<!--\r\n\t\t\tfunction openWindow(url, width , height)\r\n\t\t\t{\r\n\t\t\t\tvar def = 'status=no,resizable=no,scrollbars=yes,toolbar=no,location=no,fullscreen=no,titlebar=yes,height='.concat(height).concat(',').concat('width=').concat(width).concat(',');\r\n\t\t\t\tdef = def.concat('top=').concat((screen.height - height)/2).concat(',');\r\n\t\t\t\tdef = def.concat('left=').concat((screen.width - width)/2);\r\n\t\t\t\twindow.open(url, '_blank', def);\r\n\t\t\t}\r\n\t\t\tfunction Votes(id , url)\r\n\t\t\t{\r\n\t\t\t\tvar objs = document.getElementsByName(id);\t\t\t\t\r\n\t\t\t\tvar sQID = '';\r\n\t\t\t\tfor(var i = 0 ; i < objs.length ; i++ )\r\n\t\t\t\t{\r\n\t\t\t\t\tif(objs[i].checked) sQID += objs[i].value;\r\n                    \r\n\t\t\t\t}\r\n\t\t\t\t\r\n\t\t\t\tif(url.lastIndexOf('?') != -1) url += '&QID=' + sQID;\r\n\t\t\t\telse url += '?QID=' + sQID;\r\n\t\t\t\topenWindow(url, 490 , 250);\r\n\t\t\t}\r\n\t\t\t//-->\r\n\t\t\t</script>";
			if (this.IsHasVote(Vote_ModuleID))
			{
				DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
				{
					"SELECT TOP 1 * FROM tbl_Vote WHERE lang=",
					current.Session["vlang"],
					" AND Vote_IsUse=1 AND Vote_ModuleID=",
					Vote_ModuleID
				}));
				DataRowCollection rows = dataSet.Tables[0].Rows;
				if (rows.Count > 0)
				{
					string text3 = rows[0]["Vote_ID"].ToString();
					string str = rows[0]["Vote_Question"].ToString();
					text2 += "<table width='100%'>";
					text2 += "<tr>";
					text2 = text2 + "<td colspan='2'><b>" + str + "</b></td>";
					text2 += "</tr>";
					for (int i = 1; i <= 5; i++)
					{
						string text4 = rows[0]["Vote_Selection" + i].ToString();
						if (text4.Length > 0)
						{
							string str2 = "";
							if (i == 1)
							{
								str2 = "checked";
							}
							text2 += "<tr>";
							text2 = text2 + "<td align='left' width='2%'>" + string.Format("<input type='radio' value='{0}_{1}' " + str2 + " name='{0}_radio'  id='{0}_radio'>", text3, i) + "</td>";
							text2 = text2 + "<td style='padding:2px;' align='left'>" + text4 + "</td>";
							text2 += "</tr>";
						}
					}
					text2 += "<tr>";
					string text5 = text2;
					text2 = string.Concat(new string[]
					{
						text5,
						"<td colspan='2' style='padding-top:6px;' align='center'><img src='",
						ApplicationSetting.URLImages,
						"/Vote_Button",
						text,
						".gif' style='cursor:pointer;' onclick=\"",
						string.Format("javascript:Votes('{0}_radio','{1}')", text3, "VoteResult.aspx"),
						"\">&nbsp;&nbsp;"
					});
					text5 = text2;
					text2 = string.Concat(new string[]
					{
						text5,
						"<img src='",
						ApplicationSetting.URLImages,
						"/Vote_Result",
						text,
						".gif' style='cursor:pointer;' onclick=\"",
						string.Format("javascript:openWindow('{0}',490,250)", "VoteResult.aspx?QID=" + text3 + "_"),
						"\"></td>"
					});
					text2 += "</tr>";
					text2 += "</table>";
				}
			}
			return text2;
		}

		public static string _Replate(string strIn)
		{
			string result;
			if (strIn.Length != 0)
			{
				string text = strIn.Replace("-", "");
				text = text.Replace(" ", "-");
				text = text.Replace("\"", "");
				text = Regex.Replace(text, "[`~!@#$%^&*()_+=|/{}'?<>,.:;@” ]", string.Empty);
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static string _Replatemod(string strIn)
		{
			string result;
			if (strIn.Length != 0)
			{
				string text = strIn.Replace("-", "");
				text = text.Replace(" ", "");
				text = text.Replace("\"", "");
				text = Regex.Replace(text, "[`~!@#$%^&*()_+=|/{}'?<>,.:;@” ]", string.Empty);
				result = text;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static void checkURL()
		{
			string text = HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToLower();
			if (text.IndexOf("'") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf("union") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf("select") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf("(") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf(")") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf("@") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf("*") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
			if (text.IndexOf(";") != -1)
			{
				HttpContext.Current.Response.Redirect("default.aspx");
			}
		}

		public static string ClearHTMLTags(string source)
		{
			string result;
			if (string.IsNullOrEmpty(source))
			{
				result = source;
			}
			else
			{
				string text = source;
				while (text.IndexOf('<') != -1 && text.IndexOf('>') != -1)
				{
					int num = text.IndexOf('<');
					int num2 = text.IndexOf('>');
					text = text.Remove(num, num2 - num + 1);
				}
				result = text;
			}
			return result;
		}

		public static string ModImage(int p, string w, string h)
		{
			HttpContext current = HttpContext.Current;
			StringBuilder stringBuilder = new StringBuilder();
			string sql;
			if (p != 0)
			{
				sql = "SELECT Mod_Img FROM tbl_Mod WHERE Mod_ID=" + p;
			}
			else
			{
				sql = "SELECT Mod_Img FROM tbl_Mod WHERE Mod_Code='Home'";
			}
			DataSet dataSet = UpdateData.UpdateBySql(sql);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			if (rows.Count > 0)
			{
				string text = rows[0]["Mod_Img"].ToString();
				if (Path.GetExtension(text) == ".swf")
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<div class=\"ModImg\"><script type=\"text/javascript\">swf('",
						ApplicationSetting.URLRoot,
						text,
						"','",
						w,
						"','",
						h,
						"');</script></div>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<div class=\"ModImg\"><img src='",
						ApplicationSetting.URLRoot,
						text,
						"' width=",
						w,
						" height=",
						h,
						" border ='0'></div>"
					}));
				}
			}
			return stringBuilder.ToString();
		}

		public static string Bookmark()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<!-- AddThis Button BEGIN -->");
			stringBuilder.Append("<div class=\"addthis_toolbox addthis_default_style\">");
			stringBuilder.Append("<a class=\"addthis_button_preferred_1\"></a>");
			stringBuilder.Append("<a class=\"addthis_button_preferred_2\"></a>");
			stringBuilder.Append("<a class=\"addthis_button_preferred_3\"></a>");
			stringBuilder.Append("<a class=\"addthis_button_preferred_4\"></a>");
			stringBuilder.Append("<a class=\"addthis_button_compact\"></a>");
			stringBuilder.Append("<a class=\"addthis_counter addthis_bubble_style\"></a>");
			stringBuilder.Append("<a class=\"addthis_button_google_plusone\"></a>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<script type=\"text/javascript\">    var addthis_config = { \"data_track_clickback\": true };</script>");
			stringBuilder.Append("<script type=\"text/javascript\" src=\"http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-5031ac7d2b9bcb55\"></script>");
			stringBuilder.Append("<!-- AddThis Button END -->");
			return stringBuilder.ToString();
		}

		public static string LoadTools(string u, string n)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div class=\"cmp_like_container\" style=\"float:left;margin:10px;\"><fb:like href=\"" + u + "\" layout=\"button_count\" show_faces=\"true\" send=\"true\" width=\"\" action=\"like\" font=\"arial\" colorscheme=\"light\"></fb:like></div>");
			stringBuilder.Append(string.Concat(new string[]
			{
				"<div style=\"float:left;margin:10px;\"><a href=\"//twitter.com/share\" class=\"twitter-share-button\" data-url=\"http://",
				u,
				"\" data-text=\"",
				n,
				"\" data-count=\"horizontal\">Tweet</a></div>"
			}));
			stringBuilder.Append("<div class=\"cmp_google_container\" style=\"float:left;margin:10px;\"><g:plusone size=\"medium\" href=\"" + u + "\" ></g:plusone></div>");
			stringBuilder.Append("<div class=\"clr\"></div>");
			return stringBuilder.ToString();
		}

		public static string Follow(string n, string url)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string uRLRoot = ApplicationSetting.URLRoot;
			stringBuilder.Append("<a target=\"_blank\" href=\"http://www.facebook.com/pages/143598932455380?ref=hl\"><img border=\"0\" align=\"absmiddle\" title=\"Facebook\" src=\"" + uRLRoot + "images/facebook.png\"></a>&nbsp;");
			stringBuilder.Append(string.Concat(new string[]
			{
				"<a target=\"_blank\" href=\"http://twitter.com/intent/tweet?original_referer=",
				url,
				"&amp;text= ",
				n,
				" = ",
				url,
				"\"><img border=\"0\" align=\"absmiddle\" title=\"Twitter\" src=\"",
				uRLRoot,
				"images/twitter.png\"></a>&nbsp;"
			}));
			stringBuilder.Append("<a target=\"_blank\" href=\"http://www.google.com\"><img border=\"0\" align=\"absmiddle\" title=\"google plus\" src=\"" + uRLRoot + "images/g-plus.png\"></a>&nbsp;");
			stringBuilder.Append("<a target=\"_blank\" href=\"http://www.youtube.com\"><img border=\"0\" align=\"absmiddle\" title=\"Youtube\" src=\"" + uRLRoot + "images/youtube.png\"></a>");
			return stringBuilder.ToString();
		}

		public static void LoadDropdown(string title, string sql, DropDownList ddl)
		{
			DataSet dataSet = UpdateData.UpdateBySql(sql);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			ddl.Items.Add(new ListItem(title, "0"));
			for (int i = 0; i < rows.Count; i++)
			{
				ddl.Items.Add(new ListItem(rows[i][0].ToString(), rows[i][1].ToString()));
			}
		}

		public static void LoadDropdown(string title, int num, DropDownList ddl)
		{
			ddl.Items.Add(new ListItem(title, "0"));
			for (int i = 1; i < num; i++)
			{
				ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
		}

		public static string LoadNewsItem(string url, string img, string n, string intro)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div class=\"item-news\">\n");
			stringBuilder.Append("    <div class=\"row\">\n");
			if (img.ToString() != "")
			{
				stringBuilder.Append("        <div class=\"col-md-4\">\n");
				stringBuilder.Append(string.Concat(new string[]
				{
					"        <div class=\"img\"><a href=\"",
					url,
					"\" title=\"",
					n,
					"\"><img src=\"",
					img,
					"\" alt=\"",
					n,
					"\" class=\"img-thumbnail\" /></a></div>\n"
				}));
				stringBuilder.Append("        </div>\n");
			}
			stringBuilder.Append("        <div class=\"col-md-8\">\n");
			stringBuilder.Append("            <div class=\"detail\">\n");
			stringBuilder.Append(string.Concat(new string[]
			{
				"                <a href=\"",
				url,
				"\" title=\"",
				n,
				"\"><h2>",
				n,
				"</h2></a>\n"
			}));
			stringBuilder.Append("                <p>" + CMSfunc.CutString(CMSfunc.ClearHTMLTags(intro), 100) + "</p>");
			stringBuilder.Append(string.Concat(new string[]
			{
				"                <a href=\"",
				url,
				"\" title=\"",
				n,
				"\" class=\"btn btn-primary btn-sm\">",
				CMSfunc._Title("Detail"),
				"</a>\n"
			}));
			stringBuilder.Append("            </div>\n");
			stringBuilder.Append("        </div>\n");
			stringBuilder.Append("    </div>\n");
			stringBuilder.Append("</div>\n");
			return stringBuilder.ToString();
		}

        //thaodv add 11/08/2016
        private static string uRoot = ApplicationSetting.URLRoot;

        public static string ReWriteUrlMod(object modid)
        {
            string modName = ModControl.GetModName(modid);
            string modUrl = ModControl.GetModUrl(modid);
            if (modUrl.Length > 0)
            {
                return (CMSfunc.uRoot + "san-pham/"+ modUrl + ".htm").Replace("--", "-").ToLower();
            }
            if (modUrl.Trim().Length <= 0)
            {
                return (CMSfunc.uRoot + ApplicationUtil.GetTitle(modName) + ".htm").Replace("--", "-").ToLower();
            }
            if (modUrl.Contains("http://"))
            {
                return modUrl;
            }
            if (!modUrl.Contains("~/"))
            {
                return CMSfunc.uRoot + modUrl;
            }
            return VirtualPathUtility.ToAbsolute(modUrl);
        }


    }
}
