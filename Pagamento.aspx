<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagamento.aspx.cs" Inherits="BW16C.Pagamento" %>
<!DOCTYPE html>
<html>
<head>
<link href="Styles/stylePagamento.css" rel="stylesheet" />
    <title>Pagamento</title>
</head>
<body>
    <div class="loader-container">
        <div class="loader"></div>
    </div>

    <div id="success-message">Pagamento avvenuto con successo</div>

    <script>
        setTimeout(function () {
            document.querySelector('.loader-container').style.display = 'none';
            document.getElementById('success-message').style.display = 'block';
        }, 2000);

        setTimeout(function () { window.location.href = 'Home.aspx'; }, 4000);
    </script>
</body>
</html>
