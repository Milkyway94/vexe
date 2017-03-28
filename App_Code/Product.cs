using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string ShortDetail { get; set; }
    public string Description { get; set; }
    public double Price { get; set;}
    public int isHot { get; set; }
    public string Avatar { get; set; }
    public int CateID { get; set; }
    public string SKU { get; set; }
    public int Status { get; set; }
    public string Title { get; set; }
    public string prStatus { get; set; }
    public double salePrice { get; set; }
    public Product(int ID, string Name, string Url, string ShortDetail, string Description, double Price, int isHot, string Avatar, int CatID, string Title, string prStatus, double salePrice)
    {
        this.CateID = CatID;
        this.ID = ID;
        this.Name = Name;
        this.Url = Url;
        this.ShortDetail = ShortDetail;
        this.Description = Description;
        this.Price = Price;
        this.isHot = isHot;
        this.Avatar = Avatar;
        this.Title = Title;
        this.prStatus = prStatus;
        this.salePrice = salePrice;
    }
    public Product() { }
}