<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Document.ascx.cs" Inherits="ucontrols_include_Document" %>
<div class="container content">
    <asp:Label ID="lbErr" Text="" runat="server" />
    <div class="wrapper" runat="server" id="wrapper">
        <div class="col-sm-3">
            <div class="doc-sidebar">
                <h3>Nhóm tài liệu</h3>
                <ul class="doc-menu menu">
                    <asp:Literal ID="ltrDocType" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
        <div class="col-sm-9">
            <div class="row">
                <div class="hot-doc-header">
                    <h3>Tài liệu nội bộ xí nghiệp may Lạng Giang</h3>
                </div>
                <div class="hot-doc-box">
                    <div class="row doc-inside-box">
                        <div class="container">
                            <form class="form-horizontal" action="?act=search" method="post" role="form">
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="code">Số hiệu văn bản</label>
                                <div class="col-sm-4">
                                    <input type="text" name="txtCode" class="form-control" id="code">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="pwd">Tên văn bản</label>
                                <div class="col-sm-4">
                                    <input type="text" class="form-control" name="txtName" id="pwd">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-sm-2" for="txtSDate">Ban hành từ ngày</label>
                                <div class="col-sm-4">
                                    <input type="text" name="txtSDate" class="form-control datepicker" id="txtSDate">
                                </div>
                            </div>
                                <div class="form-group">
                                <label class="control-label col-sm-2" for="txtEDate">Đến ngày</label>
                                <div class="col-sm-4">
                                    <input type="text" name="txtEDate" class="form-control datepicker" id="txtEDate">
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-4">
                                    <button type="submit" class="btn btn-sm btn-primary">Tìm kiếm</button>
                                    <button type="reset" class="btn btn-sm btn-warning">Hủy</button>
                                </div>
                            </div>
                        </form>
                        </div>
                        <div class="table-responsive">
                        <table class="table tbl-doc table-responsive">
                            <thead style="height: 44px !important">
                                <tr>
                                    <th>STT</th>
                                    <th>Số hiệu</th>
                                    <th>Tên tài liệu</th>
                                    <th>Mô tả</th>
                                    <th>Ngày ban hành</th>
                                    <th>Tải về</th>
                                </tr>
                            </thead>
                            <asp:Literal ID="ltrDoc" Text="" runat="server" />
                        </table>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

