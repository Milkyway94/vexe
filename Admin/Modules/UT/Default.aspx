<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMasterPage.master" CodeFile="Default.aspx.cs" Inherits="Admin_Modules_TD_Default" %>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <h1 class="text-center"><b>DANH SÁCH ỨNG VIÊN</b></h1>
    <div class="container">
    <table class="table tbl-bordered table-condensed" id="ungtuyen">
        <thead style="height: 44px !important">
            <tr>
                <th>STT</th>
                <th>Họ tên ứng viên</th>
                <th>Số điện thoại</th>
                <th>Địa chỉ</th>
                <th>Email</th>
                <th>Ngày nộp CV</th>
                <th>Vị trí ứng tuyển</th>
                <th>File CV</th>
                <th>Duyệt</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="ltrTD" Text="" runat="server" />
        </tbody>
    </table>
        </div>
    <script type="text/javascript">
        $("#btnApprove").click(function () {
            id = CV_ID.val();
            $.ajax({
                type: "POST",
                url: "Default.aspx?act=approve",
                data: {id:id},
                success: function (response) {
                alert("");
                window.location.reload();
                }
            });
        });
    </script>
</asp:Content>
