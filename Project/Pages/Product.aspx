<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Project.Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project - Product</title>
    <link rel="stylesheet" type="text/css" href="../Styles/Product.css" />
    <script type="text/javascript" src="../Scripts/Product.js"></script>
</head>
<body>
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
                        <!-- Product section table -->
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
                                    <!-- Filler -->
                                </td>
                            </tr>
                            <tr>
                                <!-- Content cell -->
                                <!-- TODO: Set colspan to the number of tabs + 1 (for extra space cell) -->
                                <td colspan="6" id="productsection_contentcell">
                                    <table id="productsection_contenttable">
                                        <tr>
                                            <td>
                                                <!-- Logotype -->
                                                <!-- DATABASE: Fetch the product logotype image from the database -->
                                                <img id="content_logoimg" src="../Resources/Img/placeholder-logo.png" alt="Product Logo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <!-- Title -->
                                                <!-- DATABASE: Fetch the product name from the database -->
                                                <h1>Title</h1>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="productsection_contenttextcell">
                                                <!-- Text -->
                                                <!-- DATABASE: Fetch the product info text from the database -->
                                                <h6>Placeholder content text. Placeholder content text. Placeholder content text. Placeholder content text.
                                                Placeholder content text. Placeholder content text. Placeholder content text. Placeholder content text.
                                                Placeholder content text. Placeholder content text. Placeholder content text. Placeholder content text.</h6>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table> <!-- Product section table end -->
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
            </table> <!-- Container table end -->
        </div>
    </form>
</body>
</html>
