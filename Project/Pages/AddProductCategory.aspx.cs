using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddProductCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ReloadProducts();
        }
    }

    protected void btnAddProduct_Click(object sender, EventArgs e) {
        int index = choseProductDownList.SelectedIndex;

        if (index != -1) {

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {



                string categoryName = Request.QueryString["category"];
                string subCategoryName = Request.QueryString["subcat"];
                string productName = choseProductDownList.Text;

                // Is a category specified ?
                if (categoryName != null && categoryName.Length > 0 && subCategoryName != null && subCategoryName.Length > 0) {
                    if (DatabaseHelper.AddProductCategory(sqlconn, categoryName, subCategoryName, productName)) {
                        lAddStatus.Text = "Product was added!";
                        lAddStatus.Visible = true;

                        List<string> products = DatabaseHelper.GetProductsNotInCategory(sqlconn, categoryName, subCategoryName);

                        if (products == null) {
                            choseProductDownList.DataSource = new List<string>();
                            choseProductDownList.DataBind();
                        }
                        else {
                            choseProductDownList.DataSource = products;
                            choseProductDownList.DataBind();
                        }
                    }
                    else {
                        lAddStatus.Text = "Couldn't add. Product was already added!";
                        lAddStatus.Visible = true;
                    }
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }
        else {
            lAddStatus.Text = "Choose a product!";
            lAddStatus.Visible = true;
        }
    }

    protected void btnCreateProduct_Click(object sender, EventArgs e) {

        string productName = tbProductName.Text;
        string description = tbDescription.Text;
        string productText = tbProductText.Text;
        string contentText = tbContentText.Text;
        string systemrequirements = tbSystemRequirements.Text;

        if (fileUploadControl.HasFile && productName.Length > 0 && description.Length > 0 && productText.Length > 0 &&
            contentText.Length > 0 && systemrequirements.Length > 0) {

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {
                // test product name uniqueness
                if (!DatabaseHelper.ProductExist(sqlconn, productName)) {

                    try {

                        string picturePath = "/Resources/ProductImages/" + productName + Path.GetExtension(fileUploadControl.FileName);

                        fileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Resources/ProductImages/") + productName + Path.GetExtension(fileUploadControl.FileName));

                        if (DatabaseHelper.CreateProduct(sqlconn, productName, picturePath, description, productText, contentText, systemrequirements)) {
                            ReloadProducts();
                        }

                        lUploadStatus.Visible = false;
                    }
                    catch (Exception ex) {
                        lUploadStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        lUploadStatus.Visible = true;
                    }
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
        }
        else {
            // ERROR
        }
    }

    void ReloadProducts() {
        string categoryName = Request.QueryString["category"];
        string subCategoryName = Request.QueryString["subcat"];

        if (categoryName != null && categoryName.Length > 0 && subCategoryName != null && subCategoryName.Length > 0) {

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                List<string> products = DatabaseHelper.GetProductsNotInCategory(sqlconn, categoryName, subCategoryName);

                if (products == null) {
                    choseProductDownList.DataSource = new List<string>();
                    choseProductDownList.DataBind();
                }
                else {
                    choseProductDownList.DataSource = products;
                    choseProductDownList.DataBind();
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }
        else {
            // Category or subcategory not set
            // TODO database error
        }
    }
}