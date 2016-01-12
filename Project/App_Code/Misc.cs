using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Misc {
    public static string RndText() {
        int r;
        string ret = "";
        Random rnd = new Random();

        r = rnd.Next(1, 100);
        if(r < 10) {
            ret += "Visual ";
        }
        else if(r < 20) {
            ret += "Glorified ";
        }
        else if(r < 30) {
            ret += "Perosnal ";
        }
        else if(r < 40) {
            ret += "Christmas ";
        }
        else if(r < 50) {
            ret += "Super ";
        }
        else if(r < 60) {
            ret += "Microsoft ";
        }
        else if(r < 70) {
            ret += "Open ";
        }
        else if(r < 80) {
            ret += "Office ";
        }
        else if(r < 90) {
            ret += "Photo ";
        }
        else if(r < 100) {
            ret += "Free ";
        }

        r = rnd.Next(1, 100);
        if(r < 10) {
            ret += "Studio";
        }
        else if(r < 20) {
            ret += "Toolkit";
        }
        else if(r < 30) {
            ret += "Development";
        }
        else if(r < 40) {
            ret += "Suite";
        }
        else if(r < 50) {
            ret += "Word";
        }
        else if(r < 60) {
            ret += "Workplace";
        }
        else if(r < 70) {
            ret += "Editor";
        }
        else if(r < 80) {
            ret += "Browser";
        }
        else if(r < 90) {
            ret += "Chat";
        }
        else if(r < 100) {
            ret += "Maps";
        }

        return ret;
    }
}