using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project {
    public partial class Category : System.Web.UI.Page {
        private static string[] defaultcats = { "Design", "Music", "Programming", "Economy"/*, "Cat1", "Cat2"*/ };
        private static List<string> cats = new List<string>(defaultcats);
        private static int count = 0;
        
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                cats = new List<string>(defaultcats); //FIXA in hämta från databas här!

                //CreateCategoryTable(cats);
                
                //MainContent.Controls.Add(tbl); //Moved into UpdatePanel instead!
            }

            /*if(ScriptMan.IsInAsyncPostBack) {
                CreateCategoryTable(cats);
            }*/

            /*
                Fixa????
                Blir dubbelkallning då tabellen skapas om både här och och i DelClick()
                (Page_Load kallas även vid uppdatering utav en UpdatePanel då det blir en POST-back)
                Om jag kallade på CreateCategoryTable() på bara ena utav ställena så blev det oresponsivt
                (t.ex. uppdaterades inte på första försöket så man fick lov att trycka flera gånger och att det inte gick att ta bort den allra sista kategorin alls)
            */
            CreateCategoryTable(cats);
        }

        /*
            The function called by the Delete-buttons.
            (Registers as a trigger on the updatepanel (AJAX))
        */
        protected void DelClick(object sender, EventArgs e) {
            //Remove category (get text of category associated with the pressed X-button)
            string toremove = ((HtmlGenericControl)((Button)sender).Parent.Controls[0].Controls[0].Controls[0]).InnerText;
            cats.Remove(toremove);
            
            /*
                Fixa????
                Blir dubbelkallning då tabellen skapas om både här och och i Page_Load()
                (Page_Load kallas även vid uppdatering utav en UpdatePanel då det blir en POST-back)
                Om jag kallade på CreateCategoryTable() på bara ena utav ställena så blev det oresponsivt
                (t.ex. uppdaterades inte på första försöket så man fick lov att trycka flera gånger och att det inte gick att ta bort den allra sista kategorin alls)
            */
            CreateCategoryTable(cats);
            
            //Fixa in signlera databas att ta bort kategori osv. ...?
            //(Ta bort mappar/.aspx filer ?)
            //Fixa om till hämta från databas!

            UpdatePan.Update();
        }

        private void CreateCategoryTable(List<string> cats) {
            int i = 0;

            if(CategoryMenu.Controls.Count > 0) {
                CategoryMenu.Controls.Clear();
            }
            TableRow tr = null;
            TableCell td = null;

            count++;
            //cats[0] = count.ToString();

            for(i = 0; i < cats.Count; ++i) {
                if((i % 2) == 0) { //Every other
                    if(tr != null) {
                        CategoryMenu.Controls.Add(tr); //Add filled row
                    }
                    tr = new TableRow();
                }
                td = new TableCell();
                td.CssClass = "CategoryMenuCell";
                HtmlAnchor ha = new HtmlAnchor();
                //ha.HRef = "./Categories/" + cats[i] + ".aspx";
                ha.HRef = "SubCategories.aspx?category=" + cats[i];
                Panel pan = new Panel();
                pan.CssClass = "CategoryMenuCellDiv";
                HtmlGenericControl hgc = new HtmlGenericControl("h1");
                hgc.InnerText = cats[i];
                pan.Controls.Add(hgc);
                ha.Controls.Add(pan);
                td.Controls.Add(ha);
                //---X delete button---
                if(Session["admin"] == null) { //FIXA OM NÄR VI FIXAT IN RIKTIG INLOGGNING
                    Button btn = new Button();
                    btn.ID = "CategoryMenuCellDelBtn" + i;
                    btn.CssClass = "CategoryMenuCellDel";
                    btn.Text = "X";
                    btn.Click += DelClick;
                    btn.OnClientClick = "return YesNo()";
                    //---Register Ajax trigger---
                    AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                    trig.ControlID = btn.UniqueID;
                    trig.EventName = "Click";
                    UpdatePan.Triggers.Add(trig);
                    //---------------------------
                    td.Controls.Add(btn);
                }
                //---------------------
                tr.Controls.Add(td);
            }
            if(tr != null) { //Just incase it didnt loop
                if((i % 2) != 0) { //Uneven -> Add extra empty cell
                    td = new TableCell();
                    td.CssClass = "CategoryMenuCell";
                    tr.Controls.Add(td);
                }
                CategoryMenu.Controls.Add(tr); //Add the last row
            }
        }
    }
}