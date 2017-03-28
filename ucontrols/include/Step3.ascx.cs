
using QCMS_BUSSINESS;
using QCMS_BUSSINESS.Repositories;
using SMAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ucontrols_include_Step3 : System.Web.UI.UserControl
{
    public tbl_Order order=new tbl_Order();
    public ChuyenXe chuyenxe = new ChuyenXe();
    public tbl_Member member = new tbl_Member();
    public tbl_PhuongThucThanhToan method = new tbl_PhuongThucThanhToan();
    protected void Page_Load(object sender, EventArgs e)
    {
        string mave = Request.QueryString["nurl"];
        if (string.IsNullOrEmpty(mave))
        {
            dvmain.Visible = false;
            Value.ShowMessage(ltrError, ErrorMessage.NoTransaction, AlertType.ERROR);
        }
        else
        {
            this.order = new OrderRepository().SearchFor(o => o.Order_Code == mave).SingleOrDefault();
            if (order != null)
            {
                this.chuyenxe = new ChuyenXeRepository().Find(order.MaChuyenXe.Value);
                if (chuyenxe != null)
                {
                    chuyenxe.Xe = new XeRepository().Find(chuyenxe.MaXe.Value);
                    if (chuyenxe.Xe != null)
                    {
                        chuyenxe.Xe.NhaXe1 = new NhaxeRepository().Find(chuyenxe.Xe.Nhaxe.Value);
                    }
                }
                if (order.Order_Account.HasValue)
                {
                    this.member = new MemberRepository().Find(order.Order_Account.Value);
                }
                this.method = new MethodRepository().Find(order.Order_CheckOutMethod.Value);
            }
            else
            {
                dvmain.Visible = false;
                Value.ShowMessage(ltrError, ErrorMessage.NoVertification, AlertType.ERROR);
            }
        }
    }
}