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
                <h3>
                    <asp:Label ID="lProductName" runat="server" Text="Add existing product"></asp:Label></h3>
                <br />
                <asp:DropDownList ID="choseProductDownList" runat="server" Style="margin-left: 10px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryName" ControlToValidate="choseProductDownList" ValidationGroup="addExisting" runat="server" ErrorMessage="Choose a product"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnAddProduct" runat="server" Text="Add product" ValidationGroup="addExisting" OnClick="btnAddProduct_Click" />
                <asp:Label ID="lAddStatus" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <hr />

                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Create a new product"></asp:Label></h3>
                <br />

                <asp:Label ID="lbProductName" runat="server" Text="Product name" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:TextBox ID="tbProductName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductName" ControlToValidate="tbProductName" ValidationGroup="createNew" runat="server" ErrorMessage="Choose a name"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="Label2" runat="server" Text="Product picture" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:FileUpload ID="fileUploadControl" runat="server" />
                <asp:Label runat="server" ID="lUploadStatus" Text="Upload status: " Visible="false" />
                <br />

                <asp:Label ID="lbDescription" runat="server" Text="Pricing" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="tbDescription" ValidationGroup="createNew" runat="server" ErrorMessage="Choose a pricing"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="Label3" runat="server" Text="Product text" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:TextBox ID="tbProductText" runat="server" TextMode="MultiLine" Style="margin-left: 10px" Height="150px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbProductText" ValidationGroup="createNew" runat="server" ErrorMessage="Enter text"></asp:RequiredFieldValidator>
                <br />
                
                <asp:Label ID="Label4" runat="server" Text="Content text" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:TextBox ID="tbContentText" runat="server" TextMode="MultiLine" Style="margin-left: 10px" Height="150px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbContentText" ValidationGroup="createNew" runat="server" ErrorMessage="Enter text"></asp:RequiredFieldValidator>
                <br />
                
                <asp:Label ID="Label5" runat="server" Text="System Requirements" Style="margin-left: 10px"></asp:Label>
                <br />
                <asp:TextBox ID="tbSystemRequirements" runat="server" TextMode="MultiLine" Style="margin-left: 10px" Height="150px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbSystemRequirements" ValidationGroup="createNew" runat="server" ErrorMessage="Enter text"></asp:RequiredFieldValidator>
                <br />

                <br />
                <asp:Button ID="btnCreateProduct" runat="server" Text="Create new product" ValidationGroup="createNew" OnClick="btnCreateProduct_Click" />




            </div>
        </div>
    </form>
</body>
</html>
