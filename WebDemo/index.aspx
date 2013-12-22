<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body
    {
        background-color:#880000;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style=" width:200px; height:58px; margin:50px auto 30px; color:#EAEAEA; font-size:32px; font-family:Microsoft YaHei; font-weight:bold; text-align:center;">发布台</div>
    <div class="cleardiv"></div>
    <table height="494" align="center" cellpadding="0">
    
    <tr>
        
    <td bgcolor="#666666" class="style1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="loginButton" runat="server" Text="登录" 
            onclick="loginButton_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="registButton" runat="server" Text="注册" 
            onclick="registButton_Click" />
        <asp:Calendar ID="Calendar1" runat="server" Height="350px" Width="350px"
            BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" Font-Names="Verdana" 
            Font-Size="8pt" ForeColor="#663399" DayNameFormat="Shortest" ShowGridLines="True" >
            <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" 
                Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar><br /><br /><br />
        
        &nbsp;&nbsp;
        <asp:Button ID="flash" runat="server" Text="退出查询" onclick="flash_Click" />
        &nbsp;&nbsp;
        <asp:TextBox ID="textsearch" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="查询" onclick="search_Click" 
            style="height: 21px" />
    </td>

    <td colspan="2" bgcolor="#333333" valign="top" class="style1">
        <asp:GridView ID="GridView1" runat="server"
            AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="News_id" ForeColor="#333333" GridLines="None" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" AllowPaging="True" 
            AllowSorting="True" onsorting="GridView1_Sorting" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="12">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="News_id" Visible="False" />
                <asp:BoundField DataField="News_title" HeaderText="标题" SortExpression="News_title"/>
                <asp:BoundField DataField="News_body" HeaderText="内容" />
                <asp:BoundField DataField="News_addDate" HeaderText="添加时间" SortExpression="News_addDate"/>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" Height="50px" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                Height="40px" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" 
                Height="40px" Width="350px" Wrap="True" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="out" runat="server" Text="退出排序" onclick="flash_Click"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Add" runat="server" Text="增加新发布" onclick="Add_Click" /><br /><br />
    </td>
    </tr>
    </table>
    </div>
    </form>
    <div style=" float:left; width:100%; height:120px; background-color:#880000;">
        <div style=" width:200px; margin:50px auto 0; color:#EAEAEA; font-family:Microsoft YaHei; text-align:center;">Copyright</div>
    </div>
</body>
</html>
