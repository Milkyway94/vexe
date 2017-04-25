using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Value
/// </summary>
public static class Value
{
    public static string GetValue(string lang, string key)
    {
        string sql = "SELECT * FROM LangValue WHERE [Key]='"+key+"'";
        DataSet ds = UpdateData.UpdateBySql(sql);
        DataRowCollection rows = ds.Tables[0].Rows;
        StringBuilder str = new StringBuilder();
        if (rows.Count > 0)
        {
            if (lang == "1")
            {
                string link = rows[0]["viValue"].ToString();
                str.Append(link);
            }
            else
            {
                string link = rows[0]["enValue"].ToString();
                str.Append(link);
            }
        }
        return str.ToString();
    }
    public static string CutAddressString(string address)
    {
        string[] str = address.Split(',');
        string result = "";
        str[str.Count() - 1] = "";
        for (int i = 0; i < str.Count()-1; i++)
        {
            result += str[i];
            if(i!= str.Count() - 2)
            {
                result += ",";
            }
        }
        return result;
    }
    public static void ShowMessage(Literal ltr, string Message, string type)
    {
        ltr.Visible = true;
        StringBuilder str = new StringBuilder();
        str.Append("<div class=\"uk-alert-"+type+"\" uk-alert>");
        str.Append("<a class=\"uk-alert-close\" uk-close></a>");
        str.Append("<p>");
        str.Append("<span class=\"uk-margin-small-right\" uk-icon=\"icon: ban\"></span>");
        str.Append(Message);
        str.Append("</p>");
        str.Append("</div>");
        ltr.Text = str.ToString();
    }
    public static string GetTimestamp(this DateTime value)
    {
        return value.ToString("yyyyMMddHHmmss");
    }
    public static TimeSpan DiffTime(string sBegin, string sEnd)
    {
        DateTime tBegin = Convert.ToDateTime(sBegin);
        DateTime tEnd = Convert.ToDateTime(sEnd);
        TimeSpan ts = new TimeSpan();

        ts = (TimeSpan)(tEnd - tBegin);
        return ts;
    }
    public static string _Replate(string str)
    {
        str = str.Replace("'", "");
        str = str.Replace("*", "");
        str = str.Replace(";", "");
        str = str.Replace("-", "");
        str = str.Replace("~", "");
        str = str.Replace(")", "");
        str = str.Replace("(", "");
        str = str.Replace("]", "");
        str = str.Replace("[", "");
        str = str.Replace("@", "");
        str = str.Replace("%", "");
        str = str.Replace("<", "");
        str = str.Replace(">", "");
        return str.ToString();
    }
    public static void BindToDropdown(DropDownList ddl, DataTable dt)
    {
        ddl.DataSource = dt;
        ddl.DataTextField = "text";
        ddl.DataValueField = "id";
        ddl.DataBind();
    }
    public static string CreateSlug(string Title)
    {
        string Slug = Title.ToLower();
        // Replace characters specific fo croatian language
        // You don't need this part for english language
        // Also, you can replace other characters specific for other languages
        // e.g. é to e for French language etc.
        Slug = Slug.Replace("č", "c");
        Slug = Slug.Replace("ć", "c");
        Slug = Slug.Replace("š", "s");
        Slug = Slug.Replace("ž", "z");
        Slug = Slug.Replace("đ", "dj");

        // Replace - with empty space
        Slug = Slug.Replace("-", " ");

        // Replace unwanted characters with space
        Slug = Regex.Replace(Slug, "[^a-z0-9\\s-]", " ");
        // Replace multple white spaces with single space
        Slug = Regex.Replace(Slug, "\\s+", " ").Trim();
        // Replace white space with -
        Slug = Slug.Replace(" ", "-");

        return Slug;
    }
}
public enum ErrorCode
{
    UNAUTHORIZED,
    NODATA,
    RETURN_NULL,
    SUCCESS,
    FAIL,
    UNKNOW_ERROR,
    NOT_EQUAL,
    TURNDATA
}
public static class ErrorMessage
{
    public static string Required = "Bạn phải nhập {0}.";
    public static string Unauthorized = "Bạn chưa đăng nhập.";
    public static string NotFound = "{0} không tồn tại.";
    public static string NoData = "Không có dữ liệu nào được trả về.";
    public static string Success = "{0} thành công.";
    public static string Fail = "{0} không thành công.";
    public static string UnknowError = "Lỗi không xác định.";
    public static string DataCount = "Có {0} {1} được tìm thấy.";
    public static string LoginFail = "Số điện thoại hoặc mật khẩu không đúng.";
    public static string AccountLocked = "Tài khoản của bạn đã bị khóa hoặc chưa được kích hoạt.";
    public static string NotEqual = "Vé cũ phải có giá trị lớn hơn hoặc bằng giá trị vé hiện tại.";
    public static string NoVertification = "Bạn chưa xác thực giao dịch xe";
    public static string HaveTransaction = "Đã phát sinh giao dịch, chưa xác nhận!";
    public static string NoTransaction = "Chưa phát sinh giao dịch!";
    public static string ExTimeOut = "Đã quá thời gian cho phép đổi vé!";
    public static string TimeOut = "{0} đã hết hạn sử dụng.";
    public static string OutOfBound = "{0} không nằm trong khoảng {1}!";
    public static string CanApply = "{0} có thể áp dụng.";
}
public static class AlertType
{
    public static string ERROR = "danger";
    public static string WARNING = "warning";
    public static string SUCCESS = "success";
    public static string PRIMARY = "primary";
}
public class Result<T>
{
    public ErrorCode errcode { get; set; }
    public string message { get; set; }
    public T data { get; set; }

}
public class CheckOutMethod
{
    int id { get; set; }
    string name { get; set; }
}
public enum OrderStatus
{
    ChuaThanhToan=-1,
    ChuaGiaoDich=0,
    CoGiaoDichChuaXacThuc,
    DaXacThuc,
    ChuaCheckIn,
    DaCheckIn
} 