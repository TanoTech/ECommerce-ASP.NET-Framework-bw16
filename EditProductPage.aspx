<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="EditProductPage.aspx.cs" Inherits="BW16C.EditProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/EditProductPage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Modifica Prodotto</h1>
            <div class="product">
                <asp:Label ID="lblProductId" runat="server" Visible="false"></asp:Label>
                <div class="containerImg">
                    <asp:Image class="img" ID="imgProduct" runat="server" />

                </div>
                <div class="details">
                    <div class="left">
                        <p>
                            Nome:
                        <asp:TextBox class="space" ID="txtProductName" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Brand:
                        <asp:TextBox class="space" ID="txtProductBrand" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Rating:
                             <asp:TextBox class="space" ID="txtProductRating" runat="server"></asp:TextBox>
                        </p>

                        <p>
                            Prezzo:
                        <asp:TextBox class="space" ID="txtProductPrice" runat="server"></asp:TextBox>
                        </p>
                    </div>
                    <div class="right">
                        <p>
                            URL Immagine:
                        <asp:TextBox class="space" ID="txtImgUrl" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Dettagli:
                            <asp:TextBox class="space" ID="txtProductDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </p>
                        <p>
                            Categoria:
                        <asp:TextBox ID="txtProductCategory" runat="server"></asp:TextBox>
                        </p>
                    </div>
                </div>
            </div>
            <div class="btn1">
                <asp:Button ID="btnSave" runat="server" Text="Salva Modifiche" OnClick="btnSave_Click" CssClass="btn" />
                </div>
    </div>
</asp:Content>