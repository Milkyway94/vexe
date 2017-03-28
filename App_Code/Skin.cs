using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Skin
/// </summary>
public class Skin
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Url { get; set; } 
    public string Link { get; set; }
    public int Mod_Id { get; set;}
    public int status { get; set; }
    public int Pos { get; set; }
    public Skin(int ID, string Name, string Url, string Link, int Mod_ID, int status, int Pos)
    {
        this.ID = ID;
        this.Name = Name;
        this.Url = Url;
        this.Link = Link;
        this.Mod_Id = Mod_Id;
        this.status = status;
        this.Pos = Pos;
    }
    public Skin() { }
}