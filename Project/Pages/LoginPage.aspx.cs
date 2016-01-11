using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e) {

        string username = tbUserName.Text;
        string password = tbPassword.Text;

        if (username.Length > 0 && password.Length > 0) {

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                int loginStatus = DatabaseHelper.LoginUser(sqlconn, username, password);

                // Login succedded?
                if (loginStatus != 0) {

                    Session.Add("UserLogedIn", true);
                    Session.Add("Username", username);
                    
                    // Is admin or user?
                    if(loginStatus == 1) {
                        Session.Add("Admin", false);
                    } else {
                        Session.Add("Admin", true);
                    }
                    
                    DatabaseHelper.CloseDatabase(sqlconn);
                    Response.Redirect("Default.aspx");
                }
                else {
                    // Tell the user that username or password is wrong
                    lLoginStatus.Visible = true;
                    DatabaseHelper.CloseDatabase(sqlconn);
                }
            }
            else {
                // TODO display database error
            }
        }
    }
    protected void btdDebugLoginu_Click(object sender, EventArgs e) {
        Session.Add("UserLogedIn", false);
        Session.Add("Username", "");
        Session.Add("Admin", false);
        Response.Redirect("Default.aspx");
    }
}