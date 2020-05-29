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
    /// <summary>
    /// Klasa MasterPage, która odpowiada za część wspólnych funkcjonalności wszytskich stron, np. za odpowiednie wyświetlanie nagłówka.
    /// </summary>
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
        /// <summary>
        /// Metoda wywoływana przy załadowaniu strony.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Jeśli użytkownik jest już zalogowany, zmienia treść przycisku logowania na "Wyloguj się" oraz ukrywa przycisk rejestracji.</remarks>
        protected void Page_Load(object sender, EventArgs e)
        {

            String user = ReadCookie();
            if ((user != "1" && Session["LoggedIn"] != null) || Session["TeacherLoggedIn"] != null)
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
        /// <summary>
        /// Metoda odczytująca nazwę użytkownika z ciasteczka.
        /// </summary>
        /// <returns>Zaszyfrowaną nazwę użytkownika lub 1 dla niezalogowanego użytkownika</returns>
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
        /// <summary>
        /// Metoda przycisku logowania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Jeśli użytkownik jest zalogowany, służy wylogowaniu. Wtedy nadpisuje ciasteczko nowym, w którym nazwa użytkownika to 1</para>
        /// <para>Dla niezalogowanego użytkownika kieruje na stronę logowania</para>
        /// <para>Dla zalogowanego prowadzącego służy do wylogowania. Wtedy usuwa zmienną sesyjną przechowującą informację o zalogowanym prowadzącym.</para>
        /// </remarks>
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
            else if (Session["TeacherLoggedIn"] != null)
            {
                Session.Remove("TeacherLoggedIn");
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("LoginAccount.aspx");
            }
        }
        /// <summary>
        /// Przycisk rejestracji, kieruje niezalogowanego użytkownika na stronę rejestracji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RegisterClick(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user == "1")
            {
                Response.Redirect("RegisterAccount.aspx");
            }
        }
        /// <summary>
        /// Metoda przycisku Panel dla prowadzących.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Kieruje zalogowanego prowadzącego na stronę główną panelu dla prowadzących, gdzie wyświetlane są opinie o jego przediotach. 
        /// Niezalogowanego użytkownika kieruje na stronę logowania dla prowadzących.</remarks>
        protected void TeacherClick(object sender, EventArgs e)
        {
            if (Session["TeacherLoggedIn"] != null)
            {
                Response.Redirect("TeacherDefault.aspx");
            }
            else
            {
                Response.Redirect("TeacherLogin.aspx");
            }
        }
    }

}