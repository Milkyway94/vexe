using System;
using System.Data;
using System.Web;

namespace SMAC
{
	public class ModControl
	{
		public static int GetID_From_Url(int p, string link)
		{
			int result;
			if (link.Length > 2)
			{
				HttpContext current = HttpContext.Current;
				DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
				{
					"SELECT Content_ID FROM tbl_Content WHERE Lower(Content_Url)='",
					link.ToLower(),
					"' AND Mod_ID=",
					p
				}));
				DataRowCollection rows = dataSet.Tables[0].Rows;
				if (rows.Count > 0)
				{
					result = Convert.ToInt32(rows[0][0]);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetID_From_Linkvideo(int p, string link)
		{
			int result;
			if (link.Length > 2)
			{
				HttpContext current = HttpContext.Current;
				DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
				{
					"SELECT Content_ID FROM tbl_Content WHERE Lower(Content_Code)='",
					link.ToLower(),
					"' AND Mod_ID=",
					p
				}));
				DataRowCollection rows = dataSet.Tables[0].Rows;
				if (rows.Count > 0)
				{
					result = Convert.ToInt32(rows[0][0]);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetModtype(string code)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Modtype_ID FROM tbl_Modtype WHERE Modtype_Code='" + code + "'");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}
    
		public static int GetOldP(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_Parent FROM tbl_Mod WHERE Mod_ID=" + p);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static string GetModCode(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_Code FROM tbl_Mod WHERE Mod_ID=" + p);
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

		public static int GetP_From_Code(string code)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Mod_ID FROM tbl_Mod WHERE Mod_Code='",
				code,
				"' AND lang=",
				current.Session["vlang"]
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetP_From_ID(int id)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_ID FROM tbl_Content WHERE Content_ID=" + id);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetID_From_Url(string link)
		{
			int result;
			if (link.Length > 2)
			{
				HttpContext current = HttpContext.Current;
				DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
				{
					"SELECT Content_ID FROM tbl_Content WHERE Lower(Content_Url)='",
					link.ToLower(),
					"' AND lang=",
					current.Session["vlang"]
				}));
				DataRowCollection rows = dataSet.Tables[0].Rows;
				if (rows.Count > 0)
				{
					result = Convert.ToInt32(rows[0][0]);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetLichID_From_Url(string link)
		{
			int result;
			if (link.Length > 2)
			{
				HttpContext current = HttpContext.Current;
				DataSet dataSet = UpdateData.UpdateBySql("SELECT Lichhoc_ID FROM tbl_Lichhoc WHERE Lower(Lichhoc_Code)='" + link.ToLower() + "'");
				DataRowCollection rows = dataSet.Tables[0].Rows;
				if (rows.Count > 0)
				{
					result = Convert.ToInt32(rows[0][0]);
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static string GetName_From_Code(string code)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Mod_Name FROM tbl_Mod WHERE Mod_Code='",
				code,
				"' AND lang=",
				current.Session["vlang"]
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

		public static string GetModField(string field, int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Mod_",
				field,
				" FROM tbl_Mod WHERE Mod_ID=",
				p
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

		public static string GetField(string field, string tb, string wh)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new string[]
			{
				"SELECT ",
				field,
				" FROM ",
				tb,
				" WHERE ",
				wh
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

		public static string GetModImg(string code)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_Img FROM tbl_Mod WHERE Mod_Code='" + code + "'");
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

		public static int GetSub_Parent(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_ID FROM tbl_Mod WHERE Mod_Parent=" + p + " AND Mod_Status=1");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static int GetLevel(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_Level FROM tbl_Mod WHERE Mod_ID=" + p);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0][0]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static string GetListID(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_ID FROM tbl_Mod WHERE Mod_Parent=" + p + " AND Mod_Status=1");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string text = "";
			for (int i = 0; i < rows.Count; i++)
			{
				text = text + rows[i]["Mod_ID"] + " ";
			}
			return text.ToString();
		}

		public static string GetLocField(string field, int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Location_",
				field,
				" FROM tbl_Location WHERE Location_ID=",
				p
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
        //Quyeths   modify 26/082016
        public static int GetParent(int p)
        {
            DataSet dataSet = UpdateData.UpdateBySql("SELECT Mod_Parent FROM tbl_Mod WHERE Mod_ID=" + p + " AND Mod_Status=1");
            DataRowCollection rows = dataSet.Tables[0].Rows;
            int result;
            if (rows.Count > 0)
            {
                result = Convert.ToInt32(rows[0][0]);
            }
            else
            {
                result = 0;
            }
            return result;
        }
        //Thaodv modify 11/08/2016
        public static string GetModName(object modid)
        {
            HttpContext current = HttpContext.Current;
            return UpdateData.SQLScalar("SELECT Name FROM Shop_Category WHERE ID =" + modid + " AND lang=" + current.Session["vlang"]);
        }

        public static string GetModUrl(object modid)
        {
            HttpContext current = HttpContext.Current;
            return UpdateData.SQLScalar("Select NameAscii from Shop_Category Where ID=" + modid + " AND lang=" + current.Session["vlang"]);
        }

        public static string GetShopCatID(object modid)
        {
            return UpdateData.SQLScalar("Select ShopCatID from tbl_MapModShopCat Where ModID=" + modid);
        }
        
        //quyeths 29/11/2016 GetModTypefrommodID
        public static string GetModtypeFromModID(int modid)
        {
            return UpdateData.SQLScalar("Select Modtype_ID from tbl_Mod Where Mod_ID=" + modid);
        }
    }
}
