<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductsCategory.aspx.cs" Inherits="Pages_ProductsCategory" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Category - Design</title>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/SubCategories.css" rel="stylesheet" />
    <script src="../Scripts/Category.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <Top:TopMenu runat="server" ID="TopMenu" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent" runat="server">
            Products
        </div>
    </div>
    </form>
</body>
</html>
