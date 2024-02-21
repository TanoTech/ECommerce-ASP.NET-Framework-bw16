<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="BW16C.Carrello" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/StileCarrello.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div id="contenitoreCarrello">
            <div id="contenitoreTitoloCard">
                <div id="titolo">
                    <h1>CARRELLO</h1>
                    <p>PREZZO</p>
                </div>
                <div>
                    <asp:Repeater ID="rptCarrello" runat="server">
                        <ItemTemplate>
                            <div class="card">
                                <div id="cardImgDettagli">
                                    <img id="img" src='<%# Eval("ImgUrl") %>' alt='<%# Eval("Nome") %>' />
                                    <div id="contenitoreNomeDettagliQuantitàRimuovi">
                                        <div>
                                            <h2><%# Eval("Nome") %></h2>
                                            <p><%# Eval("Brand") %></p>
                                        </div>
                                        <p id="dettagli"><%# Eval("Dettagli") %></p>
                                        <div id="contenitoreQuantitàRimuovi">
                                            <p>Quantità:</p>
                                            <div>
                                                <asp:Button CssClass="btnRimuoviQuantità" ID="btnRimuoviSingolo" runat="server" Text="-" OnClick="RimuoviSingolo_Click" CommandArgument='<%# Eval("IdProdotto") %>' />
                                            </div>
                                            <p id="numeroQuantità"><%# Eval("Quantità") %></p>
                                            <div>
                                                <asp:Button CssClass="btnAggiungiQuantità" ID="btnAggiungiQuantità" runat="server" Text="+" OnClick="AggiungiQuantità_Click" CommandArgument='<%# Eval("IdProdotto") %>' />
                                            </div>
                                            <div>
                                                <asp:Button CssClass="btnRimuoviProdotto" ID="btnRimuoviDefinitivamente" runat="server" Text="Rimuovi" OnClick="RimuoviDefinitivamente_Click" CommandArgument='<%# Eval("IdProdotto") %>' />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <p><%# Eval("Prezzo") %>€</p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div id="contenitoreTotale">
                <h3>TOTALE CARRELLO:</h3>
                <asp:Label CssClass="prezzoTot" ID="lblTotalCartPrice" runat="server"></asp:Label>
                <asp:Button CssClass="btnSvuota" ID="Button1" runat="server" Text="Svuota il carrello" OnClick="RimuoviTutti_Click" />
            </div>
        </div>
    </form>
</asp:Content>
