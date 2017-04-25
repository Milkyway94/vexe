<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NhaXe.ascx.cs" Inherits="ucontrols_include_NhaXe" %>
<div class="fw kiemtrave">
    <div class="container">
        <ul class="uk-breadcrumb hi-padding">
            <asp:Literal ID="lbnav" runat="server" Text=""></asp:Literal>
        </ul>
        <div class="dsnhaxe fw" runat="server" id="lst">
            <div class="fw">
                <div class="fl">
                    <h3>Danh sách các nhà xe</h3>
                    <i>Hơn 1000 nhà xe và bên xe khắp Việt Nam</i>
                </div>
                <div class="fr">
                    <div class="uk-margin">
                        <select class="uk-select">
                            <option>Nhà xe tại Hà Nội</option>
                        </select>
                    </div>

                </div>
            </div>
            <div class="fw lstNhaXe">
                <ul class="uk-grid-small uk-child-width-1-2 uk-child-width-1-4@s uk-text-center" uk-grid>
                   <%=lstNhaxe() %>
                </ul>
            </div>
        </div>
        <div runat="server" id="detail">
            <h1 class="text-center title ">Nhà xe <%=nx.Tennhaxe %></h1>
            <p class="text-bold"><%=nx.Gioithieungan %></p>
            <p><%=nx.Gioithieuchitiet %></p>
        </div>
</div>
