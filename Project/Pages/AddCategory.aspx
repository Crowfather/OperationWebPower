<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Pages_AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lCategoryName" runat="server" Text="CategoryName"></asp:Label>
        <br />
        <asp:TextBox ID="tbCategoryName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCategoryName" ControlToValidate="tbCategoryName" runat="server" ErrorMessage="Missing category name"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
        <asp:Label ID="lCreateStatus" runat="server" Text="" Visible="false"></asp:Label>
    </form>
</body>
</html>
