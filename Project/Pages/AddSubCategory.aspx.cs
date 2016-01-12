using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddSubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string categoryName = Request.QueryString["category"];

        // Didn't pass a category?
        if (categoryName == null || categoryName.Length == 0) {
            Response.Redirect("SubCategories.aspx");
        }
        else {
            System.Data.SqlClient.SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {
                //Main category does not exist
                if (!DatabaseHelper.MainCategoryExist(sqlconn, categoryName)) {
                    Response.Redirect("SubCategories.aspx");
                }
            }
            else {
                // TODO display database error
            }
        }
    }

    protected void btnCreate_Click(object sender, EventArgs e) {

        string categoryName = Request.QueryString["category"];
        string subCategoryName = tbCategoryName.Text;

        if ((categoryName != null && categoryName.Length > 0) && subCategoryName.Length > 0) {

            System.Data.SqlClient.SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                if (DatabaseHelper.AddSubCategory(sqlconn, categoryName, subCategoryName)) {
                     Response.Redirect("SubCategories.aspx?category=" + categoryName);
                }
                else {
                    lCreateStatus.Text = "This sub category already exist";
                    lCreateStatus.Visible = true;
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }
        else {
            lCreateStatus.Text = "Please enter a sub category name";
            lCreateStatus.Visible = true;
        }
    }
}