﻿using System;
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
    SqlDataAdapter adp = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        string query = "select que_id,ansr,username from Company where company_id=6";
        adp = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        string ansrr = null;
        string a = null;
        a = ds.Tables[0].Rows[0]["ansr"].ToString();
        ansrr = TextBox1.Text;

        // string qid = null;
        //qid = ds.Tables[0].Rows[0]["que_id"].ToString();

        // Label23.Text = DropDownList4.SelectedIndex.ToString();

        if (a == ansrr)
        {
            Label23.Text = ds.Tables[0].Rows[0]["username"].ToString();
            TextBox2.Enabled = true;
            TextBox3.Enabled = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|JobportalDB.mdf;Integrated Security=True;User Instance=True");
        con.Open();

        if (TextBox2.Text == TextBox3.Text)
        {
            Label26.Visible = false;

            string query = "update Login set password= '" + TextBox2.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        else
        {
            Label26.Visible = true;
            Label26.Text = "Password did not matched";
        }


    }
}
