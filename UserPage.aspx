<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BW16C.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <h2>Benvenuto
                <asp:Literal ID="UserNameLiteral" runat="server"></asp:Literal>
            </h2>
            <div>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Nuova Password"></asp:Label>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="NomeLabel" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="NomeTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="ImmagineLabel" runat="server" Text="Immagine"></asp:Label>
                <asp:FileUpload ID="ImmagineFileUpload" runat="server" />
            </div>
            <asp:Button ID="UpdateButton" runat="server" Text="Aggiorna" OnClick="UpdateButton_Click" />
        </div>
</asp:Content>