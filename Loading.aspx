<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading.aspx.cs" Inherits="BW16C.Loading" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loading...</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Lato:wght@300;400;700&family=Oswald:wght@200..700&display=swap');


        body {
            background-color: #5aa3ce;
            font-family: "Oswald", sans-serif;
            font-weight: 400;
        }

        h1 {
            margin-top: 4em;
            font-size: 3em;
            color: white;
        }

        .loader {
            border: 8px solid #f3f3f3;
            border-top: 8px solid #3498db;
            border-radius: 50%;
            width: 50px;
            height: 50px;
            animation: spin 1s linear infinite;
            margin: auto;
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }
    </style>
    <script>
        setTimeout(function () {
            window.location.href = "Home.aspx";
        }, 2500);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="loader"></div>
        <h1 style="text-align: center;">Benvenuto su I CECI! </h1>
    </form>
</body>
</html>
