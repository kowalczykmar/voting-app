using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VotingApp
{
    /// <summary>
    /// Klasa strony głównej Panelu dla prowadzących
    /// </summary>
    public partial class TeacherDefault : System.Web.UI.Page
    {
        /// <summary>
        /// Metoda wywoływana przy załadowaniu strony głównej panelu dla prowadzących.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Jeśli żaden prowadzący nie jest zalogowany, przekierowuje na stronę logowania dla prowadzących. Jeśli jest, odczytuje odpowiednie
        /// nazwy przedmiotów z zmiennych sesyjnych i przypisuje je do nagłówków nad tabelami. Wywołuje odpowiednie metody GetData celem wypełnienia
        /// tabel z opiniami o przedmiotach</remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["TeacherLoggedIn"] == null)
            {
                Response.Redirect("TeacherLogin.aspx");
            }
            Header1.InnerHtml = "Opinie o przedmiocie: " + Session["TeacherSubject1"].ToString() + " - grupa L1";
            Header2.InnerHtml = "Opinie o przedmiocie: " + Session["TeacherSubject2"].ToString() + " - grupa L2";
            Header3.InnerHtml = "Opinie o przedmiocie: " + Session["TeacherSubject3"].ToString() + " - grupa L3";
            GetData(1);
            GetData(2);
            GetData(3);
        }
        /// <summary>
        /// Metoda zaciągająca dane z tabel z opiniami oraz użytkownikami, którzy przesłali opinie i wypełnia nimi tabele na stronie.
        /// </summary>
        /// <param name="groupnr"></param>
        /// <remarks>
        /// <para>W zależności od przekazanego numer grupy przypisuje do wewnętrznej zmiennej odpowiednią nazwę grupy oraz wypełnia odpowiednie tabele na stronie.</para>
        /// <para>W pierwszym kroku metoda zaciąga słowne opinie o przemdiocie i odszyfrowuje je oraz usuwa ostatni wiersz, jeśli ilość wierszy jest nieparzysta.</para>
        /// <para>W następnym kroku pobiera dane o użytkownikach, którzy wysłali opinię do odpowiedniego przedmiotu.</para>
        /// <para>Następnie pobiera dane o zaznaczonych opcjach wyboru wielokrotnego (ucinając ostatni nieparzysty wiersz), odszyfrowuje a następnie odczytuje 
        /// zapisane indeksy opinii oraz przypisuje ilości zaznaczonych opcji do pomocniczej tabeli</para>
        /// <para>Następnie pobiera dane o zaznaczonych opcjach wyboru jednokrotnego (ucinając ostatni nieparzysty wiersz), odszyfrowuje a następnie odczytuje 
        /// zapisane indeksy opinii oraz przypisuje ilości zaznaczonych opcji do pomocniczej tabeli, a także wylicza średnią ocen</para>
        /// <para>W ostatnim kroku przypisuje odpowiednie tabele do tabeli wyświetlanych na stronie celem zaprezentowania odpowiednich danych</para>
        /// </remarks>
        protected void GetData(int groupnr)
        {
            String group = "";
            if (groupnr == 1)
            {
                group = "L1";
            }
            else if (groupnr == 2)
            {
                group = "L2";
            }
            else if (groupnr == 3)
            {
                group = "L3";
            }
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select OpinionContent from Opinions where GroupID = @GroupID and Teacher = @Teacher", con);
            cmd.Parameters.AddWithValue("@GroupID", group);
            cmd.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            con.Open();
            //tabela z opiniami slownymi
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            
            foreach (DataRow row in ds.Rows)
            {
                String encodedOpinion = row["OpinionContent"].ToString();
                String decodedOpinion = Decrypt(encodedOpinion);
                row["OpinionContent"] = decodedOpinion;
            }
            //usuwa ostatni wiersz, jeśli ilość opinii jest nieparzysta, aby go nie wyświetlać
            int row_nr = ds.Rows.Count;
            if (row_nr % 2 != 0)
            {
                ds.Rows[row_nr - 1].Delete();
            }
            //tabela z uzytkownikami, ktorzy przeslali opinie
            SqlCommand cmd4 = new SqlCommand("Select Username from UsersWithOpinionSend where GroupID = @GroupID and Teacher = @Teacher", con);
            cmd4.Parameters.AddWithValue("@GroupID", group);
            cmd4.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            sda4.Fill(ds4);
            //tabela z polem wielokroetnego wyboru
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            int index4 = 0;
            int helper1 = 0;
            int helper2 = 0;
            int helper3 = 0;
            int helper4 = 0;
            SqlCommand cmd2 = new SqlCommand("Select OpinionIndexes from Opinions where GroupID = @GroupID and Teacher = @Teacher", con);
            cmd2.Parameters.AddWithValue("@GroupID", group);
            cmd2.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            DataTable table1 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(table1);
            //usuwa ostatni wiersz, jeśli ilość opinii jest nieparzysta, aby go nie wyświetlać
            int row_nr2 = table1.Rows.Count;
            if (row_nr2 % 2 != 0)
            {
                table1.Rows[row_nr2 - 1].Delete();
            }
            for (int i = 0; i < table1.Rows.Count-1; i++)
            {
                DataRow row = table1.Rows[i];
                String indexes = Decrypt(row["OpinionIndexes"].ToString());
                helper1 = 0;
                helper2 = 0;
                helper3 = 0;
                helper4 = 0;
                if (indexes.Length > 1 && indexes.Length <= 2)
                {
                    string helper = indexes;

                    helper1 = Convert.ToInt32(helper[0].ToString());
                    helper2 = Convert.ToInt32(helper[1].ToString());
                }
                else if (indexes.Length > 2 && indexes.Length <= 3)
                {
                    string helper = indexes.ToString();
                    helper1 = Convert.ToInt32(helper[0].ToString());
                    helper2 = Convert.ToInt32(helper[1].ToString());
                    helper3 = Convert.ToInt32(helper[2].ToString());
                }
                else if (indexes.Length > 3)
                {
                    string helper = indexes.ToString();
                    helper1 = Convert.ToInt32(helper[0].ToString());
                    helper2 = Convert.ToInt32(helper[1].ToString());
                    helper3 = Convert.ToInt32(helper[2].ToString());
                    helper4 = Convert.ToInt32(helper[3].ToString());
                }
                else
                {
                    helper1 = Convert.ToInt32(indexes.ToString());
                }
                if (helper1 != 0)
                {
                    if (helper1 == 1)
                    {
                        index1++;
                    }
                    else if (helper1 == 2)
                    {
                        index2++;
                    }
                    else if (helper1 == 3)
                    {
                        index3++;
                    }
                    else if (helper1 == 4)
                    {
                        index4++;
                    }
                }
                if (helper2 != 0)
                {
                    if (helper2 == 1)
                    {
                        index1++;
                    }
                    else if (helper2 == 2)
                    {
                        index2++;
                    }
                    else if (helper2 == 3)
                    {
                        index3++;
                    }
                    else if (helper2 == 4)
                    {
                        index4++;
                    }
                }
                if (helper3 != 0)
                {
                    if (helper3 == 1)
                    {
                        index1++;
                    }
                    else if (helper3 == 2)
                    {
                        index2++;
                    }
                    else if (helper3 == 3)
                    {
                        index3++;
                    }
                    else if (helper3 == 4)
                    {
                        index4++;
                    }
                }
                if (helper4 != 0)
                {
                    if (helper4 == 1)
                    {
                        index1++;
                    }
                    else if (helper4 == 2)
                    {
                        index2++;
                    }
                    else if (helper4 == 3)
                    {
                        index3++;
                    }
                    else if (helper4 == 4)
                    {
                        index4++;
                    }
                }
            }
            DataTable table_final = new DataTable();
            table_final.Clear();
            table_final.Columns.Add("Ocena");
            table_final.Columns.Add("Number");
            DataRow _index1 = table_final.NewRow();
            _index1["Ocena"] = "Zajęcia były bardziej wymagające od pozostałych zajęć w tym semestrze";
            _index1["Number"] = index1;
            table_final.Rows.Add(_index1);
            DataRow _index2 = table_final.NewRow();
            _index2["Ocena"] = "Zajęcia dużo mnie nauczyły";
            _index2["Number"] = index2;
            table_final.Rows.Add(_index2);
            DataRow _index3 = table_final.NewRow();
            _index3["Ocena"] = "Zajęcia poszerzyły moją wiedzę z tej dziedziny";
            _index3["Number"] = index3;
            table_final.Rows.Add(_index3);
            DataRow _index4 = table_final.NewRow();
            _index4["Ocena"] = "Chciałabym/chciałbym uczetsniczyć w kontynuacji zajęć, aby pogłębiać swoją wiedzę w tej dziedzinie";
            _index4["Number"] = index4;
            table_final.Rows.Add(_index4);
            //tabela z ocenami liczbowymi
            int nr1 = 0;
            int nr2 = 0;
            int nr3 = 0;
            int nr4 = 0;
            int nr5 = 0;
            double suma = 0;
            double cnt = 0;
            SqlCommand cmd3 = new SqlCommand("Select OpinionNumber from Opinions where GroupID = @GroupID and Teacher = @Teacher", con);
            cmd3.Parameters.AddWithValue("@GroupID", group);
            cmd3.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            DataTable table2 = new DataTable();
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            sda3.Fill(table2);
            //usuwa ostatni wiersz, jeśli ilość opinii jest nieparzysta, aby go nie wyświetlać
            int row_nr3 = table2.Rows.Count;
            if (row_nr3 % 2 != 0)
            {
                table2.Rows[row_nr3-1].Delete();
            }
            for (int i = 0; i < table2.Rows.Count - 1; i++)
            {
                DataRow row = table2.Rows[i];
                
                int helperNr = Convert.ToInt32(Decrypt(row["OpinionNumber"].ToString()));
                if (helperNr == 5)
                {
                    nr5++;
                    cnt++;
                    suma = suma + helperNr;
                }
                else if (helperNr == 4)
                {
                    nr4++;
                    cnt++;
                    suma = suma + helperNr;
                }
                else if (helperNr == 3)
                {
                    nr3++;
                    cnt++;
                    suma = suma + helperNr;
                }
                else if (helperNr == 2)
                {
                    nr2++;
                    cnt++;
                    suma = suma + helperNr;
                }
                else if (helperNr == 1)
                {
                    nr1++;
                    cnt++;
                    suma = suma + helperNr;
                }
            }
            double average = suma / cnt;
            DataTable table_final2 = new DataTable();
            table_final2.Clear();
            table_final2.Columns.Add("Ocena");
            table_final2.Columns.Add("Number");
            DataRow _nr5 = table_final2.NewRow();
            _nr5["Ocena"] = 5;
            _nr5["Number"] = nr5;
            table_final2.Rows.Add(_nr5);
            DataRow _nr4 = table_final2.NewRow();
            _nr4["Ocena"] = 4;
            _nr4["Number"] = nr4;
            table_final2.Rows.Add(_nr4);
            DataRow _nr3 = table_final2.NewRow();
            _nr3["Ocena"] = 3;
            _nr3["Number"] = nr3;
            table_final2.Rows.Add(_nr3);
            DataRow _nr2 = table_final2.NewRow();
            _nr2["Ocena"] = 2;
            _nr2["Number"] = nr2;
            table_final2.Rows.Add(_nr2);
            DataRow _nr1 = table_final2.NewRow();
            _nr1["Ocena"] = 1;
            _nr1["Number"] = nr1;
            table_final2.Rows.Add(_nr1);
            if (groupnr == 1)
            {
                Opinions1.DataSource = ds;
                Opinions1.DataBind();
                OpinionIndexes1.DataSource = table_final;
                OpinionIndexes1.DataBind();
                OpinionNumbers1.DataSource = table_final2;
                OpinionNumbers1.DataBind();
                Average1.Text = Average1.Text + String.Format("{0:0.00}", average);
                UsersWithOpinionSend1.DataSource = ds4;
                UsersWithOpinionSend1.DataBind();
            }
            else if (groupnr == 2)
            {
                Opinions2.DataSource = ds;
                Opinions2.DataBind();
                OpinionIndexes2.DataSource = table_final;
                OpinionIndexes2.DataBind();
                OpinionNumbers2.DataSource = table_final2;
                OpinionNumbers2.DataBind();
                Average2.Text = Average2.Text + String.Format("{0:0.00}", average);
                UsersWithOpinionSend2.DataSource = ds4;
                UsersWithOpinionSend2.DataBind();
            }
            else if (groupnr == 3)
            {
                Opinions3.DataSource = ds;
                Opinions3.DataBind();
                OpinionIndexes3.DataSource = table_final;
                OpinionIndexes3.DataBind();
                OpinionNumbers3.DataSource = table_final2;
                OpinionNumbers3.DataBind();
                Average3.Text = Average3.Text + String.Format("{0:0.00}", average);
                UsersWithOpinionSend3.DataSource = ds4;
                UsersWithOpinionSend3.DataBind();
            }
        }
        /// <summary>
        /// Metoda odszyfrowująca opinie.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>Odszyfrowaną treść opinii słownej</returns>
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = File.ReadAllText(@"C:\Users\Jan Kremer\source\repos\test\test.txt");
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