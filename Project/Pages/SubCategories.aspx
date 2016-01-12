<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubCategories.aspx.cs" Inherits="Pages_Categories_SubCategories" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Category - Sub Categories</title>
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
            <asp:ScriptManager ID="ScriptMan" runat="server" />
            <asp:UpdatePanel ID="UpdatePan" UpdateMode="Conditional" ChildrenAsTriggers="false" runat="server">
                <ContentTemplate>
                    <asp:Table ID="SubCatMenu" runat="server"></asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- <asp:Table ID="SubCatMenu" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>Data Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>Game Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>Level Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>Logo Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>Product Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell CssClass="SubCatMenuCell">
                        <a href="">
                            <asp:Panel CssClass="SubCatMenuCellDiv" runat="server">
                                <h1>UX Design</h1>
                            </asp:Panel>
                        </a>
                        <asp:Button CssClass="SubCatMenuCellDel" Text="X" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> --%>
        </div>
    </div>
    </form>
</body>
</html>
