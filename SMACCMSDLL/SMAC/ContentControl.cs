using SMAC.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace SMAC
{
	public class ContentControl
	{
		private SqlCommand command;

		public DataTable dt_Contentsearch(int pagecurrent, int pagesize, string fields, string where, string order)
		{
			DataTable dataTable = new DataTable();
			this.command = new SqlCommand("Content_search", SQLWorker.CreatedConnection());
			this.command.CommandType = CommandType.StoredProcedure;
			this.command.Parameters.AddWithValue("@pagesize", pagesize);
			this.command.Parameters.AddWithValue("@gotopage", pagecurrent);
			this.command.Parameters.AddWithValue("@Fields", fields);
			this.command.Parameters.AddWithValue("@where_text", where);
			this.command.Parameters.AddWithValue("@order_text", order);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.command);
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter.Dispose();
			return dataTable;
		}

		public DataTable dt_Contentsearch(int pagecurrent, int pagesize, string where, string order)
		{
			return this.dt_Contentsearch(pagecurrent, pagesize, "*", where, order);
		}

		public DataTable dt_Contentsearch(int pagecurrent, int pagesize, string order)
		{
			return this.dt_Contentsearch(pagecurrent, pagesize, "*", "1=1", order);
		}

		public DataTable dt_Contentsearch_view(int pagecurrent, int pagesize, string where, string order)
		{
			DataTable dataTable = new DataTable();
			this.command = new SqlCommand("Content_search_view", SQLWorker.CreatedConnection());
			this.command.CommandType = CommandType.StoredProcedure;
			this.command.Parameters.AddWithValue("@pagesize", pagesize);
			this.command.Parameters.AddWithValue("@gotopage", pagecurrent);
			this.command.Parameters.AddWithValue("@where_text", where);
			this.command.Parameters.AddWithValue("@order_text", order);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(this.command);
			sqlDataAdapter.Fill(dataTable);
			sqlDataAdapter.Dispose();
			return dataTable;
		}

		public static int getCommentCount(int id)
		{
			DataTable dataTable = UpdateData.UpdateBySql("SELECT Comment_ID FROM tbl_Comment WHERE Comment_Status=1 AND Content_ID=" + id).Tables[0];
			DataRowCollection rows = dataTable.Rows;
			return rows.Count;
		}

		public static bool CheckGroup(int p)
		{
			bool result = false;
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_ID FROM tbl_Mod WHERE Mod_Parent=" + p);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			if (rows.Count > 0)
			{
				result = true;
			}
			return result;
		}

		public static bool CheckGroupContent(int p)
		{
			bool result = false;
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_ID FROM tbl_Content WHERE Mod_ID=" + p);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			if (rows.Count >= 1)
			{
				result = true;
			}
			return result;
		}

		public static string _LoadControl(int p)
		{
			string text = "SELECT Modtype_Code FROM tbl_Modtype as MT, tbl_Mod as M";
			text = text + " WHERE MT.Modtype_ID=M.Modtype_ID AND Mod_ID=" + p;
			DataSet dataSet = UpdateData.UpdateBySql(text);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0][0].ToString().Trim();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static void Load_Head(string css, string icon, string url, string n, string d, ref StringBuilder str)
		{
			string text = "";
			if (css != "")
			{
				text = string.Concat(new string[]
				{
					" class='",
					css,
					"' onmouseover=\"this.className='",
					css,
					"ov';\" onmouseout=\"this.className='",
					css,
					"';\""
				});
			}
			if (icon != "")
			{
				icon = "<img src='" + icon + "' align='absmiddle' border='0' alt=''> ";
			}
			if (d != "")
			{
				d = " <font style='color:#333333;'>[" + d + "] - </font>";
			}
			if (n != "")
			{
				if (url != "")
				{
					str.Append(string.Concat(new string[]
					{
						"<div ",
						text,
						"><a href='",
						url,
						"'>",
						icon,
						d,
						n,
						"</a></div>"
					}));
				}
				else
				{
					str.Append(string.Concat(new string[]
					{
						"<div class='",
						css,
						"'>",
						icon,
						d,
						n,
						"</div>"
					}));
				}
			}
		}

		public static void Load_Img(string url, string css, string img, string align, int w, int h, ref StringBuilder str)
		{
			string text = "";
			string text2 = string.Concat(new string[]
			{
				" class='",
				css,
				"' onmouseover=\"this.className='",
				css,
				"ov';\" onmouseout=\"this.className='",
				css,
				"';\" "
			});
			if (w == 0)
			{
				text = "height=" + h + " border=0 hspace=0 vspace=0";
			}
			if (h == 0)
			{
				text = "width=" + w + " border=0 hspace=0 vspace=0";
			}
			if (w != 0 && h != 0)
			{
				text = string.Concat(new object[]
				{
					"width=",
					w,
					" height=",
					h,
					" border=0 hspace=0 vspace=0"
				});
			}
			if (img != null)
			{
				if (Path.GetExtension(img) == ".swf")
				{
					str.Append(string.Concat(new object[]
					{
						"<script type=\"text/javascript\">swf('",
						img,
						"','",
						w,
						"','",
						h,
						"');</script>"
					}));
				}
				else
				{
					str.Append(string.Concat(new string[]
					{
						"<a href=\"",
						url,
						"\"><img align='",
						align,
						"' ",
						text2,
						text,
						" src='",
						img,
						"'></a>"
					}));
				}
			}
		}

		public static void Load_Img_Tip(string url, string css, string tip, string img, string align, int w, int h, ref StringBuilder str)
		{
			string text = "";
			string text2 = "";
			string text3 = string.Concat(new string[]
			{
				" class='",
				css,
				"' onmouseover=\"Tip('",
				tip,
				"')\" onmouseout=\"UnTip()\" "
			});
			if (w == 0)
			{
				text2 = "height=" + h + " border=0 hspace=1 vspace=1";
			}
			if (h == 0)
			{
				text2 = "width=" + w + " border=0 hspace=1 vspace=1";
			}
			if (w != 0 && h != 0)
			{
				text2 = string.Concat(new object[]
				{
					"width=",
					w,
					" height=",
					h,
					" border=0 hspace=1 vspace=1"
				});
			}
			if (url != "")
			{
				text = " onclick=\"document.location='" + url + "';\"";
			}
			if (img != "")
			{
				str.Append(string.Concat(new string[]
				{
					"<img align='",
					align,
					"' ",
					text,
					text3,
					text2,
					" src='",
					img,
					"'>"
				}));
			}
		}

		public static string ClickDetail(string url)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div class=\"ClickDetail\"><a href=\"" + url + "\">");
			stringBuilder.Append(string.Concat(new string[]
			{
				"<img src='",
				ApplicationSetting.URLImages,
				"/ic_mn.gif' border='0' align='absmiddle'> ",
				CMSfunc._Title("Detail"),
				"</a> </div>"
			}));
			return stringBuilder.ToString();
		}

		public static string GetField(string field, object id)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT ",
				field,
				" FROM tbl_Content WHERE Content_ID=",
				id
			}));
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

		public static string GetContentField(string field, int id)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Content_",
				field,
				" FROM tbl_Content WHERE Content_ID=",
				id
			}));
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

		public static void UpdateCount(int id)
		{
			UpdateData.UpdateBySql("UPDATE tbl_Content SET Content_Count=Content_Count+1 WHERE Content_ID=" + id);
		}

		public static string LoadTags(string tags)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = tags.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != "")
				{
					string text = VirtualPathUtility.ToAbsolute("~/" + ApplicationUtil.GetTitle(array[i]) + ".htm");
					stringBuilder.Append(string.Concat(new string[]
					{
						"<a href=\"",
						text,
						"\" title=\"",
						array[i],
						"\">",
						array[i],
						"</a>"
					}));
					if (i < array.Length - 1)
					{
						stringBuilder.Append(", ");
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static void RaovatCount(int id)
		{
			UpdateData.UpdateBySql("UPDATE tbl_Raovat SET Raovat_Count=Raovat_Count+1 WHERE Raovat_ID=" + id);
		}

        public static string GetFieldByCode(string field, string Code)
        {
            DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
            {
                "SELECT Content_",
                field,
                " FROM tbl_Content WHERE Content_Code='",
                Code +"'"
            }));
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

    }
}
