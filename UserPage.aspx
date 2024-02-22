<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BW16C.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Page</title>
    <link rel="stylesheet" type="text/css" href="Styles/UserPage.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContainerUserPage">
      <div id="leftContainerUserPage">
        <div id="imgContainerUserPage">
            <img id="UserImage" runat="server" src="" alt="Immagine utente" class="imgUserPage"/>
        </div>
        <div>
            <asp:Label ID="ImmagineLabel" runat="server" Text="URL Immagine" CssClass="textlblUserPage"></asp:Label>
            <br />
            <asp:TextBox ID="ImmagineTextBox" runat="server" CssClass="textboxUrlUserPage"></asp:TextBox>            
            <div id="divBtnUrlUserPage">
                <asp:Button ID="UpdateImageButton" runat="server" Text="Aggiorna Immagine" OnClick="UpdateImageButton_Click" CssClass="btnUrlUserPage"/>
            </div>            
        </div>                   
      </div>
      <div id="rightContainerUserPage">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email" CssClass="textlblUserPage"></asp:Label>
            <br />
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="textboxUserPage"></asp:TextBox>
            <asp:Button ID="UpdateEmailButton" runat="server" Text="Aggiorna Email" OnClick="UpdateEmailButton_Click" CssClass="btnUpdateUserPage"/>
        </div>
        <div>
            <asp:Label ID="NomeLabel" runat="server" Text="Nome" CssClass="textlblUserPage"></asp:Label>
            <br />
            <asp:TextBox ID="NomeTextBox" runat="server" CssClass="textboxUserPage"></asp:TextBox>
            <asp:Button ID="UpdateNameButton" runat="server" Text="Aggiorna Nome" OnClick="UpdateNameButton_Click" CssClass="btnUpdateUserPage"/>
        </div>        
        <div>
            <asp:Label ID="NewPasswordLabel" runat="server" Text="Nuova Password" CssClass="textlblUserPage"></asp:Label>
            <br />
            <asp:TextBox ID="NewPasswordTextBox" runat="server" TextMode="Password" CssClass="textboxUserPage"></asp:TextBox>
            <asp:Button ID="UpdatePasswordButton" runat="server" Text="Aggiorna Password" OnClick="UpdatePasswordButton_Click" CssClass="btnUpdateUserPage"/>
        </div>
        <div id="divBtnLogoutUserPage">
            <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" CssClass="btnLogoutUserPage"/>
        </div>
      </div>
    </div>
</asp:Content>
