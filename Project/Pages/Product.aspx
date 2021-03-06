﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Project.Product" %>

<%@ Register Src="~/Controls/TopMenu.ascx" TagPrefix="Top" TagName="TopMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Product</title>
    <link href="../Styles/PageLayout.css" rel="stylesheet" />
    <link href="../Styles/Product.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/Product.js"></script>
</head>
<body>
    <div id="fb-root"></div>
    <script>        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/sv_SE/sdk.js#xfbml=1&version=v2.5";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));
    </script>

    <script>        
            window.twttr = (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0],
            t = window.twttr || {};
            if (d.getElementById(id)) return t;
            js = d.createElement(s);
            js.id = id;
            js.src = "https://platform.twitter.com/widgets.js";
            fjs.parentNode.insertBefore(js, fjs);

            t._e = [];
            t.ready = function (f) {
                t._e.push(f);
            };

            return t;
        } (document, "script", "twitter-wjs"));</script>

    <form id="form1" runat="server">
        <div id="Container">
        <Top:TopMenu ID="TopMenu" runat="server" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
            <!-- Product area table -->
            <table id="productsection_table">
                <tr>
                    <!-- Tabs -->
                    <td id="productsection_tab_product" class="productsection_tab_design productsection_tab_text productsection_tab_selected">
                        <h3>Product</h3>
                    </td>
                    <td id="productsection_tab_content" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                        <h3>Content</h3>
                    </td>
                    <td id="productsection_tab_rating" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                        <h3>Rating and comments</h3>
                    </td>
                    <td id="productsection_tab_sysreq" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                        <h3>System requirements</h3>
                    </td>
                    <td id="productsection_tab_share" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                        <h3>Share</h3>
                    </td>
                    <td>
                        <!-- Filler (empty space to the right of tabs) -->
                    </td>
                </tr>
                <tr>
                    <!-- Content cell -->
                    <!-- TODO: Set colspan to the number of tabs + 1 (for extra space cell) -->
                    <td colspan="6" id="productsection_contentcell">
                        <table id="productsection_contenttable">
                            <tr>
                                <!-- Logotype image section cell -->
                                <td>
                                    <div id="general_product_logoimg">
                                        <img id="databind_image" runat="server" src="../Resources/Img/placeholder-logo.png" alt="Product Logo" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <!-- Title section cell -->
                                <td>
                                    <div id="general_product_title">
                                        <h1 id="databind_title" runat="server">Title</h1>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <!-- Text sections cell -->
                                <td>
                                    <div id="product_section_text">
                                        <p id="databind_productText" runat="server">Product text.</p>
                                    </div>

                                    <div id="content_section_text">
                                        <p id="databind_contentText" runat="server">Content text.</p>
                                    </div>

                                    <div id="sysreq_section_text">
                                        <p id="databind_systemReq" runat="server">System requirements.</p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <!-- Special case: rating and comments section cell
                                    TODO: rating -->
                                <td>
                                    <div id="general_product_rating">
                                        <div runat="server" id="Comments" class="fb-comments"></div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <!-- Special case: share section cell -->
                                <td id = "share_cell">
                                    <div id="general_product_share">
                                        <table id = "share_table">
                                        <tr>
                                        <td class = share_table_cell>
                                            <!-- TODO: Add more share components here -->
                                      
                                            <div runat = "server" id ="face_share" class="fb-share-button" data-layout="button"></div>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td class = share_table_cell>
                                            <div>
                                                <a 
                                                class="twitter-share-button"
                                                href="https://twitter.com/intent/tweet"
                                                data-via= "best produkt site ever"
                                                data-size="large"
                                                data-hashtags="best_site,best_products"
                                                >
                                                Tweet
                                                </a>
                                            </div>
                                        </td>
                                        </tr>
                                        </table>
                                    </div>
                                  
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table> <!-- Product area table end -->
            </div>
        </div>
    </form>
</body>
</html>
