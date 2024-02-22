<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Carrello2.aspx.cs" Inherits="BW16C.Carrello2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Carrello</h2>
        <hr />
        <asp:Repeater ID="rptCarrello" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Image ID="imgProduct" runat="server" CssClass="img-thumbnail" />
                    </div>
                    <div class="col-md-6">
                        <h4><%# Eval("Nome") %></h4>
                        <p>Prezzo: <strong><%# string.Format("{0:C}", Eval("Prezzo")) %></strong></p>
                        <p>Quantità: <strong><%# Eval("Quantita") %></strong></p>
                    </div>
                    <div class="col-md-3">
                        <p>Prezzo totale: <strong><%# string.Format("{0:C}", (Convert.ToDecimal(Eval("Prezzo")) * Convert.ToInt32(Eval("Quantita")))) %></strong></p>
                    </div>
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
        <div class="row">
            <div class="col-md-12">
                <h4>Totale: <strong><asp:Label ID="lblTotalCartPrice" runat="server"></asp:Label></strong></h4>
            </div>
        </div>
        <hr />
        <div class="row">

        </div>
    </div>
</asp:Content>
