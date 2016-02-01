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
            <img id="GearCommunityImg" src="<%= ResolveUrl("~/Resources/Img/GearCommunity75PercentSize.png") %>" alt="Contact us" />
            <p>
                If you have questions, if you think something is missing or if something is wrong with the website, please contact our support: 
            </p>
            <p>
                <a href="mailto:Support@gearcommunity.org?Subject=Gearcommunity%20Feedback">Support@gearcommunity.org</a>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
