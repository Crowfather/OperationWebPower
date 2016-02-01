<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Pages_AboutUs" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - About Us</title>
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
            <div id="ImageDiv">
                <img id="GearCommunityImg" src="<%= ResolveUrl("~/Resources/Img/GearCommunity75PercentSize.png") %>" alt="About Gear Community" />
            </div>
            <p>
                Gear Community gathers all software’s in all categories to simplify that you find what you are looking for. It does not matter how old you are or how much experience you have, Gear Community have everything fit just for you. It is never too late to learn something, Gear Community helps you to find what you are looking for quickly without you having to search for hours online in vain. Fast, easy and costs nothing. If there are any questions or if there is something that you think is missing so do not be afraid to get in touch with us.
            </p>
        </div>
    </div>
    </form>
</body>
</html>
