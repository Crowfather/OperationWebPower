<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Project.Category" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="uc1" TagName="TopMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Category</title>
    <link href="../Styles/Home.css" rel="stylesheet" />
    <link href="../Styles/Category.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <uc1:TopMenu runat="server" ID="TopMenu" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            Category
        </div>
    </div>
    </form>
</body>
</html>
