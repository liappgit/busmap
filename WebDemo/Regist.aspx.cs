using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Regist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (username.Text == ""||password.Text == ""||
            conform.Text == "")
        {
            Response.Write("<script>alert('输入格式不正确');</script>");
            ClearUp();
        }
        else if (password.Text != conform.Text)
        {
            Response.Write("<script>alert('两次输入的密码不同');</script>");
            password.Text = "";
            conform.Text = "";
            password.Focus();
        }
        else
        {
            string s = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            string sql = "select * from tb_Class";
            string dbUserName;
            Boolean exist = false;
            SqlConnection conn = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbUserName = reader["Class_Name"].ToString();
                if (dbUserName == username.Text)
                {
                    ClearUp();
                    Response.Write("<script>alert('用户名已存在');</script>");
                    exist = true;
                }
            }
            reader.Close();

            if (!exist)
            {
                sql = "insert into tb_Class (Class_Name,Class_Password)" + "values(@name,@pass)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@name", username.Text));
                cmd.Parameters.Add(new SqlParameter("@pass", password.Text));
                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n == 1)
                        Response.Write("<script>alert('注册成功！');</script>");
                    else
                        Response.Write("<script>alert('注册失败。');</script>");
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
            }
        }
    }

    public void ClearUp()
    {
        username.Text = "";
        password.Text = "";
        conform.Text = "";
        username.Focus();
    }
}