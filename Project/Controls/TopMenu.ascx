<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="TopMenu"%>
<!-- <%@ OutputCache Duration="120" VaryByParam="None" %> -->

<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Styles/TopMenu.css") %>" />
<script src="<%= ResolveUrl("~/Scripts/TopMenu.js") %>"></script>

<asp:Panel ID="Top" runat="server">
    <table id="TopOuterTable">
        <tr>
            <td id="TopOuterFillerLeft"></td>
            <td>
                <a href="default.aspx">
                    <img id="MenuLogo" src="../Resources/Img/logo.png" alt="Logo" />
                </a>
            </td>
            <td>
                <table id="MenuTable">
                    <tr id="MenuRow">
                        <td id="MenuHomeCell" class="MenuCell">
                            <a href="default.aspx">
                                <div class="MenuCellDiv">Home</div>
                            </a>
                        </td>
                        <td id="MenuCategoryCell" class="MenuCell">
                            <a href="Category.aspx">
                                <div class="MenuCellDiv">Category</div>
                            </a>
                        </td>
                        <td id="MenuCommunityCell" class="MenuCell">
                            <a href="Product.aspx">
                                <div class="MenuCellDiv">Community</div>
                            </a>
                        </td>
                        <td id="MenuAboutUsCell" class="MenuCell">
                            <a href="">
                                <div class="MenuCellDiv">About Us</div>
                            </a>
                        </td>
                        <td id="MenuContactUsCell" class="MenuCell">
                            <a href="">
                                <div class="MenuCellDiv">Contact Us</div>
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
            <td id="TopOuterFillerRight"></td>
        </tr>
    </table>
    <div id="SubMenu">
        <table>
            <tr>
                <td class="SubMenuCell">
                    <a href="">Login</a>
                </td>
                <td class="SubMenuCell">
                    <a href="">Search...</a>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
