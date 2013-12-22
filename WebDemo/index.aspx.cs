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

public partial class index : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    string s = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.Attributes.Add("style", "table-layout:fixed");
            ViewState["SortOrder"] = "News_id";
            ViewState["OrderDire"] = "ASC";
            GridViewBind();
            bind();
        }
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void registButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Regist.aspx");
    }

    public void bind()
    {
        string sql = "select * from tb_News";
        conn = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter(sql,conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds, "tb_News");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        conn.Close();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "delete from tb_News where News_id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        string message = "";
        conn = new SqlConnection(s);
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        try
        {
            int n = cmd.ExecuteNonQuery();
            if (n == 1)
                message = "删除成功！";
            else
                message = "删除失败。";
        }
        catch (Exception ex)
        {
            message = "删除信息过程中出错" + ex.Message.Replace("\r", "\\r").Replace("\n", "\\n");
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
        }
        showMessage(message);
        bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        conn = new SqlConnection(s);

        string sqlstr = "update tb_News set News_title='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',News_body='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',News_AddDate='"
            + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where News_id='"
            + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        cmd = new SqlCommand(sqlstr, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        GridView1.EditIndex = -1;
        bind();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }

    public void GridViewBind()
    {
        conn = new SqlConnection(s);
        string sql = "select * from tb_News";
        SqlDataAdapter da = new SqlDataAdapter(sql,conn);
        DataSet ds = new DataSet();
        da.Fill(ds,"tb_News");
        DataView dv = ds.Tables[0].DefaultView;
        string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
        dv.Sort = sort;
        GridView1.DataSource = dv;
        GridView1.DataBind();
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "Desc")
                ViewState["OrderDire"] = "ASC";
            else
                ViewState["OrderDire"] = "Desc";
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        GridViewBind();
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add.aspx");
    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind(); 
    }

    protected void search_Click(object sender, EventArgs e)
    {
        string sql = "select * from tb_News where News_title like '%'+'"+textsearch.Text+"'+'%'";
        conn = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        conn.Open();
        da.Fill(ds, "tb_News");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        conn.Close();
    }

    protected void flash_Click(object sender, EventArgs e)
    {
        GridView1.Attributes.Add("style", "table-layout:fixed");
        ViewState["SortOrder"] = "News_id";
        ViewState["OrderDire"] = "ASC";
        GridViewBind();
        bind();
    }

    public void showMessage(string alertNews)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + alertNews + "');</script>");
    }
}