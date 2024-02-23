window.onload = function () {



    var cookieValue = document.cookie.replace(/(?:(?:^|.*;\s*)Carrello\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    var totalItems = 0;

    if (cookieValue) {
        var pairs = cookieValue.split('&');
        for (var i = 0; i < pairs.length; i++) {
            var pair = pairs[i].split('=');
            if (pair.length === 2) {
                var quantity = parseInt(pair[1], 10);
                totalItems += quantity;
            }
        }
    }

    document.getElementById("cartCounterCookie").textContent = totalItems;
}
