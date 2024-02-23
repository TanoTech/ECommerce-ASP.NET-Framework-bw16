<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BW16C.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/home.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <script defer>
        document.addEventListener("DOMContentLoaded", () => {
            let allRatings = document.querySelectorAll(".productCardRating");
            allRatings.forEach((rating) => {
                let ratingText = rating.textContent;
                let splittedNumber = ratingText.split(",");
                let firstNumber = splittedNumber[0];
                switch (firstNumber) {
                    case "0":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i>';
                        break;
                    case "1":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star-fill"></i><i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i>';
                        break;
                    case "2":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star"></i><i class="bi bi-star"></i><i class="bi bi-star"></i>';
                        break;
                    case "3":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star"></i><i class="bi bi-star"></i>';
                        break;
                    case "4":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star"></i>';
                        break;
                    case "5":
                        rating.textContent = "";
                        rating.innerHTML = '<i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i><i class="bi bi-star-fill"></i>';
                        break;
                    default: 
                        break;
                }
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="toTop">
        <a href="#linkToTop">
            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="#5aa3ce" class="bi bi-caret-up-fill" viewBox="0 0 16 16">
              <path d="m7.247 4.86-4.796 5.481c-.566.647-.106 1.659.753 1.659h9.592a1 1 0 0 0 .753-1.659l-4.796-5.48a1 1 0 0 0-1.506 0z"/>
            </svg>
        </a>
    </div>
    <div id="HomeDiv">
        <div id="HomeCategories">
            <a href="#Elettronica">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pc-display" viewBox="0 0 16 16">
                        <path d="M8 1a1 1 0 0 1 1-1h6a1 1 0 0 1 1 1v14a1 1 0 0 1-1 1H9a1 1 0 0 1-1-1zm1 13.5a.5.5 0 1 0 1 0 .5.5 0 0 0-1 0m2 0a.5.5 0 1 0 1 0 .5.5 0 0 0-1 0M9.5 1a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1zM9 3.5a.5.5 0 0 0 .5.5h5a.5.5 0 0 0 0-1h-5a.5.5 0 0 0-.5.5M1.5 2A1.5 1.5 0 0 0 0 3.5v7A1.5 1.5 0 0 0 1.5 12H6v2h-.5a.5.5 0 0 0 0 1H7v-4H1.5a.5.5 0 0 1-.5-.5v-7a.5.5 0 0 1 .5-.5H7V2z" />
                    </svg>
                    <p>Elettronica</p>
                </div>
            </a>
            <a href="#Casa">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-house-door-fill" viewBox="0 0 16 16">
                        <path d="M6.5 14.5v-3.505c0-.245.25-.495.5-.495h2c.25 0 .5.25.5.5v3.5a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5v-7a.5.5 0 0 0-.146-.354L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293L8.354 1.146a.5.5 0 0 0-.708 0l-6 6A.5.5 0 0 0 1.5 7.5v7a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5" />
                    </svg>
                    <p>Casa</p>
                </div>
            </a>
            <a href="#FaiDaTe">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-hand-thumbs-up-fill" viewBox="0 0 16 16">
                        <path d="M6.956 1.745C7.021.81 7.908.087 8.864.325l.261.066c.463.116.874.456 1.012.965.22.816.533 2.511.062 4.51a10 10 0 0 1 .443-.051c.713-.065 1.669-.072 2.516.21.518.173.994.681 1.2 1.273.184.532.16 1.162-.234 1.733q.086.18.138.363c.077.27.113.567.113.856s-.036.586-.113.856c-.039.135-.09.273-.16.404.169.387.107.819-.003 1.148a3.2 3.2 0 0 1-.488.901c.054.152.076.312.076.465 0 .305-.089.625-.253.912C13.1 15.522 12.437 16 11.5 16H8c-.605 0-1.07-.081-1.466-.218a4.8 4.8 0 0 1-.97-.484l-.048-.03c-.504-.307-.999-.609-2.068-.722C2.682 14.464 2 13.846 2 13V9c0-.85.685-1.432 1.357-1.615.849-.232 1.574-.787 2.132-1.41.56-.627.914-1.28 1.039-1.639.199-.575.356-1.539.428-2.59z" />
                    </svg>
                    <p>Fai da te</p>
                </div>
            </a>
            <a href="#Sport">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-walking" viewBox="0 0 16 16">
                        <path d="M9.5 1.5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0M6.44 3.752A.75.75 0 0 1 7 3.5h1.445c.742 0 1.32.643 1.243 1.38l-.43 4.083a1.8 1.8 0 0 1-.088.395l-.318.906.213.242a.8.8 0 0 1 .114.175l2 4.25a.75.75 0 1 1-1.357.638l-1.956-4.154-1.68-1.921A.75.75 0 0 1 6 8.96l.138-2.613-.435.489-.464 2.786a.75.75 0 1 1-1.48-.246l.5-3a.75.75 0 0 1 .18-.375l2-2.25Z" />
                        <path d="M6.25 11.745v-1.418l1.204 1.375.261.524a.8.8 0 0 1-.12.231l-2.5 3.25a.75.75 0 1 1-1.19-.914zm4.22-4.215-.494-.494.205-1.843.006-.067 1.124 1.124h1.44a.75.75 0 0 1 0 1.5H11a.75.75 0 0 1-.531-.22Z" />
                    </svg>
                    <p>Sport</p>
                </div>
            </a>
            <a href="#AbitiEAccessori">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-handbag-fill" viewBox="0 0 16 16">
                        <path d="M8 1a2 2 0 0 0-2 2v2H5V3a3 3 0 1 1 6 0v2h-1V3a2 2 0 0 0-2-2M5 5H3.36a1.5 1.5 0 0 0-1.483 1.277L.85 13.13A2.5 2.5 0 0 0 3.322 16h9.355a2.5 2.5 0 0 0 2.473-2.87l-1.028-6.853A1.5 1.5 0 0 0 12.64 5H11v1.5a.5.5 0 0 1-1 0V5H6v1.5a.5.5 0 0 1-1 0z" />
                    </svg>
                    <p>Abiti e Accessori</p>
                </div>
            </a>
            <a href="#SaluteEBellezza">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-stars" viewBox="0 0 16 16">
                        <path d="M7.657 6.247c.11-.33.576-.33.686 0l.645 1.937a2.89 2.89 0 0 0 1.829 1.828l1.936.645c.33.11.33.576 0 .686l-1.937.645a2.89 2.89 0 0 0-1.828 1.829l-.645 1.936a.361.361 0 0 1-.686 0l-.645-1.937a2.89 2.89 0 0 0-1.828-1.828l-1.937-.645a.361.361 0 0 1 0-.686l1.937-.645a2.89 2.89 0 0 0 1.828-1.828zM3.794 1.148a.217.217 0 0 1 .412 0l.387 1.162c.173.518.579.924 1.097 1.097l1.162.387a.217.217 0 0 1 0 .412l-1.162.387A1.73 1.73 0 0 0 4.593 5.69l-.387 1.162a.217.217 0 0 1-.412 0L3.407 5.69A1.73 1.73 0 0 0 2.31 4.593l-1.162-.387a.217.217 0 0 1 0-.412l1.162-.387A1.73 1.73 0 0 0 3.407 2.31zM10.863.099a.145.145 0 0 1 .274 0l.258.774c.115.346.386.617.732.732l.774.258a.145.145 0 0 1 0 .274l-.774.258a1.16 1.16 0 0 0-.732.732l-.258.774a.145.145 0 0 1-.274 0l-.258-.774a1.16 1.16 0 0 0-.732-.732L9.1 2.137a.145.145 0 0 1 0-.274l.774-.258c.346-.115.617-.386.732-.732z" />
                    </svg>
                    <p>Salute e Bellezza</p>
                </div>
            </a>
            <a href="#Intrattenimento">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-joystick" viewBox="0 0 16 16">
                        <path d="M10 2a2 2 0 0 1-1.5 1.937v5.087c.863.083 1.5.377 1.5.726 0 .414-.895.75-2 .75s-2-.336-2-.75c0-.35.637-.643 1.5-.726V3.937A2 2 0 1 1 10 2" />
                        <path d="M0 9.665v1.717a1 1 0 0 0 .553.894l6.553 3.277a2 2 0 0 0 1.788 0l6.553-3.277a1 1 0 0 0 .553-.894V9.665c0-.1-.06-.19-.152-.23L9.5 6.715v.993l5.227 2.178a.125.125 0 0 1 .001.23l-5.94 2.546a2 2 0 0 1-1.576 0l-5.94-2.546a.125.125 0 0 1 .001-.23L6.5 7.708l-.013-.988L.152 9.435a.25.25 0 0 0-.152.23" />
                    </svg>
                    <p>Intrattenimento</p>
                </div>
            </a>
            <a href="#Bambini">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-emoji-smile" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                        <path d="M4.285 9.567a.5.5 0 0 1 .683.183A3.5 3.5 0 0 0 8 11.5a3.5 3.5 0 0 0 3.032-1.75.5.5 0 1 1 .866.5A4.5 4.5 0 0 1 8 12.5a4.5 4.5 0 0 1-3.898-2.25.5.5 0 0 1 .183-.683M7 6.5C7 7.328 6.552 8 6 8s-1-.672-1-1.5S5.448 5 6 5s1 .672 1 1.5m4 0c0 .828-.448 1.5-1 1.5s-1-.672-1-1.5S9.448 5 10 5s1 .672 1 1.5" />
                    </svg>
                    <p>Bambini</p>
                </div>
            </a>
            <a href="#Alimentazione">
                <div class="HomeCategory">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-egg-fried" viewBox="0 0 16 16">
                        <path d="M8 11a3 3 0 1 0 0-6 3 3 0 0 0 0 6" />
                        <path d="M13.997 5.17a5 5 0 0 0-8.101-4.09A5 5 0 0 0 1.28 9.342a5 5 0 0 0 8.336 5.109 3.5 3.5 0 0 0 5.201-4.065 3.001 3.001 0 0 0-.822-5.216zm-1-.034a1 1 0 0 0 .668.977 2.001 2.001 0 0 1 .547 3.478 1 1 0 0 0-.341 1.113 2.5 2.5 0 0 1-3.715 2.905 1 1 0 0 0-1.262.152 4 4 0 0 1-6.67-4.087 1 1 0 0 0-.2-1 4 4 0 0 1 3.693-6.61 1 1 0 0 0 .8-.2 4 4 0 0 1 6.48 3.273z" />
                    </svg>
                    <p>Alimentazione</p>
                </div>
            </a>
        </div>
        <div id="HomeProducts">
            <div class="CategoryContainer">
                <h2 id="Elettronica">Elettronica
                </h2>
                <div id="ElettronicaContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="ElettronicaRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5,0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="Casa">Casa
                </h2>
                <div id="CasaContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="CasaRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="FaiDaTe">Fai da te
                </h2>
                <div id="FaiDaTeContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="FaiDaTeRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="Sport">Sport
                </h2>
                <div id="SportContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="SportRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="AbitiEAccessori">Abiti e Accessori
                </h2>
                <div id="AbitiEAccessoriContainer" class="productCardsContainer" runat="server">
                   <asp:Repeater ID="AbitiEAccessoriRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="SaluteEBellezza">Salute e Bellezza
                </h2>
                <div id="SaluteEBellezzaContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="SaluteEBellezzaRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="Intrattenimento">Intrattenimento
                </h2>
                <div id="IntrattenimentoContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="IntrattenimentoRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="Bambini">Bambini
                </h2>
                <div id="BambiniContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="BambiniRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="CategoryContainer">
                <h2 id="Alimentazione">Alimentazione
                </h2>
                <div id="AlimentazioneContainer" class="productCardsContainer" runat="server">
                    <asp:Repeater ID="AlimentazioneRepeater" runat="server">
                        <ItemTemplate>
                            <div class="productCard">
                                <a href="/ProductDetails.aspx?IdProdotto=<%# Eval("IdProdotto") %>">
                                    <div class="productImg">
                                        <asp:Image ID="productImg" runat="server" ImageUrl='<%# Eval("ImgUrl") %>' />
                                    </div>
                                    <div class="productTxt">
                                        <h2><%# Eval("Nome") %></h2>
                                        <h3><%# Eval("Brand") %></h3>
                                        <div class="productPriceRating">
                                            <p><%# Eval("Prezzo") %>€</p>
                                            <p class="productCardRating"><%# Eval("Rating") %>/5.0</p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
