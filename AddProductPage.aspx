<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="BW16C.AddProductPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Aggiungi Nuovo Prodotto</h1>
    <div>
        <form runat="server">
            <div>
                <label for="txtNome">Nome:</label>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtBrand">Brand:</label>
                <asp:TextBox ID="txtBrand" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtDettagli">Dettagli:</label>
                <asp:TextBox ID="txtDettagli" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div>
                <label for="txtImgUrl">URL Immagine:</label>
                <asp:TextBox ID="txtImgUrl" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPrezzo">Prezzo:</label>
                <asp:TextBox ID="txtPrezzo" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtRating">Rating:</label>
                <asp:TextBox ID="txtRating" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="ddlCategoria">Categoria:</label>
                <asp:DropDownList ID="ddlCategoria" runat="server">
                </asp:DropDownList>
            </div>
            <br />
            <asp:Button ID="btnAggiungi" runat="server" Text="Aggiungi Prodotto" CssClass="btn" OnClick="btnAggiungi_Click" />
        </form>
    </div>
</asp:Content>