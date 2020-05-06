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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user != "1")
            {
                if (!UserOpinionCheck())
                {
                    Opinion1.Visible = true;
                    NotLoggedIn1.Visible = false;
                    SubmitButton1.Visible = true;
                    Opinion2.Visible = true;
                    NotLoggedIn2.Visible = false;
                    SubmitButton2.Visible = true;
                    Opinion3.Visible = true;
                    NotLoggedIn3.Visible = false;
                    SubmitButton3.Visible = true;
                }
                else
                {
                    NotLoggedIn1.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code1.Visible = true;
                    CheckOpinionBtn1.Visible = true;
                    NotLoggedIn2.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code2.Visible = true;
                    CheckOpinionBtn2.Visible = true;
                    NotLoggedIn3.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code3.Visible = true;
                    CheckOpinionBtn3.Visible = true;
                }
            }
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

        private String ReadUser()
        {
            var User_key = "1";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                //String User_name = reqCookies["UserName"].ToString();
                byte[] User_name = Convert.FromBase64String(reqCookies["UserName"]);
                User_key = reqCookies["PrivateKey"];
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(User_key);
                //byte[] user = rsa.Decrypt(Encoding.Unicode.GetBytes(User_name), RSAEncryptionPadding.OaepSHA256);
                //User_key = Encoding.Unicode.GetString(user);
                //var rsa = RSA.Create();
                //rsa.FromXmlString(User_key);
                //byte[] user = rsa.Decrypt(Convert.FromBase64String(User_name), true);
                byte[] user = rsa.Decrypt(User_name, true);
                User_key = Convert.ToBase64String(user);
                User_key = User_key.ToString();
                User_key = User_key.Replace("+", ".");
                User_key = User_key.Remove(User_key.IndexOf(".en"));
            }
            return User_key;
        }

        protected void Submit1Click(object sender, EventArgs e)
        {
            string opinion = Opinion1.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion);
            Opinion1.Visible = false;
            NotLoggedIn1.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn1.Visible = true;
            SubmitButton1.Visible = false;
        }

        protected void Submit2Click(object sender, EventArgs e)
        {
            string opinion = Opinion2.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion);
            Opinion2.Visible = false;
            NotLoggedIn2.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn2.Visible = true;
            SubmitButton2.Visible = false;
        }

        protected void Submit3Click(object sender, EventArgs e)
        {
            string opinion = Opinion3.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion);
            Opinion3.Visible = false;
            NotLoggedIn3.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn3.Visible = true;
            SubmitButton3.Visible = false;
        }

        protected void CheckClick1(object sender, EventArgs e)
        {
            string code = Code1.Text.Trim();
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select OpinionContent from Opinions", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (code == OpinionCode(dr.GetString(0)))
                {
                    NotLoggedIn1.Text = "Opinia jest poprawnie zapisana.";
                    Code1.Visible = false;
                    CheckOpinionBtn1.Visible = false;
                    break;
                }
                else
                {
                    NotLoggedIn1.Text = "Brak opinii o takim kodzie. Spróbuj ponownie wpisać kod lub skontaktuj się z administratorem.";
                }
            }
        }

        protected void CheckClick2(object sender, EventArgs e)
        {
            string code = Code2.Text.Trim();
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select OpinionContent from Opinions", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (code == OpinionCode(dr.GetString(0)))
                {
                    NotLoggedIn2.Text = "Opinia jest poprawnie zapisana.";
                    Code2.Visible = false;
                    CheckOpinionBtn2.Visible = false;
                    break;
                }
                else
                {
                    NotLoggedIn2.Text = "Brak opinii o takim kodzie. Spróbuj ponownie wpisać kod lub skontaktuj się z administratorem.";
                }
            }
        }

        protected void CheckClick3(object sender, EventArgs e)
        {
            string code = Code3.Text.Trim();
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select OpinionContent from Opinions", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (code == OpinionCode(dr.GetString(0)))
                {
                    NotLoggedIn3.Text = "Opinia jest poprawnie zapisana.";
                    Code3.Visible = false;
                    CheckOpinionBtn3.Visible = false;
                    break;
                }
                else
                {
                    NotLoggedIn3.Text = "Brak opinii o takim kodzie. Spróbuj ponownie wpisać kod lub skontaktuj się z administratorem.";
                }
            }
        }

        private void InsertOpinion(string opinion)
        {
            //string user = ReadUser();
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                string sql = "UPDATE Users SET IsOpinionSend = 1 WHERE [Username] = @Email";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Email", ReadUser());
                    cmd.ExecuteNonQuery();
                }

                sql = "INSERT INTO Opinions(OpinionContent) VALUES (@Opinion)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    //connection.Open();
                    cmd.Parameters.AddWithValue("@Opinion", opinion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Boolean UserOpinionCheck()
        {
            //Boolean check = false;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select IsOpinionSend from Users where Username = @Email", con);
            cmd.Parameters.AddWithValue("@Email", ReadUser());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Boolean check = dr.GetBoolean(0);
            return check;
        }

        private String OpinionCode(String opinion)
        {
            String code = "";
            int count;
            String user = ReadUser();
            for(int i = 0; i < user.Length; i++)
            {
                count = opinion.Count(x => x == user[i]);
                code = code + count.ToString();
            }
            return code;
        }

        /*
        static byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }
        */
    }
}
 