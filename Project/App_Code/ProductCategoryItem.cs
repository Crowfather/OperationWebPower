using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductCategoryItem
/// </summary>
public struct ProductCategoryItem
{
    string productName;
    string subCategoryName;
    string categoryName;
    string picturePath;
    string description;

    public ProductCategoryItem(string productName, string subCategoryName, string categoryName, string picturePath, string description) {
        this.productName = productName;
        this.subCategoryName = subCategoryName;
        this.categoryName = categoryName;
        this.picturePath = picturePath;
        this.description = description;
    }

    public string ProductName {
        get {
            return productName;
        }
        set {
            productName = value;
        }
    }

    public string SubCategoryName {
        get {
            return subCategoryName;
        }
        set {
            subCategoryName = value;
        }
    }


    public string CategoryName {
        get {
            return categoryName;
        }
        set {
            categoryName = value;
        }
    }

    public string PicturePath {
        get {
            return picturePath;
        }
        set {
            picturePath = value;
        }
    }

    public string Description {
        get {
            return description;
        }
        set {
            description = value;
        }
    }
}