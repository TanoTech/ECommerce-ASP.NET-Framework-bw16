using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BW16C
{
    public partial class Carrello2 : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public Carrello2()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public class Prodotto
        {
            public int IdProdotto { get; set; }
            public string Nome { get; set; }
            public decimal Prezzo { get; set; }
        }

        public class ProdottoCarrello
        {
            public int IdProdotto { get; set; }
            public string Nome { get; set; }
            public decimal Prezzo { get; set; }
            public int Quantita { get; set; }
            public decimal PrezzoTotale { get { return Prezzo * Quantita; } }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Carrello"] != null)
                {
                    string carrelloValue = Request.Cookies["Carrello"].Value;
                    if (!string.IsNullOrEmpty(carrelloValue))
                    {
                        string[] prodottiInCarrello = carrelloValue.Split('&');
                        List<ProdottoCarrello> carrello = new List<ProdottoCarrello>();

                        foreach (string prodottoStringa in prodottiInCarrello)
                        {
                            string[] infoProdotto = prodottoStringa.Split('=');
                            int idProdotto = Convert.ToInt32(infoProdotto[0]);
                            int quantita = Convert.ToInt32(infoProdotto[1]);

                            Prodotto prodotto = GetProdottoFromDatabase(idProdotto);
                            if (prodotto != null)
                            {
                                ProdottoCarrello prodottoEsistente = carrello.Find(p => p.IdProdotto == idProdotto);
                                if (prodottoEsistente != null)
                                {
                                    prodottoEsistente.Quantita += quantita;
                                }
                                else
                                {
                                    ProdottoCarrello prodottoCarrello = new ProdottoCarrello
                                    {
                                        IdProdotto = prodotto.IdProdotto,
                                        Nome = prodotto.Nome,
                                        Prezzo = prodotto.Prezzo,
                                        Quantita = quantita
                                    };
                                    carrello.Add(prodottoCarrello);
                                }
                            }
                        }

                        if (carrello.Count > 0)
                        {
                            rptCarrello.DataSource = carrello;
                            rptCarrello.DataBind();
                            decimal totalCartPrice = CalculateTotalCartPrice(carrello);
                            lblTotalCartPrice.Text = string.Format("{0:C}", totalCartPrice);
                        }
                    }
                }
            }
        }


    private Prodotto GetProdottoFromDatabase(int idProdotto)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [IdProdotto], [Nome], [Prezzo] FROM [dbo].[Prodotti] WHERE [IdProdotto] = @ProductId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", idProdotto);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Prodotto prodotto = new Prodotto
                    {
                        IdProdotto = Convert.ToInt32(reader["IdProdotto"]),
                        Nome = reader["Nome"].ToString(),
                        Prezzo = Convert.ToDecimal(reader["Prezzo"])
                    };
                    reader.Close();
                    return prodotto;
                }
                return null;
            }
        }

        private decimal CalculateTotalCartPrice(List<ProdottoCarrello> carrello)
        {
            decimal total = 0;
            foreach (ProdottoCarrello prodottoCarrello in carrello)
            {
                total += prodottoCarrello.Prezzo * prodottoCarrello.Quantita;
            }
            return total;
        }
    }
}
