using SMAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SanPham
{
    public int _ID;

    public System.Nullable<int> _ManufacturerID { get; set; }

    public System.Nullable<int> _CatID { get; set; }

    public System.Nullable<int> _AttributesID { get; set; }

    public System.Nullable<int> _ImageID { get; set; }

    public System.Nullable<int> _ProductTypeID { get; set; }

    public string _Name { get; set; }

    public string _NameAscii { get; set; }

    public string _SKU { get; set; }

    public string _ShortDescription { get; set; }

    public string _Description { get; set; }

    public System.Nullable<int> _IsStatus { get; set; }

    public System.Nullable<int> _CreateBy { get; set; }

    public System.Nullable<int> _UpdateBy { get; set; }

    public string _SEOTitle { get; set; }

    public string _SEODescription { get; set; }

    public string _SEOKeyword { get; set; }

    public System.Nullable<decimal> _Price { get; set; }

    public System.Nullable<decimal> _PriceSale { get; set; }

    public System.Nullable<int> _Quantity { get; set; }

    public string _IsDate { get; set; }

    public System.Nullable<int> _isHot { get; set; }

    public System.Nullable<int> _lang { get; set; }

    public string _Avatar { get; set; }

    public int? _prStatus { get; set; }
    public string _status
    {
        get;set;
    }
}