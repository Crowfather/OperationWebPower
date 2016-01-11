<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Project.Product" %>

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
    <form id="form1" runat="server">
        <div id="Container">
        <Top:TopMenu ID="TopMenu" runat="server" />
        <div id="LeftFiller"></div>
        <div id="RightFiller"></div> 
        <div id="MainContent">
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
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <!-- Special case: share section cell -->
                                <td>
                                    <div id="general_product_share">
                                        <!-- TODO: Add share components here -->
                                        <!-- TO CROW: Insert share stuff here! -->
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
