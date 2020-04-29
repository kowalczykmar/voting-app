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
                    Opinion.Visible = true;
                    NotLoggedIn.Visible = false;
                    SubmitButton.Visible = true;
                }
                else
                {
                    NotLoggedIn.Text = "Opinia została już przesłana. Dziękujemy";
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

        protected void SubmitClick(object sender, EventArgs e)
        {
            string opinion = Opinion.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion);
            Opinion.Visible = false;
            NotLoggedIn.Text = "Dziękujemy za przesłanie opinii";
            NotLoggedIn.Visible = true;
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
 