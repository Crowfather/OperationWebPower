<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Pages_LoginPage" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="uc1" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Login</title>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <uc1:TopMenu runat="server" ID="TopMenu" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent" runat="server">
            <h3><asp:Label ID="lUserName" runat="server" Text="Username"></asp:Label></h3>
            <br />
            <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="tbUserName" runat="server" ErrorMessage="Missing username"></asp:RequiredFieldValidator>
            <br />
            <h3><asp:Label ID="lPassword" runat="server" Text="Password"></asp:Label></h3>
            <br />
            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="tbPassword" runat="server" ErrorMessage="Missing password"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
            <asp:Label ID="lLoginStatus" runat="server" Text="Wrong username or password" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="btdDebugLoginu" runat="server" Text="Logout" CausesValidation="false" OnClick="btdDebugLoginu_Click"/>
        </div>
    </div>
    </form>
</body>
</html>
