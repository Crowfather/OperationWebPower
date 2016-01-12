<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Pages_ContactUs" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Contact Us</title>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/AboutUs.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <Top:TopMenu ID="TopMenu" runat="server" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            <h1>Mail</h1>
            <p>
                <a href="mailto:owm14002@student.mdh.se?Subject=Gearcommunity%20Feedback">Send Mail</a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
