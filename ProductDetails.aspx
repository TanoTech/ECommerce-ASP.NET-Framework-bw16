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
            }, 2000);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContainerDetails">
           <div id="LeftContainerDetails">
               <div id="imgContainerDetails">
                   <asp:Image ID="imgProductDetails" runat="server" CssClass="imgProductDetails"/>
               </div>
        <div id="textContainerDetails">
            <div id="topProductDetails">
                <asp:Label ID="lblProductNameDetails" runat="server" CssClass="productNameDetails"></asp:Label>
                <asp:Label ID="lblBrandDetails" runat="server" CssClass="brandDetails"></asp:Label>
                <div id="containerStarsDetails">
                    <asp:Label ID="lblRatingDetails" runat="server" CssClass="ratingDetails"></asp:Label>
                    <div id="starRating" runat="server" class="star-rating"></div>
                </div>                
                <div>
                    <span class="spanDetails">Prezzo: </span>
                    <asp:Label ID="lblPriceDetails" runat="server" CssClass="priceDetails"></asp:Label>
                    <span class="spanDetails">€</span>
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
            <asp:ListItem Text="1" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
        </asp:DropDownList>
        
        <label for="lblPrezzoTotale" id="lblPrezzoTotale">Prezzo Totale:</label>
        <asp:Label ID="lblPrezzoTotaleDetails" runat="server" Text="" CssClass="prezzoTotaleDetails"></asp:Label>
        
        <asp:Button ID="btnAggiungiAlCarrelloDetails" runat="server" Text="AGGIUNGI AL CARRELLO" CssClass="btnAggiungiAlCarrelloDetails" OnClick="btnAggiungiAlCarrelloDetails_Click"/>
        
        <div id="modalMessaggio" class="modalMessaggio">
            <div class="modalMessaggio-content">
                <asp:Label ID="lblMessaggioConfermaModal" runat="server" Text="" CssClass="messaggioConfermaModal"></asp:Label>
            </div>
        </div>
    </div>
</div> 
</asp:Content>