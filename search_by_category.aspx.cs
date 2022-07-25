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

public partial class search_by_category : System.Web.UI.Page
{

    SqlConnection con = null;
    SqlDataAdapter adp = null;
    SqlCommand cmd = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList2.Items.Insert(0, new ListItem("select", "0"));
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        string query = "select * from job_post where area_id=" + DropDownList2.SelectedValue;

        adp = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Pratik\\Desktop\\Jobadda\\App_Data\\JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        int cid=0;
        cid = Convert.ToInt32(Session["Cid"].ToString());

        int rws = 0;
        rws = Convert.ToInt32(GridView1.Rows.Count.ToString());
          
        for (int i = 0; i < rws ; i++)
         {
             CheckBox chk = (CheckBox)GridView1.Rows[i].FindControl("CheckBox3");

             if (chk.Checked == true)
             {
                 String a = GridView1.Rows[i].Cells[2].Text;
                 string query = "insert into Saved_jobs (candidate_id,jobpost_id) values (" + cid + "," + a + ")";
                 cmd = new SqlCommand(query, con);
                 cmd.ExecuteNonQuery();
             }
         }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
