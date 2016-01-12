<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductsCategory.aspx.cs" Inherits="Pages_ProductsCategory" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Category - Product Categories</title>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/CategoryProducts.css" rel="stylesheet" />
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
                    <asp:Table ID="ProdsCatMenu" EnableViewState="false" runat="server"></asp:Table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- <asp:Table ID="ProdsCatMenu" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>SolidWorks</h1>
                                <h2>Not Free</h2>
                                <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                            </div>
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Skit Program</h1>
                                <h2>Not Free</h2>
                                <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                            </div>
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Gratis Program</h1>
                                <h2>Free</h2>
                                <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                            </div>
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Gratis Program 2</h1>
                                <h2>Free</h2>
                            </div>
                            <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                        </a>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Bra Program</h1>
                                <h2>Not Free</h2>
                            </div>
                            <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Skit Bra Program</h1>
                                <h2>Not Free</h2>
                            </div>
                            <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Firefox</h1>
                                <h2>Free</h2>
                            </div>
                            <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                        </a>
                    </asp:TableCell>
                    <asp:TableCell CssClass="ProdsCatMenuCell">
                        <a href="Product.aspx">
                            <div class="ProdsCatMenuCellDiv">
                                <img src="../Resources/Img/placeholder-logo.png" />
                                <h1>Chrome</h1>
                                <h2>Free</h2>
                            </div>
                            <asp:Button CssClass="ProdsCatMenuCellDel" Text="X" runat="server" />
                        </a>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table> --%>
        </div>
    </div>
    </form>
</body>
</html>
