<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type = "text/css">
        body
        { 
        text-align:center; 
	    position:absolute; 
	    left:35%; 
	    top:25%;
        font-size:20px; 
        background:#00BBFF;} 
        .style1
        {
            height:10px;}
        .style2
        {
            width: 157px;
            height: 15px;}
    </style>

</head>

<body>

    <form id="form1" runat="server">
    <div>
        
        <h1 style="height: 50px">用户登录</h1>
        <table style="height: 170px; width: 320px;">
      <tr><td class="style2">用户名：</td>
          <td class="style2"><asp:TextBox ID="username" runat="server" ></asp:TextBox><br /></td>
          </tr>
      <tr><td class="style2">密 码：</td>
          <td class="style2"><asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><br /></td>
          </tr>
      <tr><td class="style1"></td>
          <td class="style1"><asp:Button ID="loginButton" runat="server" Text="登录" 
              onclick="Button1_Click" />
              <asp:Button ID="registButton" runat="server" Text="注册" 
              onclick="Button2_Click" /></td>
          </tr>
      </table>
        
    </div>
    </form>
</body>
</html>
