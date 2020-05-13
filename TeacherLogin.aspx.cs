using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VotingApp
{
    public partial class TeacherLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherLoggedIn"] != null)
            {
                EmailLabel.Visible = false;
                EmailTxt.Visible = false;
                PasswordLabel.Visible = false;
                PasswordTxt.Visible = false;
                LoginButton.Visible = false;
                LoggedInText.Visible = true;
            }
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            if (EmailTxt.Text == "jan.kowalski" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "jan.kowalski";
                Response.Redirect("TeacherDefault.aspx");
            }
            else if (EmailTxt.Text == "marian.kowal" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "marian.kowal";
                Response.Redirect("TeacherDefault.aspx");
            }
            else if (EmailTxt.Text == "tomasz.nowak" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "tomasz.nowak";
                Response.Redirect("TeacherDefault.aspx");
            }
            else
            {
                FailureMessage.Text = "Hasło i/lub nazwa użytkownika jest nieprawidłowe";
            }
        }
    }
}