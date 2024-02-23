<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BW16C.Checkout" %>

<!DOCTYPE html>
<html>
<head>
    <link href="Styles/stylePagamento.css" rel="stylesheet" />
    <title>Checkout</title>
    <script src="https://js.stripe.com/v3/"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="all">
            <div class="container">
                <div class="first">
                    <label for="card-element" id="titleLbl">
                        Inserisci i dettagli della carta di credito:
                    </label>
                </div>
                <div class="detailsU">
                    <label for="nome">Nome:</label>
                    <input type="text" id="nome" name="nome" placeholder="Inserisci il tuo nome">

                    <label for="cognome">Cognome:</label>
                    <input type="text" id="cognome" name="cognome" placeholder="Inserisci il tuo cognome">

                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="Inserisci la tua email">

                    <label for="cap">CAP:</label>
                    <input type="text" id="cap" name="cap" placeholder="Inserisci il tuo CAP">

                    <label for="citta">Città:</label>
                    <input type="text" id="citta" name="citta" placeholder="Inserisci la tua città">

                    <label for="provincia">Provincia:</label>
                    <input type="text" id="provincia" name="provincia" placeholder="Inserisci la tua provincia">
                </div>

                <div id="card-element">
                </div>
                <div id="card-errors" role="alert"></div>
                <div class="contButton">
                <asp:Button ID="btnSubmit" class="btnShop" runat="server" Text="Paga adesso" OnClick="btnSubmit_Click" OnClientClick="return validateForm();" />

                </div>
            </div>

            



        </div>
    </form>

    <script>
        var stripe = Stripe('pk_test_*******************************Y98K');
        var elements = stripe.elements();
        var cardElement = elements.create('card');
        cardElement.mount('#card-element');

        cardElement.on('change', function (event) {
            var displayError = document.getElementById('card-errors');
            if (event.error) {
                displayError.textContent = event.error.message;
            } else {
                displayError.textContent = '';
            }
        })

        function validateForm() {
            var form = document.getElementById('form1');
            var isValid = true;

            var cardInput = document.getElementById('card-element');
            if (!cardInput.value.trim()) {
                isValid = false;
            }

            if (!isValid) {
                alert('Per favore, completa tutti i campi.');
            }

            return isValid;
        }

        function stripeTokenHandler(token) {
            var form = document.getElementById('form1');
            var hiddenInput = document.createElement('input');
            hiddenInput.setAttribute('type', 'hidden');
            hiddenInput.setAttribute('name', 'stripeToken');
            hiddenInput.setAttribute('value', token.id);
            form.appendChild(hiddenInput);
            window.location.href = 'Pagamento.aspx';
        }
    </script>
</body>
</html>