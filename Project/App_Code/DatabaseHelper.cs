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

    /*
    public static int addPreReq(SqlConnection sqlconn, string cc, string preReqcc) {
        SqlCommand query = new SqlCommand("InsertCoursePreReqs", sqlconn);
        query.Parameters.Add("@cc", SqlDbType.NChar);
        query.Parameters["@cc"].Value = cc;
        query.Parameters.Add("@preReqcc", SqlDbType.NChar);
        query.Parameters["@preReqcc"].Value = preReqcc;
        try {
            query.CommandType = CommandType.StoredProcedure;
            query.ExecuteNonQuery();
            return 1;
        }
        catch {
            return 0;
        }
    }
    */

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
}