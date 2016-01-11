<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="Pages_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lUserName" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="tbUserName" runat="server" ErrorMessage="Missing username"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lPassword" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="tbPassword" runat="server" ErrorMessage="Missing password"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
            <asp:Label ID="lLoginStatus" runat="server" Text="Wrong username or password" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="btdDebugLoginu" runat="server" Text="DEBUGLOGOUT!!!!" CausesValidation="false" OnClick="btdDebugLoginu_Click"/>
        </div>
    </form>
</body>
</html>
