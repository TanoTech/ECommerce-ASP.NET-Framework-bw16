<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BW16C.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Benvenuto
            <asp:Literal ID="UserNameLiteral" runat="server"></asp:Literal>
        </h2>
        <div>
            <img id="UserImage" runat="server" src="" alt="Immagine utente" />
        </div>
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
            <asp:Label ID="ImmagineLabel" runat="server" Text="URL Immagine"></asp:Label>
            <asp:TextBox ID="ImmagineTextBox" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="UpdateButton" runat="server" Text="Aggiorna" OnClick="UpdateButton_Click" />
        <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
    </div>
</asp:Content>
