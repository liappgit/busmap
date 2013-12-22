using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        string sql = "select * from tb_Class";
        string readname = "",readpass = "";
        bool judge = false;

        if (username.Text == "" || password.Text == "")
        {
            Response.Write("<script>alert('输入格式不正确');</script>");
            username.Text = "";
            password.Text = "";
            username.Focus();
        }
        else
        {
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                readname = reader["Class_Name"].ToString();
                readpass = reader["Class_Password"].ToString();
                if (readname == username.Text && readpass == password.Text)
                {
                    judge = true;
                    break;
                }
            }
            try
            {
                if (!judge)
                {
                    Response.Write("<script>alert('登录失败');</script>");
                    username.Text = "";
                    password.Text = "";
                    username.Focus();
                }
                else
                {
                    Response.Write("<script>alert('登录成功');location.href='index.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Regist.aspx");
    }
}