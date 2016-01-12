
window.onload = function()
{
    /* Give all the tabs onclick-events */
    document.getElementById("productsection_tab_product").onclick = tabClick;
    document.getElementById("productsection_tab_content").onclick = tabClick;
    document.getElementById("productsection_tab_rating").onclick = tabClick;
    document.getElementById("productsection_tab_sysreq").onclick = tabClick;
    document.getElementById("productsection_tab_share").onclick = tabClick;

    /* Give all the tabs mouseover-events */
    document.getElementById("productsection_tab_product").onmouseover = tabHover;
    document.getElementById("productsection_tab_content").onmouseover = tabHover;
    document.getElementById("productsection_tab_rating").onmouseover = tabHover;
    document.getElementById("productsection_tab_sysreq").onmouseover = tabHover;
    document.getElementById("productsection_tab_share").onmouseover = tabHover;

    /* Give all the tabs mouseout-events */
    document.getElementById("productsection_tab_product").onmouseout = tabReset;
    document.getElementById("productsection_tab_content").onmouseout = tabReset;
    document.getElementById("productsection_tab_rating").onmouseout = tabReset;
    document.getElementById("productsection_tab_sysreq").onmouseout = tabReset;
    document.getElementById("productsection_tab_share").onmouseout = tabReset;

    sectionsHide();
    document.getElementById("general_product_logoimg").style.display = "inherit";
    document.getElementById("general_product_title").style.display = "inherit";
    document.getElementById("product_section_text").style.display = "inherit";
}

/* OnClick */
function tabClick()
{
    /* Unselect currently selected tab */
    var tabs = document.getElementsByClassName("productsection_tab_design productsection_tab_text productsection_tab_selected");

    if (tabs.length > 0)
    {
        tabs[0].setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_unselected");

        /* Set this tab as selected */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_selected");

        /* Hide all sections */
        sectionsHide();

        /* Display selected section */
        switch (this.id)
        {
            case "productsection_tab_product":
                document.getElementById("general_product_logoimg").style.display = "inherit";
                document.getElementById("general_product_title").style.display = "inherit";
                document.getElementById("product_section_text").style.display = "inherit";
                break;
            case "productsection_tab_content":
                document.getElementById("general_product_logoimg").style.display = "inherit";
                document.getElementById("general_product_title").style.display = "inherit";
                document.getElementById("content_section_text").style.display = "inherit";
                break;
            case "productsection_tab_rating":
                document.getElementById("general_product_rating").style.display = "inherit";
                break;
            case "productsection_tab_sysreq":
                document.getElementById("general_product_logoimg").style.display = "inherit";
                document.getElementById("general_product_title").style.display = "inherit";
                document.getElementById("sysreq_section_text").style.display = "inherit";
                break;
            case "productsection_tab_share":
                document.getElementById("general_product_share").style.display = "inherit";
                break;
        }
    }
}

/* OnMouseOver */
function tabHover()
{
    /* Change unselected tabs only */
    if (this.className == "productsection_tab_design productsection_tab_text productsection_tab_unselected")
    {
        /* Change class to "hover" */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_hover");
    }
}

/* OnMouseOut */
function tabReset()
{
    /* Change hovered tabs only */
    if (this.className == "productsection_tab_design productsection_tab_text productsection_tab_hover")
    {
        /* Reset class/unselect tab */
        this.setAttribute("class", "productsection_tab_design productsection_tab_text productsection_tab_unselected");
    }
}

/* Hide all sections */
function sectionsHide()
{
    document.getElementById("general_product_rating").style.display = "none";
    document.getElementById("general_product_share").style.display = "none";

    document.getElementById("general_product_logoimg").style.display = "none";
    document.getElementById("general_product_title").style.display = "none";
    
    document.getElementById("product_section_text").style.display = "none";
    document.getElementById("content_section_text").style.display = "none";
    document.getElementById("sysreq_section_text").style.display = "none";
}