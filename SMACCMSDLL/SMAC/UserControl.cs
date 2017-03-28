using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMAC
{
    public class UserControls
    {
        //Check Exist
        //public static bool  isExisted(string UserName)
        //{
        //    var res = db.tbl_Users.Where(o => o.username == UserName);
        //    if (res != null)
        //    {
        //        if (res.Count() > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else { return false; }
        //}
        //public static string Register(string UserName, string Name, string Email, string Password, string Phone, int Role, DateTime Date, string address)
        //{
        //    if (!isExisted(UserName))
        //    {
        //        string sql = "insert into tbl_User(username,User_Name, User_Pass, User_Email, User_Tel, User_Status, User_Role, User_Address)";
        //        sql += "values('" + UserName + "',N'" + Name + "','" + Password + "','" + Email + "','" + Phone + "'," + 1 + "," + Role + ", N'"+address+"')";
        //        try
        //        {
        //            UpdateData.UpdateBySql(sql);
        //            return "Y";
        //        }
        //        catch (Exception ex)
        //        {
        //            return sql + ex.ToString();
        //        }
        //    }
        //    else
        //    {
        //        return "Existed";
        //    }
        //}
        //public static tbl_User GetUserByID(int uid)
        //{
        //    return db.tbl_Users.Where(o => o.User_ID == uid).SingleOrDefault();
        //}
        //Check Logined
        //public static bool CheckPassword(int UserID, string Pass)
        //{
        //    var res = db.tbl_Users.Where(o => o.User_ID == UserID && o.User_Pass == Pass).ToList();
        //    if(res==null || res.Count == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
       
        
    }
}
