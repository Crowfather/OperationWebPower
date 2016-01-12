using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// A helper class containing all the functions for interfacing with the database
/// </summary>
public static class DatabaseHelper
{
    public static SqlConnection OpenDatabase(string username, string password) {
        string connString = "Data Source=www3.idt.mdh.se;Initial Catalog=mrt10002WebCourse;User ID=" + username + ";Password=" + password;
        SqlConnection sqlconn = new SqlConnection(connString);

        try {
            sqlconn.Open();
            return sqlconn;
        }
        catch {
            return null;
        }
    }

    public static SqlConnection OpenDatabase(string loginFilePath) {

        // Get SQL login data from file
        System.IO.StreamReader file =
        new System.IO.StreamReader(loginFilePath);
        string username = file.ReadLine();
        string password = file.ReadLine();

        if (username == null || password == null) {
            return null;
        }

        string connString = "Data Source=www3.idt.mdh.se;Initial Catalog=mrt10002WebCourse;User ID=" + username + ";Password=" + password;
        SqlConnection sqlconn = new SqlConnection(connString);

        try {
            sqlconn.Open();
            return sqlconn;
        }
        catch {
            return null;
        }
    }

    public static bool CloseDatabase(SqlConnection sqlconn) {
        try {
            sqlconn.Close();
            return true;
        }
        catch {
            return false;
        }
    }

    /////////
    //User
    /////////

    //Return 0 on failure
    //Return 1 on user login
    //Return 2 on admin login
    public static int LoginUser(SqlConnection sqlconn, string userName, string password) {
        SqlCommand query = new SqlCommand("SELECT dbo.func_login(@userName, @password)", sqlconn);
        query.CommandType = CommandType.Text;

        query.Parameters.Add("@userName", SqlDbType.VarChar);
        query.Parameters["@userName"].Value = userName;
        query.Parameters.Add("@password", SqlDbType.VarChar);
        query.Parameters["@password"].Value = password;

        try {
            return (int)query.ExecuteScalar();
        }
        catch {

            return 0;
        }
    }

    public static bool AddUser(SqlConnection sqlconn, string userName, string password) {
        SqlCommand query = new SqlCommand("proc_add_user", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@userName", SqlDbType.VarChar);
        query.Parameters["@userName"].Value = userName;
        query.Parameters.Add("@password", SqlDbType.VarChar);
        query.Parameters["@password"].Value = password;

        // Used to know if user was added or not
        query.Parameters.Add("@userAdded", SqlDbType.Bit).Direction = ParameterDirection.Output;

        try {
            query.ExecuteNonQuery();
            return (bool)query.Parameters["@userAdded"].Value;
        }
        catch {
            return false;
        }
    }

    // Check if the username is in use
    public static bool UserExist(SqlConnection sqlconn, string userName) {
        SqlCommand query = new SqlCommand("SELECT dbo.func_user_exist(@userName)", sqlconn);
        query.CommandType = CommandType.Text;

        query.Parameters.Add("@userName", SqlDbType.VarChar);
        query.Parameters["@userName"].Value = userName;

        try {
            return (bool)query.ExecuteScalar();
        }
        catch {
            return false;
        }
    }

    /////////
    //Category
    /////////

    // Check if the category exist
    public static bool MainCategoryExist(SqlConnection sqlconn, string categoryName) {
        SqlCommand query = new SqlCommand("SELECT dbo.func_main_category_exist(@categoryName)", sqlconn);
        query.CommandType = CommandType.Text;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = categoryName;

        try {
            return (bool)query.ExecuteScalar();
        }
        catch {
            return false;
        }
    }

    public static List<string> GetMainCategories(SqlConnection sqlconn) {

        SqlCommand query = new SqlCommand("proc_get_main_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        try {
            List<string> list = new List<string>();

            // Get the data
            var reader = query.ExecuteReader();

            while (reader.Read()) {
                list.Add(reader.GetString(0));
            }

            return list;
        }
        catch {
            return null;
        }
    }

    public static bool AddMainCategory(SqlConnection sqlconn, string mainCategoryName) {

        SqlCommand query = new SqlCommand("proc_add_main_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategoryName;

        try {
            int result = query.ExecuteNonQuery();

            if (result == -1) {
                return false;
            }
            else {
                return true;
            }
        }
        catch {
            return false;
        }
    }

    public static bool RemoveMainCategory(SqlConnection sqlconn, string mainCategoryName) {

        SqlCommand query = new SqlCommand("proc_remove_main_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategoryName;

        try {
            int result = query.ExecuteNonQuery();

            if (result == -1) {
                return false;
            }
            else {
                return true;
            } 
        }
        catch {
            return false;
        }
    }

    public static List<string> GetSubCategories(SqlConnection sqlconn, string mainCategory) {

        SqlCommand query = new SqlCommand("proc_get_sub_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategory;

        try {
            List<string> list = new List<string>();

            // Get the data
            var reader = query.ExecuteReader();

            while (reader.Read()) {
                list.Add(reader.GetString(0));
            }

            return list;
        }
        catch {
            return null;
        }
    }

    public static bool AddSubCategory(SqlConnection sqlconn, string mainCategoryName, string subCategoryName) {

        SqlCommand query = new SqlCommand("proc_add_sub_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategoryName;
        query.Parameters.Add("@subCategoryName", SqlDbType.VarChar);
        query.Parameters["@subCategoryName"].Value = subCategoryName;

        try {
            int result = query.ExecuteNonQuery();

            if (result == -1) {
                return false;
            }
            else {
                return true;
            }
        }
        catch {
            return false;
        }
    }

    public static bool RemoveSubCategory(SqlConnection sqlconn, string mainCategoryName, string subCategoryName) {

        SqlCommand query = new SqlCommand("proc_remove_sub_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategoryName;
        query.Parameters.Add("@subCategoryName", SqlDbType.VarChar);
        query.Parameters["@subCategoryName"].Value = subCategoryName;
        
        try {
            int result = query.ExecuteNonQuery();

            if (result == -1) {
                return false;
            }
            else {
                return true;
            } 
        }
        catch {
            return false;
        }
    }

    public static List<ProductCategoryItem> GetProductCategories(SqlConnection sqlconn, string mainCategoryName, string subCategoryName) {

        SqlCommand query = new SqlCommand("proc_get_product_category", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@categoryName", SqlDbType.VarChar);
        query.Parameters["@categoryName"].Value = mainCategoryName;
        query.Parameters.Add("@subCategoryName", SqlDbType.VarChar);
        query.Parameters["@subCategoryName"].Value = subCategoryName;

        try {
            List<ProductCategoryItem> list = new List<ProductCategoryItem>();

            // Get the data
            var reader = query.ExecuteReader();

            while (reader.Read()) {
                ProductCategoryItem product = new ProductCategoryItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));

                list.Add(product);
            }

            return list;
        }
        catch {
            return null;
        }
    }






    public static ProductItem GetProduct(SqlConnection sqlconn, string productName) {

        ProductItem item = new ProductItem();

        SqlCommand query = new SqlCommand("proc_get_product", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@productName", SqlDbType.VarChar);
        query.Parameters["@productName"].Value = productName;

        try {
            // Get the data
            var reader = query.ExecuteReader();

            if (reader.Read()) {
                item = new ProductItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }

            return item;
        }
        catch {
            return item;
        }
    }

    /////////
    //News
    /////////

    public static List<NewsItem> GetNews(SqlConnection sqlconn) {
        List<NewsItem> items = null;

        SqlCommand query = new SqlCommand("proc_get_news", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        try {
            items = new List<NewsItem>();

            // Get the data
            var reader = query.ExecuteReader();

            while (reader.Read()) {
                items.Add(new NewsItem(reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }

            return items;
        }
        catch {
            return items;
        }
    }

    public static bool AddNews(SqlConnection sqlconn, string title, string text, string picturePath) {
        SqlCommand query = new SqlCommand("proc_add_news", sqlconn);
        query.CommandType = CommandType.StoredProcedure;

        query.Parameters.Add("@title", SqlDbType.VarChar);
        query.Parameters["@title"].Value = title;
        query.Parameters.Add("@text", SqlDbType.VarChar);
        query.Parameters["@text"].Value = text;
        query.Parameters.Add("@picturePath", SqlDbType.VarChar);
        query.Parameters["@picturePath"].Value = text;
        
        try {
            int result = query.ExecuteNonQuery();

            if (result == -1) {
                return false;
            }
            else {
                return true;
            }
        }
        catch {
            return false;
        }
    }
}