<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Carrello2.aspx.cs" Inherits="BW16C.Carrello2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/StileCarrello.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contenitoreCarrello" runat="server">
        <div id="contenitoreTitoloCard">
            <div id="titolo">
                <h1>CARRELLO</h1>
            </div>
            <div>
                <asp:Literal ID="ltlCarrello" runat="server"></asp:Literal>
            </div>
        </div>
        <div id="contenitoreTotale">
            <h3>TOTALE CARRELLO:</h3>
            <asp:Literal ID="ltlTotaleCarrello" runat="server"></asp:Literal>
            <asp:Button CssClass="btnSvuota" ID="Button1" runat="server" Text="Svuota il carrello" OnClick="RimuoviTutti_Click" />
            <asp:Button CssClass="btnProcediPagamento" ID="btnProcediPagamento" runat="server" Text="Procedi al pagamento" OnClick="btnProcediPagamento_Click" />
        </div>
    </div>
</asp:Content>