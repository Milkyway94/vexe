using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
/// 
public class ShoppingCarts
{
    public static List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
    public static double Promote;
    public static string Code;
    public static void AddItem(int productId, int quantity = 1)
    {
        List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];

        if (cart != null)
        {
            var list = cart;
            if (list.Exists(o => o.Product.ID == productId))
            {
                foreach (var item in list)
                {
                    if (item.Product.ID == productId)
                    {
                        item.Quantity += quantity;
                    }
                }
            }
            else
            {
                var item = new CartItem();
                //item.Product = ProductControl.GetProductByID(productId);
                item.Quantity = quantity;
                list.Add(item);
            }

        }
        else
        {
            var item = new CartItem();
            //item.Product = ProductControl.GetProductByID(productId);
            item.Quantity = quantity;
            var list = new List<CartItem>();
            list.Add(item);
            cart = list;
        }
        HttpContext.Current.Session["Cart"] = cart;
    }
    public static string GetCart()
    {
        //List<CartItem> lst = HttpContext.Current.Session["Cart"] != null ? (List<CartItem>)HttpContext.Current.Session["Cart"] : new List<CartItem>();
        string str = "";
        //str += "[";
        //foreach (var item in lst)
        //{
        //    double price = double.Parse(item.Product.Price.ToString());
        //    //double sale = double.Parse(item.Product.PriceSale.ToString());
        //    double saleprice = price - (price * sale / 100);
        //    str += "{";
        //    str += "\"ID\":\"" + item.Product.ID + "\",";
        //    str += "\"Image\":\"" + item.Product.Avatar + "\",";
        //    str += "\"SKU\":\"" + item.Product.SKU + "\",";
        //    str += "\"Name\":\"" + item.Product.Name + "\",";
        //    str += "\"Price\":" + price + ",";
        //    str += "\"Sale\":" + sale + ",";
        //    str += "\"SalePrice\":" + saleprice + ",";
        //    str += "\"ID\":" + item.Product.ID + ",";
        //    str += "\"Quantity\":" + item.Quantity + ",";
        //    if (item.Product.PriceSale == 0)
        //    {
        //        str += "\"Total\":" + item.Quantity * price;
        //    }
        //    else
        //    {
        //        str += "\"Total\":" + item.Quantity *saleprice;
        //    }
        //    if (lst.FindIndex(o => o.Product.ID == item.Product.ID) == lst.Count - 1)
        //        str += "}";
        //    else
        //    {
        //        str += "},";
        //    }
        //}
        //str += "]";

        return str;

    }
    public static string GetCount()
    {
        if (HttpContext.Current.Session["Cart"] == null)
        {
            return "0";
        }
        else
        {
            List<CartItem> lst = (List<CartItem>)HttpContext.Current.Session["Cart"];
            return lst.Count.ToString();
        }


    }
    public static string GetTotal()
    {
        List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
        double total = 0;
        if (cart == null)
        {
            return "0";
        }
        else
        {
            foreach (var item in cart)
            {
                double price = double.Parse(item.Product.Price.ToString());
                //double sale = double.Parse(item.Product.PriceSale.ToString());
                double sale = 0;
                double saleprice = price - (price * sale / 100);
                if (saleprice == 0)
                {
                    total += price * item.Quantity;
                }
                else
                {
                    total += saleprice * item.Quantity;
                }
            }
        }
        return total.ToString();
    }
    public static void RemoveCartItem(int productId)
    {
        List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
        if (cart != null)
        {
            foreach (var item in cart)
            {
                if (item.Product.ID == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            HttpContext.Current.Session["Cart"] = cart;
        }
    }
    public void SubQuan(int productId)
    {
        List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
        if (cart != null)
        {
            foreach (var item in cart)
            {
                if (item.Product.ID == productId)
                {
                    if (item.Quantity > 0)
                    {
                        item.Quantity -= 1;
                    }
                    break;
                }
            }
        }
    }
    public static string UpdateQuantity(int pid, int quan)
    {
        List<CartItem> cart = (List<CartItem>)HttpContext.Current.Session["Cart"];
        if (cart != null)
        {
            foreach (var item in cart)
            {
                if (item.Product.ID == pid)
                {
                    item.Quantity = quan;
                }
            }
        }
        return GetCart();
    }
}
