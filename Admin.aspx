<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BW16C.Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gestione Prodotti</h1>
    <div>
        <form runat="server">
            <asp:Button ID="btnAddProduct" runat="server" Text="Aggiungi Prodotto" CssClass="btn" OnClick="btnAddProduct_Click" />
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <h2><%# Eval("Nome") %></h2>
                        <p><strong>Brand:</strong> <%# Eval("Brand") %></p>
                        <p><strong>Dettagli:</strong> <%# Eval("Dettagli") %></p>
                        <p><strong>Prezzo:</strong> <%# Eval("Prezzo", "{0:C}") %></p>
                        <p><strong>Rating:</strong> <%# Eval("Rating") %></p>
                        <p><strong>Categoria:</strong> <%# Eval("Categoria") %></p>
                        <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' Width="100" Height="100" />
                        <asp:Button ID="btnEdit" runat="server" Text="Modifica" CssClass="btn" CommandName="Edit" CommandArgument='<%# Eval("IdProdotto") %>' OnClick="btnEdit_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Elimina" CssClass="btn" CommandName="Delete" CommandArgument='<%# Eval("IdProdotto") %>' OnClick="btnDelete_Click" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </div>
</asp:Content>