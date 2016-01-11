<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Project.Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Project - Product</title>
    <link rel="stylesheet" type="text/css" href="../Styles/Product.css" />
    <script type="text/javascript" src="../Scripts/Product.js"></script>
</head>
<body>
<div id="fb-root"></div>
    <script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/sv_SE/sdk.js#xfbml=1&version=v2.5";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
    </script>

    <div id="Div1"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/sv_SE/sdk.js#xfbml=1&version=v2.5";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>


    <form id="main_form" runat="server">
        <div>
            <!-- Some higher level container table -->
            <!-- TODO: Match this table with other high-level pages -->
            <table id="maintable">
                <tr>
                    <td colspan="3" class="maintable_fillercell_top">
                        <!-- Small top filler -->
                    </td>
                </tr>
                <tr>
                    <td class="maintable_fillercell_side">
                        <!-- Left column filler -->
                    </td>
                    <td>
                        <!-- Product area table -->
                        <table>
                            <tr>
                                <!-- Tabs -->
                                <td id="productsection_tab_product" class="productsection_tab_design productsection_tab_text productsection_tab_selected">
                                    <h3>Product</h3>
                                </td>
                                <td id="productsection_tab_content" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                                    <h3>Content</h3>
                                </td>
                                <td id="productsection_tab_rating" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                                    <h3>Rating and<br />comments</h3>
                                </td>
                                <td id="productsection_tab_sysreq" class="productsection_tab_design productsection_tab_text productsection_tab_unselected">
                                    <h3>System<br />requirements</h3>
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
                                                    <!-- DATABASE: Fetch [currently selected product] logotype image from the database -->
                                                    <!-- NOTE: [currently selected product] is the product that is selected through category buttons; -->
                                                    <!-- the one that users are viewing and want information about right now -->
                                                    <img src="../Resources/Img/placeholder-logo.png" alt="Product Logo" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <!-- Title section cell -->
                                            <td>
                                                <div id="general_product_title">
                                                    <!-- DATABASE: Fetch [currently selected product] name from the database -->
                                                    <h1>Title</h1>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <!-- Text sections cell -->
                                            <td>
                                                <div id="product_section_text">
                                                    <!-- DATABASE: Fetch [currently selected product] info text from the database -->
                                                    <h6>Product text.</h6>
                                                </div>

                                                <div id="content_section_text">
                                                    <!-- DATABASE: Fetch [currently selected product] content text from the database -->
                                                    <h6>Content text.</h6>
                                                </div>

                                                <div id="sysreq_section_text">
                                                    <!-- DATABASE: Fetch [currently selected product] system requirements text from the database -->
                                                    <h6>System requirements.</h6>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <!-- Special case: rating and comments section cell -->
                                            <td>
                                                <div id="general_product_rating">
                                                    <!-- TODO: Add components for comments and rating here -->
                                                    <!-- DATABASE: fetch produkt url dynamicly  -->
                                                    <div runat=server
                                                        
                                                       id="Comments" class="fb-comments">
                           
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <!-- Special case: share section cell -->
                                            <!-- DATABASE: fetch produkt url dynamicly  -->

                                            <td>
                                                <div id="general_product_share">
                                                    <div class="fb-share-button" data-href= "window.location.href" data-layout="button">
                                                    <!--<div class="fb-share-button" data-href="http://crowfather.imgur.com/all/" data-layout="button"> -->

                                                
                                                    </div>
                                                    <!-- TODO: Add share components here -->
                                                    <!-- TO CROW: Insert share stuff here! -->
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table> <!-- Product area table end -->
                    </td>
                    <td class="maintable_fillercell_side">
                        <!-- Right column filler -->
                    </td>
                </tr>
                <tr>
                    <td colspan="3" class="maintable_fillercell_bottom">
                        <!-- Filler bottom cell -->
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
