using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project {
    public partial class Product : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //string meh = HttpContext.Current.Request.Url.AbsolutePath;
            //localhost:10881/Project/Pages/Product.aspx
            //string meh = Request.Url.AbsoluteUri;

            Comments.Attributes["data-href"] = Request.Url.AbsoluteUri;
            face_share.Attributes["data-href"] = Request.Url.AbsoluteUri;
            //for test porpuse
            //face_share.Attributes["data-href"] = "http://imgur.com/gallery/topMQ";
            //face_share.Attributes["data-layout"] = "button";


            //twitter_dhare.Attributes["data-href"] = Request.Url.AbsoluteUri;

            SqlConnection sqlconn = DatabaseHelper.OpenDatabase(Server.MapPath("~/LoginData.txt"));
            if (sqlconn != null) {

                ProductItem item = DatabaseHelper.GetProduct(sqlconn, Request.QueryString["product"]);
                
                databind_title.InnerText = item.ProductName;
                databind_image.Src = item.PicturePath;
                databind_productText.InnerText = item.ProductText;
                databind_contentText.InnerText = item.ContentText;
                databind_systemReq.InnerHtml = item.SystemRequirementsText;

                DatabaseHelper.CloseDatabase(sqlconn);
            }
            else {
                // TODO display database error
            }
        }
    }
}