using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_Categories_SubCategories : System.Web.UI.Page {
    //private static string[] designcats = { "Data Design", "Game Design", "Level Design", "Logo Design", "Product Design", "UX Design" };
    private static List<string> cats;// = new List<string>(designcats);

    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                cats =  DatabaseHelper.GetSubCategories(sqlconn, Request.QueryString["category"]);

                if (cats == null) {
                    // TODO handle error
                }

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
            
            //cats = new List<string>(designcats);
        }

        CreateSubCatTable(cats);
    }

    /*
        The function called by the Delete-buttons.
        (Registers as a trigger on the updatepanel (AJAX))
    */
    protected void DelClick(object sender, EventArgs e) {
        //Remove category (get text of category associated with the pressed X-button)
        string toremove = ((HtmlGenericControl)((Button)sender).Parent.Controls[0]).InnerText;
        cats.Remove(toremove);

        SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
        if (sqlconn != null) {
            DatabaseHelper.RemoveSubCategory(sqlconn, Request.QueryString["category"], toremove);

            DatabaseHelper.CloseDatabase(sqlconn);
        }
        else {
            // TODO display database error
        }

        CreateSubCatTable(cats);

        UpdatePan.Update();
    }

    /*
        The function called by the Add-button.
        (Registers as a trigger on the updatepanel (AJAX))
    */
    protected void AddClick(object sender, EventArgs e) {


        UpdatePan.Update();
    }

    private void CreateSubCatTable(List<string> cats) {
        int i = 0;

        if(SubCatMenu.Controls.Count > 0) {
            SubCatMenu.Controls.Clear();
        }
        TableRow tr = null;
        TableCell td = null;
        
        for(i = 0; i < cats.Count; ++i) {
            if((i % 3) == 0) { //3 per row
                if(tr != null) {
                    SubCatMenu.Controls.Add(tr); //Add filled row
                }
                tr = new TableRow();
            }
            td = new TableCell();
            td.CssClass = "SubCatMenuCell";
            HtmlAnchor ha = new HtmlAnchor();
            //ha.HRef = "./Categories/Design/" + cats[i] + ".aspx";
            ha.HRef = "ProductsCategory.aspx?category=" + Request.QueryString["category"] + "&subcat=" + cats[i];
            Panel pan = new Panel();
            pan.CssClass = "SubCatMenuCellDiv";
            HtmlGenericControl hgc = new HtmlGenericControl("h1");
            hgc.InnerText = cats[i];
            pan.Controls.Add(hgc);
            //---X delete button---
            if (Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
                Button btn = new Button();
                btn.ID = "SubCatMenuCellDelBtn" + i;
                btn.CssClass = "SubCatMenuCellDel";
                btn.Text = "X";
                btn.Click += DelClick;
                btn.OnClientClick = "return YesNo()";
                //---Register Ajax trigger---
                AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                trig.ControlID = btn.UniqueID;
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
            while((i % 3) != 0) { //Not an even 3 row -> Add extra empty cell(s)
                td = new TableCell();
                td.CssClass = "SubCatMenuCell";
                tr.Controls.Add(td);
                ++i;
            }
            SubCatMenu.Controls.Add(tr); //Add the last row
        }

        //---ADD +ADD BUTTON---
        if(Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
            //If logged in as admin -> add +ADD button
            Button btn = new Button();
            btn.ID = "CategoryMenuCellAdd";
            btn.Text = "+";
            btn.Click += AddClick;
            //---Register Ajax trigger---
            AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
            trig.ControlID = btn.UniqueID;
            trig.EventName = "Click";
            UpdatePan.Triggers.Add(trig);
            //---------------------------
            //td.Controls.Add(btn);
            MainContent.Controls.Add(btn);
        }
        //---------------------
    }
}
