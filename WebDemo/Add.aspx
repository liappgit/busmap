<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="News_News_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body bgcolor="#CCCCFF">
    <form id="form1" runat="server"> 
    <div style="width:700px;">
    
        &nbsp;<asp:Label ID="Label1" runat="server" 
            Text="添加标题" ForeColor="Black"></asp:Label>
    
        &nbsp;&nbsp;<asp:TextBox ID="tb_title" runat="server" Height="20px" 
            Width="326px" BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="添加内容" 
            ForeColor="Black"></asp:Label><br /><br />
        &nbsp;&nbsp;<asp:TextBox ID="tb_content" runat="server" Height="365px" TextMode="MultiLine" 
            Width="590px" BorderStyle="Inset" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        <br />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="重置" />
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="添加" onclick="Button2_Click" />
    
        &nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="返回" />
    
    </div>
    </form>
    <p>
         &nbsp;&nbsp;&nbsp;
    </p>
</body>
</html>