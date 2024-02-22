<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BW16C.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/SearchPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 id="searchTitle">Search Results</h1>
    <div id="SearchPage" runat="server">
        <asp:Repeater ID="SearchRepeater" runat="server">
            <ItemTemplate>
                <div class="productCard">
                    <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                        <div class="productImg">
                            <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                        </div>
                        <div class="productTxt">
                            <h2><%# Eval("Nome") %></h2>
                            <h3><%# Eval("Brand") %></h3>
                            <div class="productPriceRating">
                                <p><%# Eval("Prezzo") %>€</p>
                                <p class="productCardRating"><%# Eval("Rating") %>/5,0</p>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>