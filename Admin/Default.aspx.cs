using System;
using System.Web.UI.WebControls;
using SMAC;
using System.Text;
using System.Web.Services;
using System.Collections.Generic;
using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using System.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;

public partial class Administrator_Default : System.Web.UI.Page
{
    public string sRootAppPath = "../../";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            //ltrDashBoard.Text=LoadDarshBoard();
        }
    }
    public string LoadDarshBoard()
    {
        StringBuilder str = new StringBuilder();
        str.Append("<h1 class=\"text-center\">BẢNG TIN XIN MỜI</h1>");
        return str.ToString();
    }
    //public void LoadMember()
    //{
    //    //Session.Timeout = 240;
    //    if (Session["UserID"] != null)
    //    {
    //        string UserID = Session["UserID"].ToString();
    //        DataSet ds = UpdateData.UpdateBySql("SELECT * FROM tbl_User WHERE User_ID=" + UserID);
    //        DataRowCollection rows = ds.Tables[0].Rows;
    //        if (rows.Count > 0)
    //        {
    //            lbName.Text = rows[0]["User_Name"].ToString();
    //            lbEmail.Text = rows[0]["Username"].ToString();
    //            lbTel.Text = rows[0]["User_Mobile"].ToString();
    //        }
    //    }
    //}
    [WebMethod]
    public static List<ModFLD> GetFldFromMod(int modid)
    {
        FldRepository fldRepo = new FldRepository();
        var res = fldRepo.SearchFor(o => o.ModAdminId == modid).ToList();
        foreach (var item in res)
        {
            item.tbl_ModAdmin = null;
        }
        return res;
    }
    [WebMethod]
    public static string SELECTALLCHUYENXE()
    {
        var obj = SMAC.UpdateData.ExecStore("SP_ViewChuyenXe", SessionUtil.GetValue("UserID")).Tables[0];
        return JsonConvert.SerializeObject(obj);
    }
    [WebMethod]
    public static string DELCHUYENXE(string machuyenxe)
    {
        ChuyenXeRepository cxRepo = new ChuyenXeRepository();
        ChuyenXe cx = cxRepo.Find(int.Parse(machuyenxe));
        var res = cxRepo.Remove(cx);
        cxRepo.Save();
        return JsonConvert.SerializeObject(res);
    }

    [WebMethod]
    public static string Execute(string sp, string param)
    {
        try
        {
            var obj = SMAC.UpdateData.ExecStore(sp, param).Tables[0];
            return JsonConvert.SerializeObject(obj);
        }
        catch (Exception ex)
        {
            return sp + param + "/" + ex.Message;
        }
    }
    [WebMethod]
    public static string ExecuteScalar(int mid, string sp, string param, int fldcount)
    {
        var c = new JsonSerializer();
        dynamic obj = c.Deserialize(new StringReader(param), typeof(object));
        var context = new vexedtEntities();
        FldRepository fldRepo = new FldRepository();
        var fld = fldRepo.SearchFor(o => o.ModAdminId == mid).ToList();
        List<string> lst = new List<string>();
        List<SqlParameter> para = new List<SqlParameter>();
        foreach (var item in fld)
        {
            if (obj[item.FldName] != null)
            {
                sp += " @" + item.FldName;
                if (fld.IndexOf(item) < fldcount)
                {
                    sp += ",";
                }
                item.tbl_ModAdmin = null;
                lst.Add((string)item.FldName);
                SqlParameter parameter = new SqlParameter();
                switch (item.FldType)
                {
                    case "PK":
                    case "CCB":
                    case "NUM":
                        parameter.SqlDbType = System.Data.SqlDbType.Int;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = 0;
                        }
                        else
                        {
                            parameter.Value = (int)(obj[item.FldName]);
                        }
                        break;
                    case "TIME":
                        parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = (string)(obj[item.FldName]);
                        }
                        break;
                    case "DATE":
                        parameter.SqlDbType = System.Data.SqlDbType.Date;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = (DateTime)(obj[item.FldName]);
                        }
                        break;
                    case "FLOAT":
                        parameter.SqlDbType = System.Data.SqlDbType.Float;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = 0;
                        }
                        else
                        {
                            parameter.Value = (double)(obj[item.FldName]);
                        }
                        break;
                    case "TXT":
                    case "HTML":
                        parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = (string)(obj[item.FldName]);
                        }
                        break;
                    case "CKB":
                        parameter.SqlDbType = System.Data.SqlDbType.Bit;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = false;
                        }
                        else
                        {
                            parameter.Value = (bool)(obj[item.FldName]);
                        }
                        break;
                    default:
                        parameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                        if (obj[item.FldName] == null)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = (string)(obj[item.FldName]);
                        }
                        break;
                }
                parameter.ParameterName = item.FldName;
                para.Add(parameter);
            }
        }

        int res;
        try
        {
            res = context.Database.ExecuteSqlCommand(sp, para.ToArray());
        }
        catch (Exception ex)
        {
            return sp + "\n" + JsonConvert.SerializeObject(para) + "\n" + ex.ToString();
        }

        return JsonConvert.SerializeObject(res);
    }
    [WebMethod]
    public static string GetModFromId(int mid)
    {
        string sql = "SELECT * FROM tbl_ModAdmin WHERE ModAdmin_Id=" + mid;
        var res = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(res);
    }

    [WebMethod]
    public static string GetBtnFromMod(int mid)
    {
        string sql = "SELECT * FROM ModBtn WHERE ModId=" + mid;
        var res = UpdateData.UpdateBySql(sql).Tables[0];
        return JsonConvert.SerializeObject(res);
    }
    [WebMethod]
    public static string GetAllXe()
    {
        return JsonConvert.SerializeObject(UpdateData.ExecStore("SP_GetAllXe", SessionUtil.GetValue("UserID")).Tables[0]);
    }
}
