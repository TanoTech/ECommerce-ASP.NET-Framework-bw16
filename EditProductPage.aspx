<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="EditProductPage.aspx.cs" Inherits="BW16C.EditProductPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modifica Prodotto</h1>
    <div>
        <asp:Label ID="lblProductId" runat="server" Visible="false"></asp:Label>
        <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
        <p>Nome: <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></p>
        <p>Brand: <asp:TextBox ID="txtProductBrand" runat="server"></asp:TextBox></p>
        <p>Dettagli: <asp:TextBox ID="txtProductDetails" runat="server" TextMode="MultiLine"></asp:TextBox></p>
        <p>Prezzo: <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox></p>
        <p>URL Immagine: <asp:TextBox ID="txtImgUrl" runat="server"></asp:TextBox></p>
        <p>Rating: <asp:TextBox ID="txtProductRating" runat="server"></asp:TextBox></p>
        <p>Categoria: <asp:TextBox ID="txtProductCategory" runat="server"></asp:TextBox></p>
        <asp:Button ID="btnSave" runat="server" Text="Salva Modifiche" OnClick="btnSave_Click" CssClass="btn" />
    </div>
</asp:Content>
