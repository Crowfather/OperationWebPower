using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnCreate_Click(object sender, EventArgs e) {

        string categoryName = tbCategoryName.Text;

        if (categoryName.Length > 0) {

            System.Data.SqlClient.SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                if (DatabaseHelper.AddMainCategory(sqlconn, categoryName)) {
                    Response.Redirect("Category.aspx");
                }
                else {
                    lCreateStatus.Text = "This category already exist";
                    lCreateStatus.Visible = true;
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }
        else {
            lCreateStatus.Text = "Please enter a category name";
            lCreateStatus.Visible = true;
        }
    }
}