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
    public partial class TeacherDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        protected void GetData()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["Baza DanychConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(dbConnectionString);
            SqlCommand cmd = new SqlCommand("Select OpinionContent from Opinions where Teacher = @Teacher", con);
            cmd.Parameters.AddWithValue("@Teacher", Session["TeacherLoggedIn"]);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Opinions1.DataSource = ds;
            Opinions1.DataBind();
        }
    }
}