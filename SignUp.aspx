<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ECommerce.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrazione Utente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registrazione Utente</h2>
            <div>
                Email: <asp:TextBox ID="txtEmail" runat="server" class="emailIn"></asp:TextBox>
            </div>
            <div>
                Password:
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="passwordIn"></asp:TextBox>
            </div>
            <div>
                Conferma Password:
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"  class="passwordIn"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnRegistrati" runat="server" Text="Registrati" OnClick="btnRegistrati_Click" />
            </div>
            <div>
                <a href="Login.aspx">Sei già registrato? Fai il login!</a>
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
