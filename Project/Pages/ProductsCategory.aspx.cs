using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_ProductsCategory : System.Web.UI.Page {
    private static string[] datacat = { };
    private static string[] gamecat = { };
    private static string[] levelcat = { };
    private static string[] logocat = { };
    private static string[] productcat = { "SolidWorks" };
    private static string[] uxcat = { };


    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            MainContent.InnerText = "Products --- Category: " + Request.QueryString["category"] + " --- SubCat: " + Request.QueryString["subcat"];
        }
    }
}