using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Category : System.Web.UI.Page
    {
        //private static string[] defaultcats = { "Design", "Music", "Programming", "Economy"/*, "Cat1", "Cat2"*/ };
        private static List<string> cats;// = new List<string>(defaultcats);
        //private static int count = 0;
        
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
                if (sqlconn != null) {

                    cats = DatabaseHelper.GetMainCategories(sqlconn);

                    if (cats == null) {
                        // TODO handle error
                    }

                    DatabaseHelper.CloseDatabase(sqlconn);
                }
                else {
                    // TODO display database error
                }

                //cats = new List<string>(defaultcats);
                //CreateCategoryTable(cats);
            }

            /*if(ScriptMan.IsInAsyncPostBack) {
                CreateCategoryTable(cats);
            }*/

            CreateCategoryTable(cats);
        }

        /*
            The function called by the Delete-buttons.
            (Registers as a trigger on the updatepanel (AJAX))
        */
        protected void DelClick(object sender, EventArgs e) {
            //Remove category (get text of category associated with the pressed X-button)
            string toremove = ((HtmlGenericControl)((Button)sender).Parent.Controls[0]).InnerText;
            cats.Remove(toremove);
            
            CreateCategoryTable(cats);

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {
                DatabaseHelper.RemoveMainCategory(sqlconn, toremove);

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }

            UpdatePan.Update();
        }

        /*
            The function called by the Add-button.
            (Registers as a trigger on the updatepanel (AJAX))
        */
        protected void AddClick(object sender, EventArgs e) {


            UpdatePan.Update();
        }

        private void CreateCategoryTable(List<string> cats) {
            int i = 0;

            if (CategoryMenu.Controls.Count > 0) {
                CategoryMenu.Controls.Clear();
            }
            TableRow tr = null;
            TableCell td = null;

            //count++;
            //cats[0] = count.ToString();

            for (i = 0; i < cats.Count; ++i) {
                if ((i % 2) == 0) { //Every other
                    if (tr != null) {
                        CategoryMenu.Controls.Add(tr); //Add filled row
                    }
                    tr = new TableRow();
                }
                td = new TableCell();
                td.CssClass = "CategoryMenuCell";
                HtmlAnchor ha = new HtmlAnchor();
                ha.ID = "CategoryMenuCellA" + i;
                //ha.HRef = "./Categories/" + cats[i] + ".aspx";
                ha.HRef = "SubCategories.aspx?category=" + cats[i];
                Panel pan = new Panel();
                pan.CssClass = "CategoryMenuCellDiv";
                HtmlGenericControl hgc = new HtmlGenericControl("h1");
                hgc.InnerText = cats[i];
                pan.Controls.Add(hgc);
                //---X delete button---
                if (Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
                    Button btn = new Button();
                    btn.ID = "CategoryMenuCellDelBtn" + i;
                    btn.CssClass = "CategoryMenuCellDel";
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
            if (tr != null) { //Just incase it didnt loop
                if((i % 2) != 0) { //Uneven -> Add extra empty cell (if not logged in as admin)
                    td = new TableCell();
                    td.CssClass = "CategoryMenuCell";
                    /* NOTERA ATT DETTA BARA ÄR EN BÖRJAN FÖR +ADD KNAPPEN OCH LÅNGT IFRÅN KLART! */
                    /*if(Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
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
                        td.Controls.Add(btn);
                    }*/
                    tr.Controls.Add(td);
                }
                else if(Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
                    //If logged in -> add +ADD button AND an extra empty cell
                    CategoryMenu.Controls.Add(tr); //Add the last row
                    //tr = new TableRow();

                    //CategoryMenu.Controls.Add(tr); //Add the last row
                }
                CategoryMenu.Controls.Add(tr); //Add the last row
            }
        }
    }
}