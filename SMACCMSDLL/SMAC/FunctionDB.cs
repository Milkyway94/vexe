using SMAC.DataAccess;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace SMAC
{
	public class FunctionDB
	{
		public static string URLRoot = ApplicationSetting.URLRoot;

		public static bool CheckUser(string username)
		{
			bool result = false;
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			string cmdText = "SELECT COUNT(*) FROM tbl_User WHERE Username='" + username + "'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			try
			{
				sqlConnection.Open();
				int num = (int)sqlCommand.ExecuteScalar();
				if (num != 0)
				{
					result = true;
				}
			}
			finally
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			return result;
		}

		public static bool CheckMember(string username, string tb)
		{
			bool result = false;
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			string cmdText = string.Concat(new string[]
			{
				"SELECT COUNT(*) FROM tbl_",
				tb,
				" WHERE ",
				tb,
				"_Username='",
				username,
				"'"
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			try
			{
				sqlConnection.Open();
				int num = (int)sqlCommand.ExecuteScalar();
				if (num != 0)
				{
					result = true;
				}
			}
			finally
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			return result;
		}

		public static bool CheckEmail(string email, string tb)
		{
			bool result = false;
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			string cmdText = string.Concat(new string[]
			{
				"SELECT COUNT(*) FROM tbl_",
				tb,
				" WHERE ",
				tb,
				"_Email='",
				email,
				"'"
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			try
			{
				sqlConnection.Open();
				int num = (int)sqlCommand.ExecuteScalar();
				if (num != 0)
				{
					result = true;
				}
			}
			finally
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			return result;
		}

		public bool HasChildren(string intParentID, string sFilter)
		{
			bool result = false;
			string sql = "SELECT COUNT(*) FROM tbl_ModAdmin WHERE ModAdmin_Status=1 AND ModAdmin_ID=" + intParentID + sFilter;
			int totalRecord = UpdateData.GetTotalRecord(sql);
			if (totalRecord > 0)
			{
				result = true;
			}
			return result;
		}

		public string BuildMenuTop(string UserID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("");
			stringBuilder.Append("<ul class=\"nav navbar-nav pull-left\">");
			DataSet dataSet = (DataSet)HttpContext.Current.Cache["mydata"];
			if (dataSet == null)
			{
				dataSet = UpdateData.UpdateBySql("SELECT * FROM tbl_ModAdmin WHERE ModAdmin_Parent=0 ORDER BY ModAdmin_Pos");
				HttpContext.Current.Cache.Insert("mydata", dataSet, null, DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration);
			}
			DataRowCollection rows = dataSet.Tables[0].Rows;
			for (int i = 0; i < rows.Count; i++)
			{
				string text = " AND tbl_ModAdmin.ModAdmin_ID IN (SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID='" + UserID + "')";
				string text2 = rows[i]["ModAdmin_ID"].ToString();
                if (this.HasChildren(text2, text))
				{
                    string texti = rows[i]["ModAdmin_Icon"].ToString();
                    stringBuilder.Append("\t<li class=\"dropdown messages-menu\">");
					stringBuilder.Append("   <a href=\"#\"><i class=\""+ texti +" fa-2x\"></i><br>" + rows[i]["ModAdmin_Name"].ToString() + "</a>");
					string str = " ORDER BY ModAdmin_Pos ";
					text = string.Concat(new string[]
					{
						" AND ModAdmin_Status=1 AND ModAdmin_Parent=",
						text2,
						" AND tbl_ModAdmin.ModAdmin_ID IN (SELECT ModAdmin_ID FROM tbl_ModUser WHERE UserID='",
						UserID,
						"')"
					});
					string sql = "SELECT * FROM tbl_ModAdmin WHERE 1=1" + text + str;
					DataSet dataSet2 = UpdateData.UpdateBySql(sql);
					DataRowCollection rows2 = dataSet2.Tables[0].Rows;
					stringBuilder.Append("<ul class=\"dropdown-menu\">");
					for (int j = 0; j < rows2.Count; j++)
					{
						string text3 = rows2[j]["ModAdmin_ID"].ToString();
						string text4 = rows2[j]["ModAdmin_Path"].ToString();
						string text5 = FunctionDB.URLRoot + "adcadmin/" + rows2[j]["ModAdmin_Icon"].ToString();
                        string text10 = rows2[j]["ModAdmin_Icon"].ToString();
                        string text6 = rows2[j]["ModAdmin_Name"].ToString();
						stringBuilder.Append(string.Concat(new string[]
						{
							"<li class=\"p\"><a href=\"#\" onclick=\"javascript:location.href='",
							FunctionDB.URLRoot,
							"adcadmin/",
							text4,
							"'\"><i class=\""+text10+"\"></i> ",
							text6,
							"</a></li>"
						}));
					}
					stringBuilder.Append("</ul>");
					stringBuilder.Append("</li>");
				}
			}
			stringBuilder.Append("</ul>");
			return stringBuilder.ToString();
		}

		public static bool AddLog(string DepartmentID, string EmployeeID, string sManipulate, string sContent)
		{
			return UpdateData.Insert("tbl_Log", new Hashtable
			{
				{
					"Log_DepartmentID",
					DepartmentID
				},
				{
					"Log_EmployeeID",
					EmployeeID
				},
				{
					"Log_Manipulate",
					sManipulate
				},
				{
					"Log_Content",
					CMSfunc.CutString(sContent, 50)
				}
			});
		}

		public static string GetName(string tb, string id)
		{
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new string[]
			{
				"SELECT ",
				tb,
				"_Name FROM tbl_",
				tb,
				" WHERE ",
				tb,
				"_ID=",
				id
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0][tb + "_Name"].ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static int GetAdminID()
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT User_ID FROM tbl_User WHERE username='admin'");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0]["User_ID"]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static string GetModType(int p)
		{
			DataSet dataSet = UpdateData.UpdateBySql("SELECT Modtype_Code FROM tbl_Modtype MT, tbl_Mod M WHERE MT.Modtype_ID=M.Modtype_ID AND Mod_ID=" + p);
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string result;
			if (rows.Count > 0)
			{
				result = rows[0]["Modtype_Code"].ToString().Trim();
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static int Get_ID_From_Code(string code)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql(string.Concat(new object[]
			{
				"SELECT Mod_ID FROM tbl_Mod WHERE Mod_Code='",
				code,
				"' AND lang=",
				current.Session["lang"]
			}));
			DataRowCollection rows = dataSet.Tables[0].Rows;
			int result;
			if (rows.Count > 0)
			{
				result = Convert.ToInt32(rows[0]["Mod_ID"]);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public static void GetRole(int uid)
		{
			HttpContext current = HttpContext.Current;
			DataSet dataSet = UpdateData.UpdateBySql("SELECT RU.Role_ID,Role_Name FROM tbl_RoleUser as RU,tbl_Role as R WHERE RU.User_ID=" + uid + " AND RU.Role_ID=R.Role_ID");
			DataRowCollection rows = dataSet.Tables[0].Rows;
			string text = "";
			for (int i = 0; i < rows.Count; i++)
			{
				text = text + rows[i][1] + ",";
			}
			SessionUtil.SetKey("RoleID", text.ToString());
		}

		public static string GetTitleOfTable(string strField, string strTable, string sWhere)
		{
			string result = "";
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			DataSet dataSet = new DataSet();
			string cmdText = string.Concat(new string[]
			{
				"SELECT ",
				strField,
				" FROM ",
				strTable,
				" WHERE ",
				sWhere
			});
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			try
			{
				sqlConnection.Open();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					result = dataSet.Tables[0].Rows[0][strField].ToString();
				}
			}
			finally
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			return result;
		}

		public static ArrayList GetRowAsArrayList(DataSet ds, string sKey)
		{
			SqlConnection sqlConnection = SQLWorker.CreatedConnection();
			ArrayList arrayList = new ArrayList();
			try
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						arrayList.Add(ds.Tables[0].Rows[i][sKey].ToString().Trim());
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (sqlConnection.State == ConnectionState.Open)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			return arrayList;
		}
	}
}
