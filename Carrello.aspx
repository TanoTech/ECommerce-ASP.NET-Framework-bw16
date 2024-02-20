<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="BW16C.Carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <asp:Repeater ID="rptCarrello" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <img src='<%# Eval("ImgUrl") %>' alt='<%# Eval("Nome") %>' />
                        <h2><%# Eval("Nome") %></h2>
                        <p><%# Eval("Dettagli") %></p>
                        <p>Prezzo: <%# Eval("Prezzo") %></p>
                        <asp:TextBox ID="txtQuantita" runat="server" Text='<%# Eval("Quantità") %>'></asp:TextBox>
                        <asp:Button ID="btnAggiungi" runat="server" Text="+" OnClick="AggiungiQuantita_Click" CommandArgument='<%# Eval("IdProdotto") %>' />
                        <asp:Button ID="btnRimuovi" runat="server" Text="-" OnClick="RimuoviProdotto_Click" CommandArgument='<%# Eval("IdProdotto") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>