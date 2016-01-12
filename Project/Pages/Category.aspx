<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Project.Category" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="uc1" TagName="TopMenu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Category</title>
    <% if (DesignMode == true) { %>
        <!-- To get CSS style of the topmenu to show up in Design/Split view here in VS -->
        <!-- (Real CSS is included inside TopMenu.ascx !) -->
        <link href="~/Styles/TopMenu.css" rel="stylesheet" type="text/css" />
    <% } %>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/Category.css" rel="stylesheet" />
    <script src="../Scripts/Category.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Container">
        <uc1:TopMenu runat="server" ID="TopMenu" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            <asp:ScriptManager ID="ScriptMan" runat="server" />
            <asp:UpdatePanel ID="UpdatePan" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <asp:Table ID="CategoryMenu" EnableViewState="false" runat="server"></asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- <asp:Table ID="CategoryMenu" runat="server"></asp:Table> --%>
            <%-- <asp:Table ID="CategoryMenu" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="CategoryMenuCell">
                            <a href="./Categories/Design.aspx">
                                <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                                    <h1>Design</h1>
                                </asp:Panel>
                            </a>
                            <asp:Button CssClass="CategoryMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="CategoryMenuCell">
                        <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                            <h1>Music</h1>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="CategoryMenuCell">
                        <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                            <h1>Programming</h1>
                        </asp:Panel>
                    </asp:TableCell>
                    <asp:TableCell CssClass="CategoryMenuCell">
                        <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                            <h1>Economy</h1>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="CategoryMenuCell">
                        <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                            <h1>Category 1</h1>
                        </asp:Panel>
                    </asp:TableCell>
                    <asp:TableCell CssClass="CategoryMenuCell">
                        <asp:Panel CssClass="CategoryMenuCellDiv" runat="server">
                            <h1>Category 2</h1>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> --%>
        </div>
    </div>
    </form>
</body>
</html>
