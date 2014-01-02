using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        localhost.WebService service = new localhost.WebService();
        string text = service.convertToChinese(int.Parse(TextBox1.Text));
        Label1.Text = text;

        SqlConnection conn = new SqlConnection(s);

        string sql = "insert into serTable(text1,text2) " + "values(@t1,@t2)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        cmd.Parameters.Add(new SqlParameter("@t1", TextBox1.Text));
        cmd.Parameters.Add(new SqlParameter("@t2", Label1.Text));
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        conn.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.Text = "";
        SqlConnection conn = new SqlConnection(s);
        string sql = "select * from serTable";
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        string t, b;
        while (reader.Read())
        {
            t = reader["text1"].ToString();
            b = reader["text2"].ToString();
            Label2.Text += (t + " " + b + "<br/>");

        }
        cmd.Dispose();
        conn.Close();
    }
}