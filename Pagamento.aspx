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

    <div id="success-message">
        <p>
            <svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" fill="green" class="bi bi-check2-square" viewBox="0 0 16 16">
              <path d="M3 14.5A1.5 1.5 0 0 1 1.5 13V3A1.5 1.5 0 0 1 3 1.5h8a.5.5 0 0 1 0 1H3a.5.5 0 0 0-.5.5v10a.5.5 0 0 0 .5.5h10a.5.5 0 0 0 .5-.5V8a.5.5 0 0 1 1 0v5a1.5 1.5 0 0 1-1.5 1.5z"/>
              <path d="m8.354 10.354 7-7a.5.5 0 0 0-.708-.708L8 9.293 5.354 6.646a.5.5 0 1 0-.708.708l3 3a.5.5 0 0 0 .708 0"/>
            </svg>
            Pagamento avvenuto con successo
        </p>
    </div>

    <script>
        setTimeout(function () {
            document.querySelector('.loader-container').style.display = 'none';
            document.getElementById('success-message').style.display = 'block';
        }, 2000);

        setTimeout(function () { window.location.href = 'Home.aspx'; }, 4000);
    </script>
</body>
</html>
