using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SMAC;

    public class CartItem
    {
        public  Product Product { get; set; }
        public int Quantity { get; set; }
    }
