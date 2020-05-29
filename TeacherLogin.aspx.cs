using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace VotingApp
{
    /// <summary>
    /// klasa strony do logowania dla prowadzących.
    /// </summary>
    public partial class TeacherLogin : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wywoływana przy załadowaniu strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Jeśli prowadzący jest już zalogowany, wyświetla odpowiedni komunikat i ukrywa pola logowania.</remarks>
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
        /// <summary>
        /// Metoda wywoływana przy naciśnięciu przycisku logowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Sprawdza czy login i hasło są prawidłowe. Przy powodzeniu zapisuje informację o zalogowanym prowadzącym w zmiennej sesyjnej oraz przekierowuje
        /// na stronę główną panelu dla prowadzących. Przy niepowodzeniu wyświetla odpowiedni komunikat.
        /// </remarks>
        protected void LoginClick(object sender, EventArgs e)
        {
            if (EmailTxt.Text == "jan.kowalski" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "jan.kowalski";
                ReadSubject();
                Response.Redirect("TeacherDefault.aspx");
            }
            else if (EmailTxt.Text == "marian.kowal" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "marian.kowal";
                ReadSubject();
                Response.Redirect("TeacherDefault.aspx");
            }
            else if (EmailTxt.Text == "tomasz.nowak" && PasswordTxt.Text == "Test123!")
            {
                Session["TeacherLoggedIn"] = "tomasz.nowak";
                ReadSubject();
                Response.Redirect("TeacherDefault.aspx");
            }
            else
            {
                FailureMessage.Text = "Hasło i/lub nazwa użytkownika jest nieprawidłowe";
            }
        }
        /// <summary>
        /// Odczytuje przedmioty prowadzącego i zapisuje w zmiennych sesyjnych.
        /// </summary>
        private void ReadSubject()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select Subject from Subjects where Teacher = @Teacher", con);
            cmd.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String s1 = dt.Rows[0][0].ToString();
            String s2 = dt.Rows[1][0].ToString();
            String s3 = dt.Rows[2][0].ToString();

            Session["TeacherSubject3"] = s1;
            Session["TeacherSubject2"] = s2;
            Session["TeacherSubject1"] = s3;
        }
    }
}