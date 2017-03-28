using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderList
/// </summary>
public class OrderList
{
    public int OrderID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public double Total { get; set; }
    //public List<tbl_OrderDetail> OrderDetail { get; set; }
}