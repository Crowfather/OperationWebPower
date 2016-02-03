/*  */
// http://stackoverflow.com/questions/2276961/is-there-for-window-onload-in-javascript?rq=1
function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    }
    else {
        window.onload = function () {
            oldonload();
            func();
        }
    }
}

addLoadEvent(topmenuload);


/* OnLoad */
function topmenuload() {
    //Give all the menu cells onclick events
    var menucats = document.getElementsByClassName("MenuCell");
    for (i = 0; i < menucats.length; ++i) {
        menucats[i].onclick = menuclick;
    }
    var menuclicked = document.getElementsByClassName("MenuCellClicked");
    for (i = 0; i < menuclicked.length; ++i) { //Should only be 1, but you never know...
        menuclicked[i].onclick = menuclick;
    }
    document.getElementById("MenuLogo").onclick = menuclick;
    
    if (typeof (Storage) !== "undefined") {
        //Storage exists
        if (sessionStorage.getItem("menuchoice")) {
            var choice = sessionStorage.getItem("menuchoice");
            document.getElementById(choice).setAttribute("class", "MenuCellClicked");
        }
        else {
            //Set Current page
            var current = window.location.href;
            var split = current.split("/");
            current = split[split.length - 1].split(".")[0];
            //alert(current); //VARFÖR KÖRS INTE VID VARJE SIDLADDNING?!?
            switch (current) {
                /*case "Default": //Home (Use default case instead!)
                    document.getElementById("MenuHomeCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuHomeCell");
                    break;*/
                case "Category": //Category
                    document.getElementById("MenuCategoryCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuCategoryCell");
                    break;
                case "Community": //Community
                    document.getElementById("MenuCommunityCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuCommunityCell");
                    break;
                case "AboutUs": //About Us
                    document.getElementById("MenuAboutUsCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuAboutUsCell");
                    break;
                case "ContactUs": //Contact Us
                    document.getElementById("MenuContactUsCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuContactUsCell");
                    break;
                default: //Home
                    document.getElementById("MenuHomeCell").setAttribute("class", "MenuCellClicked");
                    sessionStorage.setItem("menuchoice", "MenuHomeCell");
            }

            //Set Home (default)
            //document.getElementById("MenuHomeCell").setAttribute("class", "MenuCellClicked");
            //sessionStorage.setItem("menuchoice", "MenuHomeCell");
        }
    }
}

/* OnClick */
function menuclick() {
    //Unclick
    var menuclicked = document.getElementsByClassName("MenuCellClicked");
    for (i = 0; i < menuclicked.length; ++i) { //Should only be 1, but you never know...
        menuclicked[i].setAttribute("class", "MenuCell");
    }
    
    //Changed the clicked one's class to clicked
    if (this.id !== "MenuLogo") {
        this.setAttribute("class", "MenuCellClicked");
        sessionStorage.setItem("menuchoice", this.id);
    }
    else { //Logo was clicked - Set back to Home
        document.getElementById("MenuHomeCell").setAttribute("class", "MenuCellClicked");
        sessionStorage.setItem("menuchoice", "MenuHomeCell");
    }
    
}
