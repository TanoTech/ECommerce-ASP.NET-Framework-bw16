<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BW16C.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestione Prodotti</h1>
    <div>
        <asp:Repeater ID="rptProducts" runat="server">
            <ItemTemplate>
                <div class="card">
                    <h2><%# Eval("Nome") %></h2>
                    <p><strong>Brand:</strong> <%# Eval("Brand") %></p>
                    <p><strong>Dettagli:</strong> <%# Eval("Dettagli") %></p>
                    <p><strong>Prezzo:</strong> <%# Eval("Prezzo", "{0:C}") %></p>
                    <p><strong>Rating:</strong> <%# Eval("Rating") %></p>
                    <p><strong>Categoria:</strong> <%# Eval("Categoria") %></p>
                    <asp:Button ID="btnEdit" runat="server" Text="Modifica" CssClass="btn" CommandName="Edit" CommandArgument='<%# Eval("IdProdotto") %>' />
                    <asp:Button ID="btnDelete" runat="server" Text="Elimina" CssClass="btn" CommandName="Delete" CommandArgument='<%# Eval("IdProdotto") %>' OnClick="btnDelete_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <asp:Button ID="btnAddProduct" runat="server" Text="Aggiungi Prodotto" CssClass="btn" OnClick="btnAddProduct_Click" />
    </div>
</asp:Content>
