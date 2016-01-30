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
    string picturePath;
    string description;

    public ProductCategoryItem(string productName, string picturePath, string description) {
        this.productName = productName;
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