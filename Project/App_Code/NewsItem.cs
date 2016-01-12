using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NewsItem
/// </summary>
public class NewsItem
{
    string title;
    string text;
    string picturePath;

    public NewsItem(string title, string text, string picturePath) {
        this.title = title;
        this.text = text;
        this.picturePath = picturePath;
    }

    public string Title {
        get {
            return title;
        }
        set {
            title = value;
        }
    }

    public string Text {
        get {
            return text;
        }
        set {
            text = value;
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
}