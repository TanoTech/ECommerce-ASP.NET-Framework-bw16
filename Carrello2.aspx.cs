using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class Carrello2 : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }
        private int quantitaTotaleProdotti = 0;
        private decimal totaleCarrello = 0;

        public Carrello2()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Carrello"] != null)
                {
                    string carrelloCookieValue = Request.Cookies["Carrello"].Value;

                    MatchCollection matches = Regex.Matches(carrelloCookieValue, @"(?<idProdotto>\d+)=(?<quantita>\d+)");

                    string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        foreach (Match match in matches)
                        {
                            int idProdotto = int.Parse(match.Groups["idProdotto"].Value);
                            int quantita = int.Parse(match.Groups["quantita"].Value);

                            string query = $"SELECT * FROM Prodotti WHERE IdProdotto = {idProdotto}";
                            SqlCommand command = new SqlCommand(query, connection);
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                string nomeProdotto = reader.GetString(1);
                                string brand = reader.GetString(2);
                                string dettagli = reader.GetString(3);
                                string imgUrl = reader.GetString(4);
                                decimal prezzo = reader.GetDecimal(5);

                                AggiungiProdottoAlCarrello(nomeProdotto, brand, dettagli, imgUrl, prezzo, quantita, idProdotto);
                                quantitaTotaleProdotti += quantita;
                            }

                            reader.Close();
                        }
                    }
                }
                else
                {
                    ltlCarrello.Text = "Il carrello è vuoto.";
                }

                ltlTotaleCarrello.Text = $"Totale carrello: {totaleCarrello.ToString("C")}";
            }
        }

        private void AggiungiProdottoAlCarrello(string nomeProdotto, string brand, string dettagli, string imgUrl, decimal prezzo, int quantita, int idProdotto)
        {
            Panel panelProdotto = new Panel();

            Image imgProdotto = new Image();
            imgProdotto.ID = "imgProdotto_" + idProdotto;
            imgProdotto.ImageUrl = imgUrl;
            imgProdotto.AlternateText = nomeProdotto;
            panelProdotto.Controls.Add(imgProdotto);

            Label lblNomeProdotto = new Label();
            lblNomeProdotto.Text = nomeProdotto + "<br />";
            panelProdotto.Controls.Add(lblNomeProdotto);

            Label lblBrand = new Label();
            lblBrand.Text = brand + "<br />";
            panelProdotto.Controls.Add(lblBrand);

            Label lblDettagli = new Label();
            lblDettagli.Text = dettagli + "<br />";
            panelProdotto.Controls.Add(lblDettagli);

            Label lblPrezzo = new Label();
            lblPrezzo.Text = prezzo.ToString("C") + "<br />";
            panelProdotto.Controls.Add(lblPrezzo);

            Label lblQuantita = new Label();
            lblQuantita.Text = "Quantità: " + quantita.ToString() + "<br />";
            panelProdotto.Controls.Add(lblQuantita);

            panelProdotto.Controls.Add(new LiteralControl("<hr />"));

            contenitoreCarrello.Controls.Add(panelProdotto);

            totaleCarrello += prezzo * quantita;
        }

        protected void RimuoviTutti_Click(object sender, EventArgs e)
        {
            ltlCarrello.Text = "Il carrello è vuoto.";
        }

        protected void btnProcediPagamento_Click(object sender, EventArgs e)
        {
            ltlCarrello.Text = "Il carrello è vuoto.";
            Response.Redirect("CheckOut.aspx");
        }

        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

    }
}
