using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddProductCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

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

    }
}