using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = null;
    SqlDataReader dr = null;
    SqlCommand cmd = null;
    SqlDataAdapter adp = null;

    public int getrid(string UserName)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        int rec;

        string query = "select company_id from company where username='" + UserName + "' ";
        adp = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        rec = Convert.ToInt32(ds.Tables[0].Rows[0]["company_id"].ToString());

        return (rec);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool Flag = false;

        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Login";
        dr = cmd.ExecuteReader();
        string Role = "";

        while (dr.Read())
        {
            string UserName = dr[0].ToString();
            string PassWord = dr[1].ToString();
            int rid = 0;

            if (tbrun.Text == UserName && tbrpw.Text == PassWord)
            {
                Session.Add("RName", UserName);
                Role = dr[2].ToString();
                Flag = true;

                rid = getrid(UserName);
                Session.Add("Rid", rid);
            }
        }
        dr.Close();

        if (Flag == false)
        {
            Label5.Visible = true;
            Label5.Text = "Not authorized";
        }
        if (Flag == true)
        {
            if (Role == "recruiter")
            {
                Response.Redirect("~/recruiter_profile.aspx");
            }
        }
        con.Close();
    }
}
