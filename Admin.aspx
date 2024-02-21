<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BW16C.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Admin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminPage">
            <div class="admin">
                <h1>ADMIN</h1>
                <asp:Button ID="btnAddProduct" runat="server" Text="Aggiungi Prodotto" CssClass="btnAdd" OnClick="btnAddProduct_Click" />
            </div>    
            <asp:Repeater ID="rptProducts" runat="server">
            
            <itemtemplate>
                <div class="container">
                    <div class="card">
                        <div class="imgProduct">
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                        </div>

                        <div class="left">
                            <h2><%# Eval("Nome") %></h2>
                            <p><strong>Brand:</strong> <%# Eval("Brand") %></p>
                            <p><strong>Prezzo:</strong> <%# Eval("Prezzo", "{0:C}") %></p>
                            <p><strong>Categoria:</strong> <%# Eval("Categoria") %></p>
                            <p><strong>Rating:</strong> <%# Eval("Rating") %></p>
                        </div>

                        <div class="dettagli">
                            <p><strong>Dettagli:</strong> <%# Eval("Dettagli") %></p>
                        </div>

                        <div class="rightButton">
                            <asp:Button ID="btnEdit" runat="server" Text="Modifica" CssClass="btn" CommandName="Edit" CommandArgument='<%# Eval("IdProdotto") %>' OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="Rimuovi" CssClass="btn" CommandName="Delete" CommandArgument='<%# Eval("IdProdotto") %>' OnClick="btnDelete_Click" />
                        </div>
                    </div>

                </div>
            </itemtemplate>
            </asp:Repeater>
    </div>
</asp:Content>