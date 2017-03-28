<%@ WebHandler Language="C#" Class="Render" %>

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI.WebControls;
public class Render : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string data = context.Request["id"];
        HtmlString htmlString = RenderHtml("/Admin/Modules/Products/Controls/EditProductFrm.ascx", data);
        context.Response.Write(htmlString);
    }
    private HtmlString RenderHtml(string controlName, string id)
    {
        Page page = new Page();
        UserControl control =(UserControl) page.LoadControl(controlName);
        (control.FindControl("ID") as TextBox).Text = id;
        HtmlForm form = new HtmlForm();
        form.Controls.Add(control);
        page.Controls.Add(form);
        StringWriter writer = new StringWriter();
        HttpContext.Current.Server.Execute(page, writer, false);
        HtmlString str = new HtmlString(writer.ToString());
        return str;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}