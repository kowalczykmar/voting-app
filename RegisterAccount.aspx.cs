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
    /// Klasa strony rejestracji.
    /// </summary>
    public partial class WebForm2 : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wywoływana przy załadowaniu strony rejestracji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Metoda sprawdza, czy użytkownik jest już zalogowany. Dla zalogowanego użytkownika zamiast pól rejestracji wyświetlany jest komunikat.</remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user != "1" && Session["LoggedIn"] != null)
            {
                ErrorMessage.Visible = false;
                EmailLabel.Visible = false;
                EmailTxt.Visible = false;
                PasswordLabel.Visible = false;
                PasswordTxt.Visible = false;
                ConfirmPasswordLabel.Visible = false;
                ConfirmPasswordTxt.Visible = false;
                RegisterButton.Visible = false;
                LoggedInText.Visible = true;
            }
        }
        /// <summary>
        /// Metoda przycisku rejestracji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Metoda w kolejności sprawdza, czy podany mail jest w porpawnej domenie (student.up.krakow.pl), czy mail istnieje już w bazie, czy podane
        /// hasło oraz powtórzone hasło są takie samo oraz czy hasła spełnia odpowiednie kryteria (metoda ValidatePassword)</para>
        /// <para>W przypadku sukcesu zapisuje użytkownika oraz hasło w bazie Users oraz przekierowuje na stronę logowania.</para>
        /// </remarks>
        protected void RegisterClick(object sender, EventArgs e)
        {
            //walidacja email i hasla
            String email = EmailTxt.Text.Trim();
            String pass = PasswordTxt.Text.Trim();
            String passconf = ConfirmPasswordTxt.Text.Trim();
            String domain = email.Substring(email.IndexOf("@") + 1);
            String groupid = Group.SelectedValue.ToString();
            if (domain == "student.up.krakow.pl")
            {
                email = email.Remove(email.IndexOf("@"));
                if (EmailCheck(email))
                {

                    if (pass == passconf)
                    {
                        if (ValidatePassword(pass))
                        {
                            InsertRecord(email, pass, groupid);
                            Response.Write("<script language='javascript'>window.alert('Rejestracja się powiodła, zaloguj się');window.location='LoginAccount.aspx';</script>");
                        }
                        else
                        {
                            ErrorMessage.Text = "Hasło jest nieprawidłowe, musi zawierać co najmniej 8 znaków, jedną wielką literę, jedną cyfrę i jeden znak specjalny";
                        }
                    }
                    else
                    {
                        ErrorMessage.Text = "Powtórzone hasło jest nieprawidłowe";
                    }
                }
                else
                {
                    ErrorMessage.Text = "Adres e-mail jest już zarejestrowany. Przejdź do strony logowania, aby się zalogować";
                }
            }
            else
            {
                ErrorMessage.Text = "Adres e-mail nie pochodzi z domeny student.up.krakow.pl";
            }
        }
        /// <summary>
        /// Metoda odpowiadając za wpisanie nowe użytkownika do tabeli Users.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="groupid"></param>
        /// <remarks>W pierwszym kroku metoda pobiera na podstawie grupy oraz rocznika przedmioty, aby wpisać je następnie wraz z użytkownikiem i hasłem
        /// w odpowiednie pola w tabeli.</remarks>
        private void InsertRecord(string email, string password, string groupid)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                
                SqlCommand cmd1 = new SqlCommand("Select Subject from Subjects where Year = @Year and Groups = @GroupID", connection);
                connection.Open();
                cmd1.Parameters.AddWithValue("@Year", Year.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@GroupID", groupid);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                String s1 = dt.Rows[0][0].ToString();
                String s2 = dt.Rows[1][0].ToString();
                String s3 = dt.Rows[2][0].ToString();

                string sql = "INSERT INTO Users(Username,Password,Year,GroupID,Subject1,Subject2,Subject3) VALUES (@Email,@Pass,@Year,@GroupID,@Subject1,@Subject2,@Subject3)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    //zapisanie loginu i zaszyfrowanego hasla w bazie
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Pass", Encrypt(password));
                    cmd.Parameters.AddWithValue("@Year", Year.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@GroupID", groupid);
                    cmd.Parameters.AddWithValue("@Subject1", s1);
                    cmd.Parameters.AddWithValue("@Subject2", s2);
                    cmd.Parameters.AddWithValue("@Subject3", s3);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Metoda służąca szyfrowaniu hasła
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>Zaszyfrowany ciąg znaków</returns>
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
        /// Metoda sprawdzająca, czy hasło jest odpowiednio silne.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Wartość logiczną</returns>
        /// <remarks>Sprawdza w kolejności: czy hasło ma przynajmniej 8 znaków czy hasło zawiera min. 1 dużą literę, czy zawiera min. 1 cyfrę oraz 
        /// min. 1 znak specjalny</remarks>
        private Boolean ValidatePassword(string password)
        {
            if (password.Length>=8){
                if (password.Any(char.IsUpper))
                {
                    if (password.Any(char.IsDigit))
                    {
                        if (password.Any(p => !char.IsLetterOrDigit(p))){
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy podany mail istnieje już w bazie.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Wartość logiczną</returns>
        private Boolean EmailCheck(string email)
        {
            Boolean check = true;
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
                    check = false;
                }
            }
            return check;
        }
        /// <summary>
        /// Metoda odczytująca nazwę użytkownika z ciasteczka.
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
    }
}