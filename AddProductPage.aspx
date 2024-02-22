<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="AddProductPage.aspx.cs" Inherits="BW16C.AddProductPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/AddProductPage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <h1>Aggiungi Nuovo Prodotto</h1>
    </div>
    <div class="container">

        <div class="left">
            <div>
                <label for="txtNome">Nome:</label>
                <asp:TextBox class="space" ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtBrand">Brand:</label>
                <asp:TextBox class="space" ID="txtBrand" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPrezzo">Prezzo:</label>
                <asp:TextBox class="space" ID="txtPrezzo" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtRating">Rating:</label>
                <asp:TextBox class="space" ID="txtRating" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtImgUrl">URL Img:</label>
                <asp:TextBox class="space" ID="txtImgUrl" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="right">
            <label for="ddlCategoria">Categoria:</label>
            <asp:DropDownList class="space" ID="ddlCategoria" runat="server">
            </asp:DropDownList>

        </div>
        <div class="category">
            <label for="txtDettagli">Dettagli:</label>
            <div class="details">

                <asp:TextBox ID="txtDettagli" CssClass="space" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

        </div>
    </div>
    <div class="btn2">
        <asp:Button ID="btnAggiungi" runat="server" Text="Aggiungi Prodotto" CssClass="btn" OnClick="btnAggiungi_Click" />
    </div>

</asp:Content>
