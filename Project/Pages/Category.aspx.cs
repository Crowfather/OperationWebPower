using System;
using System.Web.UI.WebControls;

namespace Project {
    public partial class Category : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if((bool)Session["admin"]) {

            //}

            /*<asp:Table ID="CategoryMenu" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass="CategoryMenuCell">
                            <a href="./Categories/Design.aspx">
                                <asp:Panel CssClass="CategoryMenuCellDiv CategoryMenuCellDivLeft" runat="server">
                                    <h1>Design</h1>
                                </asp:Panel>
                            </a>
                            <asp:Button CssClass="CategoryMenuCellDel" OnPreRender="CategoryMenuCellDel_PreRender" Text="X" runat="server" />
                    </asp:TableCell>*/

            string[] cats = { "Design", "Music", "Programming", "Economy" };



        }

        protected void CategoryMenuCellDel_PreRender(object sender, EventArgs e) {
            /*Fixa om när vi har fungerande inloggning!
                FIXA IN I DÄR CAT-KNAPPARNA SKAPAS ISTÄLLET!
            */

            /*if(Session["admin"] == null) {
                ((Panel)sender).Attributes.Add("display", "none");
            }*/
            ((Button)sender).Visible = true;
        }
    }
}