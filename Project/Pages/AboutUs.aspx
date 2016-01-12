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
            <h1>Oscar Wahlström</h1>
            <p>
                1990. Eskilstuna. Student.
            </p>
        </div>
    </div>
    </form>
</body>
</html>
