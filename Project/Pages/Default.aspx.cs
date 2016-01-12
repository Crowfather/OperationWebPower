using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        FillNewsTable();

        // DEBUG: Message box
        //string script = "alert(\"Method executed!\");";
        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    }

    // Dynamically fills the news table.
    private void FillNewsTable() {

        List<NewsItem> newsItems = null;

        SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
        if (sqlconn != null) {

            newsItems = DatabaseHelper.GetNews(sqlconn);

            if (newsItems == null) {
                // TODO handle error
                newsItems = new List<NewsItem>();
            }

            DatabaseHelper.CloseDatabase(sqlconn);
        }
        else {
            // TODO display database error
        }
        
        
        // DATABASE: Assign this numberOfNews variable to a number fetched from the database (stored procedure that
        // keeps track of the number of news instances stored in the database?). Replace this hardcoded assignment
        int numberOfNews = 5;

        for (int i = 0; i < newsItems.Count; i++) {
            // --- Declaration of table rows and cells for each part of this news instance --- //

            TableRow spacingRow = new TableRow();
            TableCell spacingCell = new TableCell();
            TableRow imageRow = new TableRow();
            TableCell imageCell = new TableCell();
            TableRow titleRow = new TableRow();
            TableCell titleCell = new TableCell();
            TableRow textRow = new TableRow();
            TableCell textCell = new TableCell();
            TableRow dividerRow = new TableRow();
            TableCell dividerCell = new TableCell();


            // --- Adds relevant content for this news instance in each cell respectively --- //

            // - Spacing cell - //
            InsertText(spacingCell, "<br />", "h6");

            // - Image cell - //
            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            // DATABASE: Assign to an image text fetched from the database (note: this is the text that will show instead of
            // the image if the browser doesn't support the <img> tag)
            image.DescriptionUrl = "Image";
            
            image.ImageUrl = newsItems[i].PicturePath;
            imageCell.Controls.Add(image);

            // - Title cell - //
            InsertText(titleCell, newsItems[i].Title, "h3");

            // - Text cell - //
            InsertText(textCell, newsItems[i].Text, "h6");

            // - Divider cell - //
            dividerCell.BackColor = Color.FromArgb(67, 107, 145);
            dividerCell.Height = 1;


            // --- Adds rows and (now filled) cells to the news table --- //

            // Spacing (special case: no spacing (new line) in the first (top) news instance)
            if(i != 0) {
                newstable.Rows.Add(spacingRow);
                spacingRow.Cells.Add(spacingCell);
            }
            // Image
            newstable.Rows.Add(imageRow);
            imageRow.Cells.Add(imageCell);
            // Title
            newstable.Rows.Add(titleRow);
            titleRow.Cells.Add(titleCell);
            // Text
            newstable.Rows.Add(textRow);
            textRow.Cells.Add(textCell);
            // Divider (special case: no divider in the last (bottom) news instance)
            if((i + 1) != numberOfNews) {
                newstable.Rows.Add(dividerRow);
                dividerRow.Cells.Add(dividerCell);
            }
        }
    }

    // Inserts text in a cell
    private void InsertText(TableCell cell, string text, string textTag) {
        cell.Text += CreateText(text, textTag);
    }

    // Adds together a string formatted with the proper <h> tag. Return value can be directly set as the text field for
    // site elements.
    private string CreateText(string text, string textTag) {
        return "<" + textTag + ">" + text + "</" + textTag + ">";
    }
}