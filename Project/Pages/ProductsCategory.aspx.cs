using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_ProductsCategory : System.Web.UI.Page {
    //private static string[] productcat = { "SolidWorks", "Firefox", "Chrome", "Photoshop", "Visual Studio", "GIMP", "Notepad", "Skype" };
    //private static List<string> cats;

    private static List<ProductCategoryItem> categories;

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            //MainContent.InnerText = "Products --- Category: " + Request.QueryString["category"] + " --- SubCat: " + Request.QueryString["subcat"];

            categories = new List<ProductCategoryItem>();

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                categories = DatabaseHelper.GetProductCategories(sqlconn, Request.QueryString["category"], Request.QueryString["subcat"]);

                if (categories == null) {
                    // TODO handle error
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }

        CreateProdsCatTable(categories);
    }

    /*
        The function called by the Delete-buttons.
        (Registers as a trigger on the updatepanel (AJAX))
    */
    protected void DelClick(object sender, EventArgs e) {
        //Remove category (get text of category associated with the pressed X-button)
        string toremove = ((HtmlGenericControl)((Button)sender).Parent.Controls[0]).InnerText;
        
        //cats.Remove(toremove);
        CreateProdsCatTable(categories);

        /*SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
        if (sqlconn != null) {
            DatabaseHelper.RemoveMainCategory(sqlconn, toremove);

            DatabaseHelper.CloseDatabase(sqlconn);
        }
        else {
            // TODO display database error
        }*/

        UpdatePan.Update();
    }


    /*
        The function called by the Add-button.
        (Registers as a trigger on the updatepanel (AJAX))
    */
    protected void AddClick(object sender, EventArgs e) {

        UpdatePan.Update();
    }

    private void CreateProdsCatTable(List<ProductCategoryItem> cats) {
        
        int i = 0;

        if(ProdsCatMenu.Controls.Count > 0) {
            ProdsCatMenu.Controls.Clear();
        }
        TableRow tr = null;
        TableCell td = null;

        //count++;
        //cats[0] = count.ToString();

        for (i = 0; i < categories.Count; ++i) {
            if((i % 4) == 0) { //Every other
                if(tr != null) {
                    ProdsCatMenu.Controls.Add(tr); //Add filled row
                }
                tr = new TableRow();
            }
            td = new TableCell();
            td.CssClass = "ProdsCatMenuCell";
            HtmlAnchor ha = new HtmlAnchor();
            ha.ID = "ProdsCatMenuCellA" + i;
            //ha.HRef = "./Categories/" + cats[i] + ".aspx";
            //ha.HRef = "ProductsCategory.aspx?category=" + Request.QueryString["category"] + "&subcat=" + cats[i];
            ha.HRef = "Product.aspx?category=" + Request.QueryString["category"] + "&subcat=" + Request.QueryString["subcat"] + "&product=" + cats[i].ProductName;
            Panel pan = new Panel();
            pan.CssClass = "ProdsCatMenuCellDiv";
            Image img = new Image();
            img.ImageUrl = cats[i].PicturePath;
            pan.Controls.Add(img);
            HtmlGenericControl hgc = new HtmlGenericControl("h1");
            hgc.InnerText = cats[i].ProductName;
            pan.Controls.Add(hgc);
            HtmlGenericControl hgc2 = new HtmlGenericControl("h2");
            
            hgc2.InnerText = cats[i].Description;
 
            //---------------------------
            pan.Controls.Add(hgc2);
            //---X delete button---
            if(Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
                Button btn = new Button();
                btn.ID = "ProdsCatMenuCellDelBtn" + i;
                btn.CssClass = "ProdsCatMenuCellDel";
                btn.Text = "X";
                btn.Click += DelClick;
                btn.OnClientClick = "return YesNo()";
                //---Register Ajax trigger---
                AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                trig.ControlID = btn.UniqueID;
                //cats[0] = btn.UniqueID;
                trig.EventName = "Click";
                UpdatePan.Triggers.Add(trig);
                //---------------------------
                pan.Controls.Add(btn);
            }
            //---------------------
            ha.Controls.Add(pan);
            td.Controls.Add(ha);
            tr.Controls.Add(td);
        }
        if(tr != null) { //Just incase it didnt loop
            while((i % 4) != 0) { //Not an even 4 row -> Add extra empty cell(s)
                td = new TableCell();
                td.CssClass = "ProdsCatMenuCell";
                tr.Controls.Add(td);
                ++i;
            }
            ProdsCatMenu.Controls.Add(tr); //Add the last row
        }
    }
}