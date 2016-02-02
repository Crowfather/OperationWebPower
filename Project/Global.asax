<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(object sender, EventArgs e) {
        //Code that runs when a request is received.
        //NOTE: This is run on ALL requests!

        //http://weblogs.asp.net/scottgu/tip-trick-url-rewriting-with-asp-net
        //http://www.dotnetperls.com/rewritepath
        //http://thesitedoctor.co.uk/blog/beware-contextrewritepath-does-not-end-the-current-execution-path/
        
        if(Request.Path.Contains(".aspx")) { //FILTER: Only on page-requests
            string path = Request.Path;

            //Check if url-path does not include /Pages/ and include it if it does 
            if(!path.Contains("Default.aspx") && !path.Contains("/Pages/")) {
                Context.RewritePath(path.Insert(path.IndexOf("/"), "/Pages/"));
            }
        }

        //Fixa in Category/SubCategory/Product ??!?

    }

    /*void Application_AuthenticateRequest(object sender, EventArgs e) {

    }*/

</script>
