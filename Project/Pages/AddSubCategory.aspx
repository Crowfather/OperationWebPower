<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubCategory.aspx.cs" Inherits="Pages_AddSubCategory" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="uc1" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - AddSubCategory</title>
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
                <h3><asp:Label ID="lCategoryName" runat="server" Text="SubCategoryName"></asp:Label></h3>
                <br />
                <asp:TextBox ID="tbCategoryName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCategoryName" ControlToValidate="tbCategoryName" runat="server" ErrorMessage="Missing sub category name"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
                <asp:Label ID="lCreateStatus" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
