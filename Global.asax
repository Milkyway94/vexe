<%@ Application Language="C#" %>
<script runat="server">
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.ToString().ToLower();
        if (url.Contains("www"))
        {
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url.Replace("www.", string.Empty));
        }
    }

    protected void Session_Start(Object sender, EventArgs e)
    {
        //Session.Timeout = 20; //20 minute timeout
        int visitors        =   int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[0]);
        int visitors_online =   int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[1]);

        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("/visitor.txt"), false))
        {
            file.Write((visitors+1) + "\n"+ (visitors_online+1));
        }

    }
    void Session_End(object sender, EventArgs e)
    {
        int visitors_online=int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[1]);
        int visitors=int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[0]);
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("/visitor.txt"), false))
        {
            file.Write(visitors + "\n"+ (visitors_online-1));
        }

    }
    protected void Application_End(Object sender, EventArgs e)
    {
        int visitors_online=int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[1]);
        int visitors=int.Parse(System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[0]);
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("/visitor.txt"), false))
        {
            file.Write(visitors + "\n"+ (visitors_online-1));
        }
    }


    void Application_Start(object sender, EventArgs e)
    {
        Application["visitors_online"] = 0;
        string visitors = System.IO.File.ReadAllLines(Server.MapPath("~/visitor.txt"))[1];
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("/visitor.txt"), false))
        {
            file.Write(0 + "\n"+ visitors);
        }
        //Application["ComponentArtWebUI_AppKey"] = "cd2e15e4-92e7-444c-99fe-cecb54320597";
        //BundleConfig.RegisterBundles(BundleTable.Bundles);

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        Response.Write(e.ToString());
    }
</script>
