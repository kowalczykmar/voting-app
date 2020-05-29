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
    /// Strona główna aplikacji - służy do przesyłania opinii.
    /// </summary>
    public partial class _Default : Page
    {
        /// <summary>
        /// Przy wywołaniu strony Default sprawdzamy, czy użytkownik jest zalogowany i w zależności od tego wyświetlamy funkcjonalności, bądź nie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Jeśli zalogowany jest prowadzący, strona przekierowuje na stronę główną panelu dla prowadzących</para>
        /// <para>Jeśli użytkownik nie jest zalogowany (rozponanie następuje po zczytaniu nazwy użytkownika z ciasteczka oraz zmiennej sesyjnej), 
        /// nie są wyświetlane żadne pola do przesyłania opinii, jedynie komentarz, aby się zalogował. Jeśli jest zalogowany, dostępne są pola 
        /// do przesyłania opinii (komentarz słowny, pola jednokrotnego oraz wielokrotnego wyboru). Wyświetlane są jedynie te, dla których nie została 
        /// przesłana jeszcze opinia. Jeśli opinia dla któregoś przedmiotu została już przesłana, wyświetlane jest jedynie pole do wpisania 
        /// unikalnego kodu umożliwiającego sprawdzenie, czy opinia jest poprawnie zapisana w bazie.</para>
        /// <para>korzysta z metod ReadCookie, GetSubjects, UserOpinionCheck</para>
        /// </remarks>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherLoggedIn"] != null)
            {
                Response.Redirect("TeacherDefault.aspx");
            }
            String user = ReadCookie();
            if (user != "1" && Session["LoggedIn"] != null)
            {
                GetSubjects();
                if (!UserOpinionCheck(1))
                {
                    Subject1.Text = "Przedmiot: " + Session["Subject1"];
                    Subject1.Visible = true;
                    Teacher1.Text = "Prowadzący: " + Session["Teacher1"];
                    Teacher1.Visible = true;
                    Opinion1.Visible = true;
                    NotLoggedIn1.Visible = false;
                    RadioButtonText1.Visible = true;
                    RadioButtonList1.Visible = true;
                    CheckboxText1.Visible = true;
                    CheckboxList1.Visible = true;
                    SubmitButton1.Visible = true;
                }
                else
                {
                    NotLoggedIn1.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code1.Visible = true;
                    CheckOpinionBtn1.Visible = true;
                    RequiredFieldValidator1.Enabled = false;
                    OpinionValidator1.Enabled = false;
                }
                if (!UserOpinionCheck(2))
                {
                    Subject2.Text = "Przedmiot: " + Session["Subject2"];
                    Subject2.Visible = true;
                    Teacher2.Text = "Prowadzący: " + Session["Teacher2"];
                    Teacher2.Visible = true;
                    RadioButtonText2.Visible = true;
                    RadioButtonList2.Visible = true;
                    CheckboxText2.Visible = true;
                    CheckboxList2.Visible = true;
                    Opinion2.Visible = true;
                    NotLoggedIn2.Visible = false;
                    SubmitButton2.Visible = true;
                }
                else
                {
                    NotLoggedIn2.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code2.Visible = true;
                    CheckOpinionBtn2.Visible = true;
                    RequiredFieldValidator2.Enabled = false;
                    OpinionValidator2.Enabled = false;
                }
                if (!UserOpinionCheck(3))
                {
                    Subject3.Text = "Przedmiot: " + Session["Subject3"];
                    Subject3.Visible = true;
                    Teacher3.Text = "Prowadzący: " + Session["Teacher3"];
                    Teacher3.Visible = true;
                    RadioButtonText3.Visible = true;
                    RadioButtonList3.Visible = true;
                    CheckboxText3.Visible = true;
                    CheckboxList3.Visible = true;
                    Opinion3.Visible = true;
                    NotLoggedIn3.Visible = false;
                    SubmitButton3.Visible = true;
                }
                else
                {
                    NotLoggedIn3.Text = "Opinia została już przesłana. Dziękujemy! Wpisz poniżej swój kod, aby sprawdzić, czy opinia została prawidłowo zapisana.";
                    Code3.Visible = true;
                    CheckOpinionBtn3.Visible = true;
                    RequiredFieldValidator3.Enabled = false;
                    OpinionValidator3.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Funkcja służy odczytywaniu informacji z ciasteczka po stronie użytkownika
        /// </summary>
        /// <returns>Nazwę użytkownika</returns>
        /// <remarks>
        /// Zwraca 1, jeśli ciasteczko nie istnieje lub jeśli użytkownik nie jest zalogowany, lub zaszyfrowaną nazwę użytkownika, jeśli jest zalogowany.
        /// </remarks>
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
        /// Funkcja do odczytywania zaszyfrowanej nazwy użytkownika
        /// </summary>
        /// <returns>Odszyfrowaną nazwę użytkownika</returns>
        /// <remarks>Jeśli ciasteczko nie istnieje, zwraca 1. Używa do odszyfrowania klucza prywatnego zapisanego w ciasteczku oraz algorytmu RSA</remarks>
        private String ReadUser()
        {
            var User_key = "1";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                byte[] User_name = Convert.FromBase64String(reqCookies["UserName"]);
                User_key = reqCookies["PrivateKey"];
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(User_key);
                byte[] user = rsa.Decrypt(User_name, true);
                User_key = Convert.ToBase64String(user);
                User_key = User_key.ToString();
                User_key = User_key.Replace("+", ".");
                User_key = User_key.Remove(User_key.IndexOf(".en"));
            }
            return User_key;
        }

        /// <summary>
        /// Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu pierwszego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.</para>
        /// <para>Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem 
        /// unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.</para>
        /// <para>Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.</para>
        /// </remarks>
        protected void Submit1Click(object sender, EventArgs e)
        {
            string opinion = Opinion1.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion, 1);
            Opinion1.Visible = false;
            NotLoggedIn1.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn1.Visible = true;
            RadioButtonText1.Visible = false;
            RadioButtonList1.Visible = false;
            CheckboxText1.Visible = false;
            CheckboxList1.Visible = false;
            SubmitButton1.Visible = false;
            RequiredFieldValidator1.Enabled = false;
            OpinionValidator1.Enabled = false;
            ShuffleOpinionsTable();
            ShuffleUsersWithOpinionsTable();
        }

        /// <summary>
        /// Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu drugiego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.</para>
        /// <para>Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem 
        /// unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.</para>
        /// <para>Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.</para>
        /// </remarks>
        protected void Submit2Click(object sender, EventArgs e)
        {
            string opinion = Opinion2.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion, 2);
            Opinion2.Visible = false;
            NotLoggedIn2.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn2.Visible = true;
            RadioButtonText2.Visible = false;
            RadioButtonList2.Visible = false;
            CheckboxText2.Visible = false;
            CheckboxList2.Visible = false;
            SubmitButton2.Visible = false;
            RequiredFieldValidator2.Enabled = false;
            OpinionValidator2.Enabled = false;
            ShuffleOpinionsTable();
            ShuffleUsersWithOpinionsTable();
        }

        /// <summary>
        /// Wywołanie akcji w wyniku kliknięcia przyscisku przesłania opinii przedmiotu trzeciego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Wywołuje metodę InsertOpinion w celu wprowadzenia opinii do bazy.</para>
        /// <para>Odpowiada za zniknięcie ze strony pól do przesyłania opinii oraz wyświetlenie pól z tekstem podziękowania oraz wyświetleniem 
        /// unikalnego kodu do sprawdzenia czy opinia została poprawnie zapisana w bazie jak i wyświetlenie pola do wpisania kodu.</para>
        /// <para>Wywołuje metody odpowiedzialne za przemiszanie tabel po dodaniu opinii.</para>
        /// </remarks>
        protected void Submit3Click(object sender, EventArgs e)
        {
            string opinion = Opinion3.Text;
            opinion = opinion.Trim();
            InsertOpinion(opinion, 3);
            Opinion3.Visible = false;
            NotLoggedIn3.Text = "Dziękujemy za przesłanie opinii. Twój unikalny kod do sprawdzenia, czy opinia została poprawnie przesłana: " + OpinionCode(opinion);
            NotLoggedIn3.Visible = true;
            RadioButtonText3.Visible = false;
            RadioButtonList3.Visible = false;
            CheckboxText3.Visible = false;
            CheckboxList3.Visible = false;
            SubmitButton3.Visible = false;
            RequiredFieldValidator3.Enabled = false;
            OpinionValidator3.Enabled = false;
            ShuffleOpinionsTable();
            ShuffleUsersWithOpinionsTable();
        }

        /// <summary>
        /// Przycisk do sprawdzenia czy opinia do przedmiotu pierwszego została poprawnie zapisana w bazie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.</para>
        /// <para>W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.</para>
        /// </remarks>
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
                if (code == OpinionCode(Decrypt(dr.GetString(0))))
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

        /// <summary>
        /// Przycisk do sprawdzenia czy opinia do przedmiotu drugiego została poprawnie zapisana w bazie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.</para>
        /// <para>W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.</para>
        /// </remarks>
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

        /// <summary>
        /// Przycisk do sprawdzenia czy opinia do przedmiotu trzeciego została poprawnie zapisana w bazie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <para>Pobiera unikalny kod i sprawdza kody tworzone dla wszystkich opinii zapisanych w bazie.</para>
        /// <para>W przypadku sukcesu pola do wpisywania kodu oraz przycisk nie są dłużej wyświetlane na stronie.</para>
        /// </remarks>
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

        /// <summary>
        /// Metoda służąca wprowadzaniu opinii do bazy
        /// </summary>
        /// <param name="opinion"></param>
        /// <param name="nr"></param>
        /// <remarks>
        /// <para>Metoda ta pobiera tekst opinii oraz numer nr, czyli informację, do którego przedmiotu opinia ta się odnosi</para>
        /// <para>Metoda zapisuje w tabeli z opiniami koemntarz słowny oraz zaznaczone opcje jednokrotnego i wielokrotnego wyboru w formie zaszyfrowanej wraz z 
        /// informacją o roku, grupie, przedmiocie i prowadzącym zajęcia.</para>
        /// <para>Metoda ta również zapisuje w tabeli użytkowników, którzy przesłali opinię nazwę użytkownika wraz z rokiem, grupą oraz przedmiotem 
        /// i prowadzącym, którego opinia się tyczy.</para>
        /// <para>Metoda ta korzysta z metod ReadUser oraz GetIndexesforOpinion</para>
        /// </remarks>
        private void InsertOpinion(string opinion, int nr)
        {
            String encodedOpinion = Encrypt(opinion);

            if (nr == 1)
            {
                string dbConnectionString2 = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(dbConnectionString2))
                {
                    string sql = "INSERT INTO Opinions(OpinionContent, OpinionNumber, OpinionIndexes, Year, GroupID, Subject, Teacher) VALUES (@Opinion, @OpNr, @OpIndex, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Opinion", encodedOpinion);
                        cmd.Parameters.AddWithValue("@OpNr", Encrypt(RadioButtonList1.SelectedValue));
                        cmd.Parameters.AddWithValue("@OpIndex", Encrypt(GetIndexesforOpinion(1)));
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject1"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher1"]);
                        cmd.ExecuteNonQuery();
                    }

                    sql = "INSERT INTO UsersWithOpinionSend(Username, Year, GroupID, Subject, Teacher) VALUES (@User, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@User", ReadUser());
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject1"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher1"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else if (nr == 2)
            {
                string dbConnectionString2 = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(dbConnectionString2))
                {
                    string sql = "INSERT INTO Opinions(OpinionContent, OpinionNumber, OpinionIndexes, Year, GroupID, Subject, Teacher) VALUES (@Opinion, @OpNr, @OpIndex, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Opinion", encodedOpinion);
                        cmd.Parameters.AddWithValue("@OpNr", Encrypt(RadioButtonList2.SelectedValue));
                        cmd.Parameters.AddWithValue("@OpIndex", Encrypt(GetIndexesforOpinion(2)));
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject2"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher2"]);
                        cmd.ExecuteNonQuery();
                    }

                    sql = "INSERT INTO UsersWithOpinionSend(Username, Year, GroupID, Subject, Teacher) VALUES (@User, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@User", ReadUser());
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject2"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher2"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else if (nr == 3)
            {
                string dbConnectionString2 = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(dbConnectionString2))
                {
                    string sql = "INSERT INTO Opinions(OpinionContent, OpinionNumber, OpinionIndexes, Year, GroupID, Subject, Teacher) VALUES (@Opinion, @OpNr, @OpIndex, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@Opinion", encodedOpinion);
                        cmd.Parameters.AddWithValue("@OpNr", Encrypt(RadioButtonList3.SelectedValue));
                        cmd.Parameters.AddWithValue("@OpIndex", Encrypt(GetIndexesforOpinion(3)));
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject3"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher3"]);
                        cmd.ExecuteNonQuery();
                    }

                    sql = "INSERT INTO UsersWithOpinionSend(Username, Year, GroupID, Subject, Teacher) VALUES (@User, @Year, @GroupID, @Subject, @Teacher)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@User", ReadUser());
                        cmd.Parameters.AddWithValue("@Year", Session["Year"]);
                        cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
                        cmd.Parameters.AddWithValue("@Subject", Session["Subject3"]);
                        cmd.Parameters.AddWithValue("@Teacher", Session["Teacher3"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Metoda sprawdzająca, czy dla danego przedmiotu opinia została już przesłana
        /// </summary>
        /// <param name="nr"></param>
        /// <returns>Wartość logiczną</returns>
        /// <remarks>Przekzywany metodzie numer nr decyduje o tym, który przedmiot jest sprawdzany pod kątem przesłania opinii.</remarks>
        private Boolean UserOpinionCheck(int nr)
        {
            Boolean check = false;
            int checkint = -1;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            if (nr == 1)
            {
                SqlCommand cmd = new SqlCommand("Select ID from UsersWithOpinionSend where Username = @Email and Subject = @Subject", con);
                cmd.Parameters.AddWithValue("@Email", ReadUser());
                cmd.Parameters.AddWithValue("@Subject", Session["Subject1"]);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    checkint = dr.GetInt32(0);
                }
                if (checkint > 0)
                {
                    check = true;
                }
            }
            else if (nr == 2)
            {
                SqlCommand cmd = new SqlCommand("Select ID from UsersWithOpinionSend where Username = @Email and Subject = @Subject", con);
                cmd.Parameters.AddWithValue("@Email", ReadUser());
                cmd.Parameters.AddWithValue("@Subject", Session["Subject2"]);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    checkint = dr.GetInt32(0);
                }
                if (checkint > 0)
                {
                    check = true;
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select ID from UsersWithOpinionSend where Username = @Email and Subject = @Subject", con);
                cmd.Parameters.AddWithValue("@Email", ReadUser());
                cmd.Parameters.AddWithValue("@Subject", Session["Subject3"]);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    checkint = dr.GetInt32(0);
                }
                if (checkint > 0)
                {
                    check = true;
                }
            }
            return check;
        }

        /// <summary>
        /// Metoda tworząca unikalny kod na podstawie przesłanej opinii i nazwy użytkownika i hashuje go
        /// </summary>
        /// <param name="opinion"></param>
        /// <returns>Ciąg cyfrowo-znakowy</returns>
        /// <remarks>Kod nie jest nigdzie zapisywany - użytkownik musi go przechować we własnym zakresie, jeśli chce z niego później skorzystać</remarks>
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
            code = ComputeSha256Hash(code);           
            return code;
        }

        /// <summary>
        /// Metoda zczytuje zaznaczone opcje wielokrotnego wyboru
        /// </summary>
        /// <param name="nr"></param>
        /// <returns>Indeksy w formie ciągu znaków</returns>
        /// <remarks>
        /// <para>Jeśli nie została zaznaczona żadna opcja, zwraca pusty ciąg.</para>
        /// <para>Numer nr przekazywany metodzie decyduje o tym, opinie dla którego przedmiotu bierzemy pod uwagę.</para>
        /// </remarks>
        private String GetIndexesforOpinion(int nr)
        {
            String indexes = "";
            if (nr == 1)
            {
                foreach (ListItem item in CheckboxList1.Items)
                {
                    if (item.Selected)
                    {
                        indexes = indexes + (CheckboxList1.Items.IndexOf(item) + 1).ToString();
                    }
                }
            }
            else if (nr == 2)
            {
                foreach (ListItem item in CheckboxList2.Items)
                {
                    if (item.Selected)
                    {
                        indexes = indexes + (CheckboxList2.Items.IndexOf(item) + 1).ToString();
                    }
                }
            }
            else if (nr == 3)
            {
                foreach (ListItem item in CheckboxList3.Items)
                {
                    if (item.Selected)
                    {
                        indexes = indexes + (CheckboxList3.Items.IndexOf(item) + 1).ToString();
                    }
                }
            }
            return indexes;
        }

        /// <summary>
        /// Metoda pobierająca przedmioty z tabeli z użytkownikami i zapisująca je w zmiennych sesyjnych.
        /// </summary>
        private void GetSubjects()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select Subject from Subjects where Year = @Year and Groups = @GroupID", con);
            cmd.Parameters.AddWithValue("@Year", Session["Year"]);
            cmd.Parameters.AddWithValue("@GroupID", Session["GroupID"]);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String s1 = dt.Rows[0][0].ToString();
            String s2 = dt.Rows[1][0].ToString();
            String s3 = dt.Rows[2][0].ToString();

            Session["Subject1"] = s1;
            Session["Subject2"] = s2;
            Session["Subject3"] = s3;
        }

        /// <summary>
        /// Metoda zmieniająca losowo kolejność wpisów w tabeli z przesłanymi opiniami
        /// </summary>
        /// <remarks>Przemieszanie wpisów służy zaciemnianiu obrazu danych przed administratorem oraz prowadzącym.</remarks>
        private void ShuffleOpinionsTable()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Opinions", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            int rows_nr = table.Rows.Count;
            int[] indexes = new int[rows_nr];
            for (int j = 0; j < rows_nr; j++)
            {
                indexes[j] = j;
            }
            Random rnd = new Random();
            indexes = indexes.OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0; i < rows_nr; i++)
            {
                SqlCommand cmd1 = new SqlCommand("Update Opinions SET OpinionContent = @OpCon, OpinionNumber = @OpNr, OpinionIndexes = @OpInd, Year = @Year, GroupID = @GroupID, Subject = @Subject, Teacher = @Teacher WHERE OpinionId = @OpID", con);
                cmd1.Parameters.AddWithValue("@OpCon", table.Rows[indexes[i]]["OpinionContent"].ToString());
                cmd1.Parameters.AddWithValue("@OpNr", table.Rows[indexes[i]]["OpinionNumber"].ToString());
                cmd1.Parameters.AddWithValue("@OpInd", table.Rows[indexes[i]]["OpinionIndexes"].ToString());
                cmd1.Parameters.AddWithValue("@Year", table.Rows[indexes[i]]["Year"].ToString());
                cmd1.Parameters.AddWithValue("@GroupID", table.Rows[indexes[i]]["GroupID"].ToString());
                cmd1.Parameters.AddWithValue("@Subject", table.Rows[indexes[i]]["Subject"].ToString());
                cmd1.Parameters.AddWithValue("@Teacher", table.Rows[indexes[i]]["Teacher"].ToString());
                cmd1.Parameters.AddWithValue("@OpID", table.Rows[i]["OpinionId"].ToString());
                cmd1.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Metoda zmieniająca losowo kolejność wpisów w tabeli z użytkownikami, którzy wysłali już opinię
        /// </summary>
        /// <remarks>Przemieszanie wpisów służy zaciemnianiu obrazu danych przed administratorem oraz prowadzącym.</remarks>
        private void ShuffleUsersWithOpinionsTable()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from UsersWithOpinionSend", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);

            int rows_nr = table.Rows.Count;
            int[] indexes = new int[rows_nr];
            for (int j = 0; j < rows_nr; j++)
            {
                indexes[j] = j;
            }
            Random rnd = new Random();
            indexes = indexes.OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0; i < rows_nr; i++)
            {
                SqlCommand cmd1 = new SqlCommand("Update UsersWithOpinionSend SET Username = @User, Year = @Year, GroupID = @GroupID, Subject = @Subject, Teacher = @Teacher WHERE Id = @UserID", con);
                cmd1.Parameters.AddWithValue("@User", table.Rows[indexes[i]]["Username"].ToString());
                cmd1.Parameters.AddWithValue("@Year", table.Rows[indexes[i]]["Year"].ToString());
                cmd1.Parameters.AddWithValue("@GroupID", table.Rows[indexes[i]]["GroupID"].ToString());
                cmd1.Parameters.AddWithValue("@Subject", table.Rows[indexes[i]]["Subject"].ToString());
                cmd1.Parameters.AddWithValue("@Teacher", table.Rows[indexes[i]]["Teacher"].ToString());
                cmd1.Parameters.AddWithValue("@UserID", table.Rows[i]["Id"].ToString());
                cmd1.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Funkcja do szyfrowania opinii
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>Zaszyfrowany tekst w formie tekstowej</returns>
        /// <remarks>
        /// Funkcja szyfruje tekst w oparciu o algorytm AES oraz klucz, który znajduje się w niedostępnym dla administratora pliku zewnętrznym.
        /// </remarks>
        private string Encrypt(string clearText)
        {
            string EncryptionKey = File.ReadAllText(@"C:\Users\Jan Kremer\source\repos\test\test.txt");
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (System.IO.MemoryStream ms = new MemoryStream())
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
        /// Funkcja do odszyfrowywania.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>Odszyfrowany tekst</returns>
        /// <remarks>
        /// Jest funkcją odwrotną do Encrypt, używamy jej, aby sprawdzić czy opinia o podanym unikalnym kodzie jest zapisana poprawnie w bazie.
        /// </remarks>
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

        /// <summary>
        /// Funkcja hashująca
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns>Skrót wporwadzonego tekstu</returns>
        /// <remarks>
        /// Służy do tworzenia skrótu unikalnego kodu po przesłaniu opinii.
        /// </remarks>
        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().Substring(0,10);
            }
        }

    }
}
 