<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProductCategory.aspx.cs" Inherits="Pages_AddProductCategory" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="uc1" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - AddProductCategory</title>
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
                <h3><asp:Label ID="lProductName" runat="server" Text="Add existing product"></asp:Label></h3>
                <br />
                <asp:DropDownList ID="choseProductDownList" runat="server" style="margin-left: 10px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryName" ControlToValidate="choseProductDownList" validationgroup="addExisting" runat="server" ErrorMessage="Choose a product"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="btnAddProduct" runat="server" Text="Add product" validationgroup="addExisting" OnClick="btnAddProduct_Click"/>
                <asp:Label ID="lAddStatus" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <hr />
                
                <h3><asp:Label ID="Label1" runat="server" Text="Create a new product"></asp:Label></h3>
                <br />
                
                <h3><asp:Label ID="lbProductName" runat="server" Text="Product name"></asp:Label></h3>
                <br />
                <asp:TextBox ID="tbProductName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductName" ControlToValidate="tbProductName" validationgroup="createNew" runat="server" ErrorMessage="Choose a name"></asp:RequiredFieldValidator>

                <h3><asp:Label ID="Label2" runat="server" Text="TODO PICTURE!!!!"></asp:Label></h3>
                <br />

                <h3><asp:Label ID="lbDescription" runat="server" Text="Pricing"></asp:Label></h3>
                <br />
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="tbDescription" validationgroup="createNew" runat="server" ErrorMessage="Choose a pricing"></asp:RequiredFieldValidator>

                <h3><asp:Label ID="Label3" runat="server" Text="TODO ProductText!!!!"></asp:Label></h3>
                <br />
                <h3><asp:Label ID="Label4" runat="server" Text="TODO contentText!!!!"></asp:Label></h3>
                <br />
                <h3><asp:Label ID="Label5" runat="server" Text="TODO systemrequirements!!!!"></asp:Label></h3>
                <br />

                <br />
                <asp:Button ID="btnCreateProduct" runat="server" Text="Create new product" validationgroup="createNew" OnClick="btnCreateProduct_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
