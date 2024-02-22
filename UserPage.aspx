<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BW16C.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <img id="UserImage" runat="server" src="" alt="Immagine utente" />
        </div>
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="UpdateEmailButton" runat="server" Text="Aggiorna Email" OnClick="UpdateEmailButton_Click" />
        </div>
        <div>
            <asp:Label ID="NomeLabel" runat="server" Text="Nome"></asp:Label>
            <asp:TextBox ID="NomeTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="UpdateNameButton" runat="server" Text="Aggiorna Nome" OnClick="UpdateNameButton_Click" />
        </div>
        <div>
            <asp:Label ID="ImmagineLabel" runat="server" Text="URL Immagine"></asp:Label>
            <asp:TextBox ID="ImmagineTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="UpdateImageButton" runat="server" Text="Aggiorna Immagine" OnClick="UpdateImageButton_Click" />
        </div>
        <div>
            <asp:Label ID="NewPasswordLabel" runat="server" Text="Nuova Password"></asp:Label>
            <asp:TextBox ID="NewPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="UpdatePasswordButton" runat="server" Text="Aggiorna Password" OnClick="UpdatePasswordButton_Click" />
        </div>
        <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
    </div>
</asp:Content>
