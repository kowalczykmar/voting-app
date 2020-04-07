﻿using System;
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterClick(object sender, EventArgs e)
        {
            //walidacja email i hasla
            String email = EmailTxt.Text.Trim();
            String pass = PasswordTxt.Text.Trim();
            String passconf = ConfirmPasswordTxt.Text.Trim();
            String domain = email.Substring(email.IndexOf("@") + 1);
            if(domain == "student.up.krakow.pl")
            {
                //walidacja czy mail juz istnieje w bazie
                if(pass == passconf)
                {
                    ErrorMessage.Visible = false;
                    InsertRecord(EmailTxt.Text.Trim(), PasswordTxt.Text.Trim());
                    EmailLabel.Visible = false;
                    EmailTxt.Visible = false;
                    PasswordLabel.Visible = false;
                    PasswordTxt.Visible = false;
                    ConfirmPasswordLabel.Visible = false;
                    ConfirmPasswordTxt.Visible = false;
                    RegisterButton.Visible = false;
                    SuccesLabel.Visible = true;

                }
                else
                {
                    ErrorMessage.Text = "Powtórzone hasło jest nieprawidłowe";
                }
            }
            else
            {
                ErrorMessage.Text = "Adres e-mail nie pochodzi z domeny student.up.krakow.pl";
            }
            //InsertRecord(EmailTxt.Text.Trim(), PasswordTxt.Text.Trim());

        }

        private void InsertRecord(string email, string password)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                string sql = "INSERT INTO Users(Username,Password) VALUES (@Email,@Pass)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    //zapisanie zaszyfrowanych emailu i hasla w bazie
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Email", Encrypt(email));
                    cmd.Parameters.AddWithValue("@Pass", Encrypt(password));
                    cmd.ExecuteNonQuery();
                }
            }
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

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}