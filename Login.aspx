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
            <h1 class="textL hL">I CECI</h1>
        </div>
        <div class="contenitoreL">
            <div class="logIn">
                <h2 class="textL hL hL1">Login</h2>
                <div class="bordoL">
                    <div class="formL">
                        <div>
                            <p class="textL pL ">Email:</p>
                            <asp:TextBox ID="txtEmail" runat="server" class="emailIn" required="required"></asp:TextBox>
                        </div>
                        <div>
                            <p class="textL pL">Password:</p>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="passwordIn" required="required"></asp:TextBox>
                        </div>
                        <div>
                            <asp:CheckBox ID="chkVisualizzaPassword" runat="server" Text="Visualizza Password" AutoPostBack="true" OnCheckedChanged="chkVisualizzaPassword_CheckedChanged" class="textL pL" />
                        </div>
                        <div class="btnCL">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btnL" />
                        </div>
                    </div>
                    <div class="formSotto">
                        <div>
                            <a href="Home.aspx" class="textL pL tCL linkL">Procedi come ospite</a>
                        </div>
                        <div>
                            <a href="SignUp.aspx" class="textL pL tCL linkL">Non hai un account? Registrati!</a>
                        </div>
                        <div>
                            <p class="textL pL">Oppure fai login con:</p>
                        </div>
                        <div class="containerBtn">
                            <div>
                                <asp:LinkButton ID="btnAccediConGoogle" runat="server" Text="Accedi con Google" OnClick="btnAccediConGoogle_Click">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-google btnML" viewBox="0 0 16 16">
                                    <path d="M15.545 6.558a9.4 9.4 0 0 1 .139 1.626c0 2.434-.87 4.492-2.384 5.885h.002C11.978 15.292 10.158 16 8 16A8 8 0 1 1 8 0a7.7 7.7 0 0 1 5.352 2.082l-2.284 2.284A4.35 4.35 0 0 0 8 3.166c-2.087 0-3.86 1.408-4.492 3.304a4.8 4.8 0 0 0 0 3.063h.003c.635 1.893 2.405 3.301 4.492 3.301 1.078 0 2.004-.276 2.722-.764h-.003a3.7 3.7 0 0 0 1.599-2.431H8v-3.08z" />
                                </svg>
                                </asp:LinkButton>
                            </div>
                            <div>
                                <asp:LinkButton ID="btnAccediConFacebook" runat="server" Text=" Accedi con Facebook" OnClick="btnAccediConFacebook_Click">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-facebook bntML" viewBox="0 0 16 16">
                                    <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951" />
                                </svg>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
