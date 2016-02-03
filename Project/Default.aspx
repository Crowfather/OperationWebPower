<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Home</title>
    <link href="Styles/PageLayout.css" rel="stylesheet" />
    <link href="Styles/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <Top:TopMenu ID="TopMenu" runat="server" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            <asp:ScriptManager ID="ScriptMan" runat="server" />
            <asp:UpdatePanel ID="UpdatePan" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <!-- Note: changing the id of this table will make it unreachable from the code-behind -->
                    <!-- If you change the id you are also responsible to update all references in the code-behind -->
                    <table id="containertable" runat="server">
                        <tr>
                            <td id="gearcommunityimagecell" runat="server">
                                <img src="../Resources/Img/GearCommunity75PercentSize.png" alt="Gear Community" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Table id="newstable" runat="server">
                                    <%-- Dynamically filled with rows, columns and news content (see code-behind) --%>
                                </asp:Table>
                            </td>
                            <%-- <td id="containertable_fillercell_right">
                                <!-- Right side filler -->
                            </td> --%>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </div>
    </form>
</body>
</html>
