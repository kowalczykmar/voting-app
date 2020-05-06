using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace VotingApp
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // Poniższy kod zapewnia ochronę przed atakami XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Użyj tokenu Anti-XSRF z pliku cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Wygeneruj nowy token Anti-XSRF i zapisz go w pliku cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ustaw token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Zweryfikuj token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Weryfikacja tokenu Anti-XSRF nie powiodła się.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            String user = ReadCookie();
            if (user != "1")
            {
                //RegisterLabel.Text = "Witaj";
                LoginButton.Text = "Wyloguj się";
                RegisterButton.Visible = false;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        private String ReadCookie()
        {
            string User_name = "1";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                User_name = reqCookies["UserName"].ToString();
            }
            return User_name;
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user != "1")
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["UserName"] = 1.ToString();
                Response.Cookies.Add(userInfo);
                LoginButton.Text = ReadCookie();
                Response.Redirect("Default.aspx");
                RegisterButton.Visible = true;
            }
            else
            {
                Response.Redirect("LoginAccount.aspx");
            }
        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user == "1")
            {
                Response.Redirect("RegisterAccount.aspx");
            }
        }
    }

}