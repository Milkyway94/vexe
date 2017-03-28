using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SMAC
{ 
    public class AuthenticationMenu
    {
        public static bool CheckPermission(int ModID, int UserID)
        {
            string sql = "select * from tbl_ModsiteUser where User_ID="+UserID+"and Mod_ID="+ModID;
            DataTable ds = UpdateData.UpdateBySql(sql).Tables[0];
            DataRowCollection rows = ds.Rows;
            if (rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
