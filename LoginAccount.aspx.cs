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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = ReadCookie();
            if (user != "1")
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
            String email = EmailTxt.Text.Trim();
            String pass = PasswordTxt.Text.Trim();
            String domain = email.Substring(email.IndexOf("@") + 1);
            email = email.Remove(email.IndexOf("@"));//, domain.Length + 1);
            if (EmailCheck(email))
            {
                if (PassCheck(email, Encrypt(pass)))
                {
                    Response.Write("<script language='javascript'>window.alert('Logowanie udało się :) Wróć na stronę główną');window.location='Default.aspx';</script>");
                    SetCookie(email);
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
            //EmailLabel.Visible = false;
            //EmailTxt.Visible = false;
            //PasswordLabel.Visible = false;
            //PasswordTxt.Visible = false;
            }


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

        private void SetCookie(String username)
        {

            //var (publicKey, privateKey) = GenerateKeys(2048);

            //var encryptedData = Encrypt(data, publicKey);
            //var decryptedData = Decrypt(encryptedData, privateKey);
            //var rsa = RSA.Create();
            //var privateKey = rsa.ToXmlString(true);
            //var publicKey = rsa.ExportParameters(false);
            //var publicKey = rsa.ToXmlString(false);
            //StringWriter sw = new StringWriter();
            //XmlTextWriter xw = new XmlTextWriter(sw);
            //privateKey.WriteTo(xw);
            //string xml = sw.ToString();
            username = username.Trim();
            username = username.Replace(".", "+");
            //username = username.Replace(" ", "+");
            username += "+end";
            int mod4 = username.Length % 4;
            if (mod4 > 0)
            {
                username += new string('=', 4 - mod4);
            }

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            var privatekey = rsa.ToXmlString(true);

            String user = ReadCookie();
            if (user == "1")
            {
                HttpCookie userInfo = new HttpCookie("userInfo");
                byte[] data = Convert.FromBase64String(username);
                //userInfo["UserName"] = Encoding.Unicode.GetString(rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256));
                //userInfo["PrivateKey"] = privateKey;
                //userInfo.Expires = DateTime.MinValue;
                userInfo["UserName"] = Convert.ToBase64String(rsa.Encrypt(data, true));
                userInfo["PrivateKey"] = privatekey;
                Response.Cookies.Add(userInfo);
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

        /*static void Main(string[] args)
        {
            var data = new byte[] { 1, 2, 3 };
            var (publicKey, privateKey) = GenerateKeys(2048);

            var encryptedData = Encrypt(data, publicKey);
            var decryptedData = Decrypt(encryptedData, privateKey);
        }
        
        static (RSAParameters publicKey, RSAParameters privateKey) GenerateKeys(int keyLength)
        {
            using (var rsa = RSA.Create())
            {
                rsa.KeySize = keyLength;
                return (
                    publicKey: rsa.ExportParameters(includePrivateParameters: false),
                    privateKey: rsa.ExportParameters(includePrivateParameters: true)
                );
            }
        }

        static byte[] Encrypt(byte[] data, RSAParameters publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);

                var result = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
                return result;
            }
        }

        static byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }

        byte[] GetBytesFromPEM(string pemString, string section)
        {
            var header = String.Format("-----BEGIN {0}-----", section);
            var footer = String.Format("-----END {0}-----", section);

            var start = pemString.IndexOf(header, StringComparison.Ordinal);
            if (start < 0)
                return null;

            start += header.Length;
            var end = pemString.IndexOf(footer, start, StringComparison.Ordinal) - start;

            if (end < 0)
                return null;

            return Convert.FromBase64String(pemString.Substring(start, end));
        }*/
    }
}