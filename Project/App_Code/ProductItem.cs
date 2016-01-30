using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductItem
/// </summary>
public struct ProductItem
{
	string productName;
    string picturePath;
    string productText;
    string contentText;
    string systemRequirementsText;

    public ProductItem(string productName, string picturePath, string productText, string contentText, string systemRequirementsText) {
        this.productName = productName;
        this.picturePath = picturePath;
        this.productText = productText;
        this.contentText = contentText;
        this.systemRequirementsText = systemRequirementsText;
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

    public string ProductText {
        get {
            return productText;
        }
        set {
            productText = value;
        }
    }

    public string ContentText {
        get {
            return contentText;
        }
        set {
            contentText = value;
        }
    }

    public string SystemRequirementsText {
        get {
            return systemRequirementsText;
        }
        set {
            systemRequirementsText = value;
        }
    }
}