<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ECommerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Utente</title>
    <link rel="stylesheet" type="text/css" href="Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Utente</h2>
            <div>
                Email: <asp:TextBox ID="txtEmail" runat="server" class="emailIn"></asp:TextBox>
            </div>
            <div>
                Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  class="passwordIn"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div>
                <a href="SignUp.aspx">Non hai un account? Registrati!</a>
            </div>
            <div>
                <p>Oppure</p>
            </div>
            <div>
                <asp:Button ID="btnAccediConGoogle" runat="server" Text="Accedi con Google" OnClick="btnAccediConGoogle_Click" />
                <asp:Button ID="btnAccediConFacebook" runat="server" Text="Accedi con Facebook" OnClick="btnAccediConFacebook_Click" />
            </div>
        </div>
    </form>
</body>
</html>