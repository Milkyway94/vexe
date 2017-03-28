using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase :Page
{
    private const string SESSION_KEY_LANGUAGE = "CURRENT_LANGUAGE";
    protected override void InitializeCulture()
    {
        base.InitializeCulture();

        //If you would like to have DefaultLanguage changes to effect all users,
        // or when the session expires, the DefaultLanguage will be chosen, do this:
        // (better put in somewhere more GLOBAL so it will be called once)
        //LanguageManager.DefaultCulture = …

        //Change language setting to user-chosen one
        if (Session[SESSION_KEY_LANGUAGE] != null)
        {
            ApplyNewLanguage((CultureInfo)Session[SESSION_KEY_LANGUAGE]);
        }
    }

    private void ApplyNewLanguage(CultureInfo culture)
    {
        LanguageManager.CurrentCulture = culture;
        //Keep current language in session
        Session.Add(SESSION_KEY_LANGUAGE, LanguageManager.CurrentCulture);
    }

    protected void ApplyNewLanguageAndRefreshPage(CultureInfo culture)
    {
        ApplyNewLanguage(culture);
        //Refresh the current page to make all control-texts take effect
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}
