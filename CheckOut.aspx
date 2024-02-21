<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BW16C.Checkout" %>
<!DOCTYPE html>
<html>
<head>
    <title>Checkout</title>
    <script src="https://js.stripe.com/v3/"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>
            <label for="card-element">
                Inserisci i dettagli della carta di credito:
            </label>
            <div id="card-element">
            </div>
            <div id="card-errors" role="alert"></div>
        </div>

        <asp:Button ID="btnSubmit" runat="server" Text="Paga adesso" OnClick="btnSubmit_Click" OnClientClick="return validateForm();" />
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