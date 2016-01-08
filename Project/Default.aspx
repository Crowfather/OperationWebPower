<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Home</title>
    <% if (DesignMode == true) { %>
        <!-- To get CSS style of the topmenu to show up in Design/Split view here in VS -->
        <!-- (Real CSS is included inside TopMenu.ascx !) -->
        <link href="~/Styles/TopMenu.css" rel="stylesheet" type="text/css" />
    <% } %>
    <link href="Styles/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <Top:TopMenu runat="server" ID="TopMenu" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            Home/News
        </div>       
    </div>
    </form>
</body>
</html>
