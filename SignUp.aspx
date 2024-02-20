<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ECommerce.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrazione Utente</title>
    <link rel="stylesheet" type="text/css" href="/Styles/Login.css" />
</head>
<body class="sfondoL">
    <form id="form1" runat="server">
        <div class="contenitoreL">
            <h1 class="textL hL">I CECI</h1>
        </div>
        <div class="contenitoreL">
            <div>
                <h2 class="textL hL">Registrazione</h2>
                <div class="bordoL">
                    <div>
                        <div>
                            <p class="textL pL">Email:</p>
                            <asp:TextBox ID="txtEmail" runat="server" class="emailIn"></asp:TextBox>
                        </div>
                        <div>
                            <p class="textL pL">Password:</p>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="passwordIn"></asp:TextBox>
                        </div>
                        <div>
                            <p class="textL pL">Conferma Password:</p>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="passwordIn"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Button ID="btnRegistrati" runat="server" Text="Registrati" OnClick="btnRegistrati_Click" class="btnL" />
                        </div>
                        <div>
                            <a href="Login.aspx" class="textL pL">Sei già registrato? Fai il login!</a>
                        </div>
                        <div>
                            <p class="textL pL">Oppure</p>
                        </div>
                        <div>
                            <asp:Button ID="btnAccediConGoogle" runat="server" Text="Accedi con Google" OnClick="btnAccediConGoogle_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="btnAccediConFacebook" runat="server" Text=" Accedi con Facebook" OnClick="btnAccediConFacebook_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
