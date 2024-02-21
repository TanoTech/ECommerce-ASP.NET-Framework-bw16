<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagamento.aspx.cs" Inherits="BW16C.Pagamento" %>
<!DOCTYPE html>
<html>
<head>
    <title>Pagamento</title>
    <style>
        .loader-container {
            display: flex;
            align-items: center;
            justify-content: center;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(255, 255, 255, 0.7);
            z-index: 9999;
        }

        .loader {
            border: 16px solid #f3f3f3;
            border-top: 16px solid #3498db; 
            border-radius: 50%;
            width: 120px;
            height: 120px;
            animation: spin 2s linear infinite;
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }

        #success-message {
            display: none;
            text-align: center;
            margin-top: 20px;
            font-size: 18px;
            color: green;
        }
    </style>
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
