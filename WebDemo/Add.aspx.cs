using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

public partial class News_News_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClearUp(); 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        System.DateTime currentTime = new System.DateTime();
        currentTime = System.DateTime.Now; 
        string strYMD = currentTime.ToString("D"); 
        string s = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        string sql = "insert into tb_News (News_title,News_body,News_addDate)" + "values(@title,@body,@time)";
        SqlConnection conn = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand(sql,conn);
        conn.Open();
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add(new SqlParameter("@title", tb_title.Text));
        cmd.Parameters.Add(new SqlParameter("@body", tb_content.Text));
        cmd.Parameters.Add(new SqlParameter("@time", strYMD));
        try
        {
            int n = cmd.ExecuteNonQuery();
            if (n == 1)
                Response.Write("<script>alert('添加成功!');</script>");
            else
                Response.Write("<script>alert('添加失败。');</script>");
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        ClearUp();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    public void ClearUp()
    {
        tb_title.Text = "";
        tb_content.Text = "";
        tb_title.Focus();
    }
}