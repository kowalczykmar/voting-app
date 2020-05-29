using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;

namespace VotingApp
{
    /// <summary>
    /// Klasa strony logowania
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Funkcja wywoływana przy ładowaniu strony logowania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Funkcja sprawdza czy użytkownik jest już zalogowany. Dla zalogowanego zamiast pól do logowania jest wyświetlany komunikat.</para>
        /// <para>Korzysta z metody ReadCookie</para>
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user != "1" && Session["LoggedIn"] != null)
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
        /// Metoda wywoływana przez przycisk logowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Sprawdza czy podany mail istnieje w bazie i jeśli tak, sprawdza czy hasło zgadza się z tym podanym przy rejestracji</para>
        /// <para>W przypadku sukcesu przekierowuje na stronę główną oraz zapisuje w zmiennych sesyjnych informację o tym, że użytkownik jest zalogowany
        /// oraz o jego roczniku, grupie, przedmiotach.</para>
        /// </remarks>
        protected void LoginClick(object sender, EventArgs e)
        {
            String email = EmailTxt.Text.Trim();
            String pass = PasswordTxt.Text.Trim();
            String domain = email.Substring(email.IndexOf("@") + 1);
            email = email.Remove(email.IndexOf("@"));
            if (EmailCheck(email))
            {
                if (PassCheck(email, Encrypt(pass)))
                {
                    Response.Write("<script language='javascript'>window.alert('Logowanie udało się :) Wróć na stronę główną');window.location='Default.aspx';</script>");
                    SetCookie(email);
                    Session["Year"] = GetYear(email);
                    Session["GroupID"] = GetGroupID(email);
                    GetTeachers(email);
                    Session["LoggedIn"] = "1";
                }
                else
                {
                    FailureMessage.Text = "Hasło jest nieprawidłowe";
                }
            }
            else
            {
                FailureMessage.Text = "Podany mail nie jest zarejestrowany";
            }
        }

        /// <summary>
        /// Metoda do sprawdzania, czy podany mail istnieje już w bazie
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Wartość logiczną</returns>
        private Boolean EmailCheck(string email)
        {
            Boolean check = false;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Users where Username = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    check = true;
                }
            }
            return check;
        }
        /// <summary>
        /// Metoda do sprawdzania, czy dla danego maila podane hasło jest prawidłowe
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>Wartość logiczną</returns>
        private Boolean PassCheck(string email, string pass)
        {
            Boolean check = false;
            String confpass = "pass";
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select Password from Users where Username = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                confpass = dr.GetString(0);
            }
            if(confpass == pass)
            {
                check = true;
            }
            return check;
        }

        /// <summary>
        /// Metoda służąca do szyfrowania
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>Zaszyfrowany ciąg znaków</returns>
        /// <remarks>Służy do sprawdzania podanego hasła z zaszyfrowanym hasłem podanym przy rejestracji.</remarks>
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        /// <summary>
        /// Ustawia po stronie użytkownika ciasteczko z nazwą użytkownika oraz kluczem szyfrującym po zalogowaniu.
        /// </summary>
        /// <param name="username"></param>
        /// <remarks>Po udanym logowaniu zapisuje w ciasteczku zaszyfrowaną nazwę użytkownika oraz klucz prywatny algorytmu RSa do odszfyrowania tej
        /// nazwy na innych podstronach aplikacji.</remarks>
        private void SetCookie(String username)
        {
            username = username.Trim();
            username = username.Replace(".", "+");
            username += "+end";
            int mod4 = username.Length % 4;
            if (mod4 > 0)
            {
                username += new string('+', 4 - mod4);
            }

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            var privatekey = rsa.ToXmlString(true);

            String user = ReadCookie();
            if (user == "1")
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                byte[] data = Convert.FromBase64String(username);
                userInfo["UserName"] = Convert.ToBase64String(rsa.Encrypt(data, true));
                userInfo["PrivateKey"] = privatekey;
                Response.Cookies.Add(userInfo);
            }
        }
        /// <summary>
        /// Odczytuje zaszyfrowaną nazwę użytkowika z ciasteczka.
        /// </summary>
        /// <returns>Zaszyfrowaną nazwę użytkownika lub 1, jeśli nie jest zalogowany</returns>
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
        /// Pobiera rocznik na podstawie podanego maila
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Rocznik w formie liczby całkowitej</returns>
        private int GetYear(string email)
        {
            int year = 0;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select Year from Users where Username = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                year = dr.GetInt32(0);
            }
            return year;
        }
        /// <summary>
        /// Pobiera grupę użytownika na podstawie podanego maila.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>ID grupy użytkownika</returns>
        private String GetGroupID(string email)
        {
            string group = "";
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select GroupID from Users where Username = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                group = dr.GetString(0);
            }
            return group;
        }
        /// <summary>
        /// Pobiera prowadzących użytkownika na podstawie maila oraz zapisuje ich w zmiennych sesyjnych.
        /// </summary>
        /// <param name="email"></param>
        private void GetTeachers(string email)
        {
            //string teacher1 = "";
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select Teacher from Subjects where Year = @Year and Groups = @GroupID", con);
            cmd.Parameters.AddWithValue("@Year", GetYear(email));
            cmd.Parameters.AddWithValue("@GroupID", GetGroupID(email));
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String t1 = dt.Rows[0][0].ToString();
            String t2 = dt.Rows[1][0].ToString();
            String t3 = dt.Rows[2][0].ToString();

            Session["Teacher1"] = t1;
            Session["Teacher2"] = t2;
            Session["Teacher3"] = t3;
        }
    }
}