﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="TopMenu"%>

<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Styles/TopMenu.css") %>" />
<script type="text/javascript" src="<%= ResolveUrl("~/Scripts/TopMenu.js") %>"></script>

<asp:Panel ID="Top" runat="server">
    <table id="TopOuterTable">
        <tr>
            <td id="TopOuterFillerLeft"></td>
            <td>
                <%-- <a href="<%= ResolveUrl("~/Default.aspx") %>"> --%>
                <a href="Default.aspx">
                    <img id="MenuLogo" src="<%= ResolveUrl("~/Resources/Img/Gear1.png") %>" alt="Logo" />
                </a>
            </td>
            <td>
                <table id="MenuTable">
                    <tr id="MenuRow">
                        <td id="MenuHomeCell" class="MenuCell">
                            <%-- <a href="<%= ResolveUrl("~/Default.aspx") %>"> --%>
                            <a href="Default.aspx">
                                <div class="MenuCellDiv">Home</div>
                            </a>
                        </td>
                        <td id="MenuCategoryCell" class="MenuCell">
                            <%-- <a href="<%= ResolveUrl("~/Pages/Category.aspx") %>"> --%>
                            <a href="Category.aspx">
                                <div class="MenuCellDiv">Category</div>
                            </a>
                        </td>
                        <%-- <td id="MenuCommunityCell" class="MenuCell">
                            <a href="">
                                <div class="MenuCellDiv">Community</div>
                            </a>
                        </td> --%>
                        <td id="MenuAboutUsCell" class="MenuCell">
                            <%-- <a href="<%= ResolveUrl("~/Pages/AboutUs.aspx") %>"> --%>
                            <a href="AboutUs.aspx">
                                <div class="MenuCellDiv">About Us</div>
                            </a>
                        </td>
                        <td id="MenuContactUsCell" class="MenuCell">
                            <%--<a href="<%= ResolveUrl("~/Pages/ContactUs.aspx") %>"> --%>
                            <a href="ContactUs.aspx">
                                <div class="MenuCellDiv">Contact Us</div>
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
            <td id="TopOuterFillerRight"></td>
        </tr>
    </table>
    <%-- <div id="SubMenu">
        <table>
            <tr>
                <td class="SubMenuCell">
                    <a href="<%= ResolveUrl("~/Pages/LoginPage.aspx") %>">Login</a>
                </td>
                <td class="SubMenuCell">
                    <a href="">Search...</a>
                </td>
            </tr>
        </table>
    </div> --%>
</asp:Panel>
