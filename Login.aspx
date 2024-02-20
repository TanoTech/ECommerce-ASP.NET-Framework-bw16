<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ECommerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Utente</title>
    <link rel="stylesheet" type="text/css" href="/Styles/Login.css" />
</head>
<body class="sfondoL">
    <form id="form1" runat="server">
        <div class="contenitoreL">
            <h1 class="textL">I CECI</h1>
        </div>
        <div class="contenitoreL">
            <div>
                <h2 class="textL">Login</h2>
                <div class="bordoL">
                    <div>
                        <h2 class="textL">Email:</h2>
                        <asp:TextBox ID="txtEmail" runat="server" class="emailIn"></asp:TextBox>
                    </div>
                    <div>
                        <h2 class="textL">Password:</h2>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="passwordIn"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btnL" />
                    </div>
                    <div>
                        <a href="SignUp.aspx" class="textL">Non hai un account? Registrati!</a>
                    </div>
                    <div>
                        <p class="textL">Oppure</p>
                    </div>
                    <div>
                        <asp:Button ID="btnAccediConGoogle" runat="server" Text="Accedi con Google" OnClick="btnAccediConGoogle_Click" />
                        <asp:Button ID="btnAccediConFacebook" runat="server" Text="Accedi con Facebook" OnClick="btnAccediConFacebook_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
