<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="BW16C.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dettagli Prodotto</title>    
    <link rel="stylesheet" type="text/css" href="Styles/ProductDetails.css" />
    <script type="text/javascript">
        function mostraMessaggioConferma(messaggio) {
            var modal = document.getElementById('modalMessaggio');
            var lblMessaggioConfermaModal = document.getElementById('<%= lblMessaggioConfermaModal.ClientID %>');

            lblMessaggioConfermaModal.innerHTML = messaggio;
            modal.style.display = 'block';

            setTimeout(function () {
                modal.style.display = 'none';
            }, 3000);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id="form1" runat="server">
       <div id="mainContainerDetails">
           <div id="LeftContainerDetails">
               <div id="imgContainerDetails">
                   <asp:Image ID="imgProductDetails" runat="server" CssClass="imgProductDetails"/>
               </div>
        <div id="textContainerDetails">
            <div id="topProductDetails">
                <asp:Label ID="lblProductNameDetails" runat="server" CssClass="productNameDetails"></asp:Label>
                <asp:Label ID="lblBrandDetails" runat="server" CssClass="brandDetails"></asp:Label>
                <asp:Label ID="lblRatingDetails" runat="server" CssClass="ratingDetails"></asp:Label>
                <div>
                    <span>Prezzo: </span>
                    <asp:Label ID="lblPriceDetails" runat="server" CssClass="priceDetails"></asp:Label>
                    <span>€</span>
                </div>
            </div>            
            <div id="bottomProductDetails">
                <asp:Label ID="lblCategoryDetails" runat="server" CssClass="categoryDetails"></asp:Label>
                <asp:Label ID="lblDetailsDetails" runat="server" CssClass="detailsDetails"></asp:Label>
            </div>
        </div>
    </div>
    <div id="RightContainerDetails">
        <h3 id="compraDetails">COMPRA</h3>
        <label for="ddlQuantita" id="lblQuantitàDetails">Quantità:</label>
        <asp:DropDownList ID="ddlQuantitàDetails" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQuantita_SelectedIndexChanged" CssClass="listDetails">
            <asp:ListItem Text="1" Value="1" Selected="True" CssClass="listDetails"></asp:ListItem>
            <asp:ListItem Text="2" Value="2" CssClass="listDetails"></asp:ListItem>
            <asp:ListItem Text="3" Value="3" CssClass="listDetails"></asp:ListItem>
            <asp:ListItem Text="4" Value="4" CssClass="listDetails"></asp:ListItem>
            <asp:ListItem Text="5" Value="5" CssClass="listDetails"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <label for="lblPrezzoTotale">Prezzo Totale:</label>
        <asp:Label ID="lblPrezzoTotaleDetails" runat="server" Text="" CssClass="prezzoTotaleDetails"></asp:Label>
        <br />
        <asp:Button ID="btnAggiungiAlCarrelloDetails" runat="server" Text="Aggiungi al Carrello" CssClass="btnAggiungiAlCarrelloDetails" OnClick="btnAggiungiAlCarrelloDetails_Click"/>
        <br />
        <div id="modalMessaggio" class="modalMessaggio">
            <div class="modalMessaggio-content">
                <asp:Label ID="lblMessaggioConfermaModal" runat="server" Text="" CssClass="messaggioConfermaModal"></asp:Label>
            </div>
        </div>
</div>
</div>
</form>
    
</asp:Content>
