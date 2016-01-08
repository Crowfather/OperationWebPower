window.onload = function()
{
    /* Give all the tabs onclick-events */
    document.getElementById("productsection_tab_product").onclick = productSectionTabClick;
    document.getElementById("productsection_tab_content").onclick = productSectionTabClick;
    document.getElementById("productsection_tab_rating").onclick = productSectionTabClick;
    document.getElementById("productsection_tab_sysreq").onclick = productSectionTabClick;
    document.getElementById("productsection_tab_share").onclick = productSectionTabClick;

    /* Give all the tabs mouseover-events */
    document.getElementById("productsection_tab_product").onmouseover = productSectionTabOver;
    document.getElementById("productsection_tab_content").onmouseover = productSectionTabOver;
    document.getElementById("productsection_tab_rating").onmouseover = productSectionTabOver;
    document.getElementById("productsection_tab_sysreq").onmouseover = productSectionTabOver;
    document.getElementById("productsection_tab_share").onmouseover = productSectionTabOver;

    /* Give all the tabs mouseout-events */
    document.getElementById("productsection_tab_product").onmouseout = productSectionTabReset;
    document.getElementById("productsection_tab_content").onmouseout = productSectionTabReset;
    document.getElementById("productsection_tab_rating").onmouseout = productSectionTabReset;
    document.getElementById("productsection_tab_sysreq").onmouseout = productSectionTabReset;
    document.getElementById("productsection_tab_share").onmouseout = productSectionTabReset;
}


/* OnClick */
function productSectionTabClick()
{
    /* Unselect currently selected tab */
    var tabs = document.getElementsByClassName("productsection_tab_design productsection_tab_text productsection_tab_selected");

    if (tabs.length > 0)
    {
        tabs[0].setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_unselected");

        /* Set this tab as selected */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_selected");

        /* TODO: Change what text is fetched from the database in the productsection_contenttextcell */
    }
}

/* OnMouseOver */
function productSectionTabOver()
{
    /* Change unselected tabs only */
    if (this.className == "productsection_tab_design productsection_tab_text productsection_tab_unselected")
    {
        /* Change class to "hover" */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_hover");
    }
}

/* OnMouseOut */
function productSectionTabReset()
{
    /* Change hovered tabs only */
    if (this.className == "productsection_tab_design productsection_tab_text productsection_tab_hover")
    {
        /* Reset class/unselect tab */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_unselected");
    }
}