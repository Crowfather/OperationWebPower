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
            /*System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            // DATABASE: Assign to an image text fetched from the database (note: this is the text that will show instead of
            // the image if the browser doesn't support the <img> tag)
            image.DescriptionUrl = "Image";
            
            image.ImageUrl = FixPath(newsItems[i].PicturePath);*/
            object imgvid = GetImgVid(FixPath(newsItems[i].PicturePath));
            //object imgvid = GetImgVid(FixPath("../Resources/Img/Gear1.png"));
            //object imgvid = GetImgVid(FixPath("../Resources/Vid/vader.webm"));
            //object imgvid = GetImgVid(FixPath("https://www.youtube.com/watch?v=ytU7kgiqp1s"));
            //object imgvid = GetImgVid(FixPath("https://youtu.be/ytU7kgiqp1s"));
            if (imgvid is System.Web.UI.WebControls.Image) {
                imageCell.CssClass = "NewsImage";
                imageCell.Controls.Add((System.Web.UI.WebControls.Image)imgvid);
            }
            else if (imgvid is LiteralControl) { imageCell.Controls.Add((LiteralControl)imgvid); }
            //imageCell.Controls.Add(image);

            // - Title cell - //
            InsertText(titleCell, newsItems[i].Title, "h3");

            // - Text cell - //
            InsertText(textCell, newsItems[i].Text, "p");

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
            if((i + 1) != newsItems.Count /*numberOfNews*/) {
                newstable.Rows.Add(dividerRow);
                dividerRow.Cells.Add(dividerCell);
            }

            if(Session["Admin"] != null && Convert.ToBoolean(Session["Admin"])) {
                //Del button
                Button btn = new Button();
                btn.ID = "NewsDelBtn" + i; //ERSÄTT i MED NEWS-ID HÄR!!!!!
                btn.CssClass = "NewsDel";
                btn.Text = "X";
                btn.Click += DelClick;
                btn.OnClientClick = "return YesNo()";
                //---Register Ajax trigger---
                AsyncPostBackTrigger trig = new AsyncPostBackTrigger();
                trig.ControlID = btn.UniqueID;
                trig.EventName = "Click";
                UpdatePan.Triggers.Add(trig);
                //---------------------------
                imageCell.Controls.Add(btn);
                imageRow.Cells.Add(imageCell);

                //Edit button
                btn = new Button();
                btn.ID = "NewsEditBtn" + i; //ERSÄTT i MED NEWS-ID HÄR!!!!!
                btn.CssClass = "NewsEdit";
                btn.Text = "EDIT";
                btn.Click += EditClick;
                imageCell.Controls.Add(btn);
                imageRow.Cells.Add(imageCell);
            }

        }

        //Add button
        if (Session["Admin"] != null && Convert.ToBoolean(Session["Admin"]))
        {
            //If logged in as admin -> add +ADD button
            Button btn = new Button();
            btn.ID = "NewsAdd";
            btn.Text = "+";
            btn.Click += AddClick;
            //VART ADDA BTN!?
            gearcommunityimagecell.Controls.Add(btn);
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

    //Removes ../ from imagepaths
    private string FixPath(string path)
    {
        if (path.StartsWith("../"))
        {
            return path.Substring(3);
        }

        return path;
    }

    private object GetImgVid(string path)
    {
        object ret = GetVideo(path);
        if (ret == null) { ret = GetEmbeddedYTVideo(path); }
        if (ret == null) { ret = GetImage(path); } //Image last -> if not video or YT and errorneous path then there will atleast be the alt. text from the img-element!

        return ret;
    }

    private System.Web.UI.WebControls.Image GetImage(string path)
    {
        if (path != "")
        {
            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            image.AlternateText = "News image";
            image.ImageUrl = path;
            image.Visible = true;

            return image;
        }

        return null;
    }

    private LiteralControl GetVideo(string path)
    {
        switch (System.IO.Path.GetExtension(path))
        {
            case ".AVI":
            case ".avi":
            case ".MOV":
            case ".mov":
            case ".mp4":
            case ".MPEG":
            case ".mpeg":
            case ".MPG":
            case ".mpg":
            case ".webm":
            case ".WEBM":
                return new LiteralControl("<video width=\"350\" height=\"250\" controls><source src=\"" + path + "\">News video</video>");
        }

        return null;
    }
    
    private LiteralControl GetEmbeddedYTVideo(string path)
    {
        //HTML format
        /* <iframe width="420" height="315"
        src="http://www.youtube.com/embed/XGSy3_Czz8k?autoplay=1">
        </iframe> */
        //<iframe width="854" height="480" src="https://www.youtube.com/embed/ytU7kgiqp1s" frameborder="0" allowfullscreen></iframe>
        
        //YT Link Formats:
        //https://www.youtube.com/watch?v=ytU7kgiqp1s
        //https://youtu.be/ytU7kgiqp1s
        
        if(path.Contains(".com")) {
            return new LiteralControl("<iframe width=\"350\" height=\"250\" src=\"https://www.youtube.com/embed/" + path.Substring(path.IndexOf("?v=")).Replace("?v=", "") + "\"></iframe>");
        }
        else if (path.Contains(".be"))
        {
            return new LiteralControl("<iframe width=\"350\" height=\"250\" src=\"https://www.youtube.com/embed/" + path.Substring(path.LastIndexOf("/")) + "\"></iframe>");
        }

        return null;
    }

    //The function called by the Add-button.
    protected void AddClick(object sender, EventArgs e)
    {
        //Response.Redirect("AddCategory.aspx");
    }

    //The function called by the Edit-button
    protected void EditClick(object sender, EventArgs e)
    {
        //Get newstitle (get title of news associated with the pressed Edit-button)
        string toedit = ((Button)sender).ID.Replace("NewsEditBtn", "");
        
        //Response.Redirect(toedit);
    }

    /*
            The function called by the Delete-buttons.
            (Registers as a trigger on the updatepanel (AJAX))
    */
    protected void DelClick(object sender, EventArgs e)
    {
        //Remove news (get title of news associated with the pressed X-button)
        string toremove = ((Button)sender).ID.Replace("NewsDelBtn", "");

        SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
        if (sqlconn != null)
        {
            /*if (DatabaseHelper.RemoveMainCategory(sqlconn, toremove))
            {
                //cats.Remove(toremove);
            }*/

            DatabaseHelper.CloseDatabase(sqlconn);
        }
        else
        {
            // TODO display database error
        }

        //CreateCategoryTable(cats);

        UpdatePan.Update();
    }
}
