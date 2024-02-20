using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = Convert.ToInt32(Request.QueryString["IdProdotto"]);
                PopulateProduct(productId);

                CalcolaPrezzoTotale();
            }
        }

        private IConfiguration Configuration { get; }

        public ProductDetails()
        {
            Configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void PopulateProduct(int productId)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [IdProdotto], [Nome], [Brand], [Dettagli], [ImgUrl], [Prezzo], [Rating], [Categoria] FROM [dbo].[Prodotti] WHERE [IdProdotto] = @ProductId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblProductNameDetails.Text = reader["Nome"].ToString();
                    lblBrandDetails.Text = reader["Brand"].ToString();
                    lblDetailsDetails.Text = reader["Dettagli"].ToString();
                    imgProductDetails.ImageUrl = reader["ImgUrl"].ToString();
                    lblPriceDetails.Text = reader["Prezzo"].ToString();
                    lblRatingDetails.Text = reader["Rating"].ToString();
                    lblCategoryDetails.Text = reader["Categoria"].ToString();
                }
                reader.Close();
            }
        }

        protected void ddlQuantita_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcolaPrezzoTotale();
        }

        private void CalcolaPrezzoTotale()
        {
            decimal prezzoProdotto;
            if (decimal.TryParse(lblPriceDetails.Text, out prezzoProdotto))
            {
                int quantità = Convert.ToInt32(ddlQuantitàDetails.SelectedValue);
                decimal prezzoTotale = prezzoProdotto * quantità;
                lblPrezzoTotaleDetails.Text = prezzoTotale.ToString("C");
            }
            else
            {
                Console.WriteLine("Errore: Il prezzo del prodotto non è valido.");
            } 
        }

        protected void btnAggiungiAlCarrelloDetails_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["IdProdotto"]);
            int userId = 1;
            int quantità = Convert.ToInt32(ddlQuantitàDetails.SelectedValue);
            decimal prezzoProdotto = Convert.ToDecimal(lblPriceDetails.Text);
            decimal prezzoTotaleProdotto = prezzoProdotto * quantità;
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT IdCarrello, Quantità, PrezzoTotProdotto FROM Carrello WHERE IdUtente = @UserId AND IdProdotto = @ProductId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@UserId", userId);
                checkCmd.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader = checkCmd.ExecuteReader();
                if (reader.Read())
                {
                    int idCarrello = Convert.ToInt32(reader["IdCarrello"]);
                    int quantitàEsistente = Convert.ToInt32(reader["Quantità"]);
                    decimal prezzoTotaleEsistente = Convert.ToDecimal(reader["PrezzoTotProdotto"]);int nuovaQuantità = quantità + quantitàEsistente;
                    decimal nuovoPrezzoTotale = prezzoTotaleProdotto + prezzoTotaleEsistente;
                    reader.Close();
                    string updateQuery = "UPDATE Carrello SET Quantità = @NuovaQuantità, PrezzoTotProdotto = @NuovoPrezzoTotale WHERE IdCarrello = @IdCarrello";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@NuovaQuantità", nuovaQuantità);
                    updateCmd.Parameters.AddWithValue("@NuovoPrezzoTotale", nuovoPrezzoTotale);
                    updateCmd.Parameters.AddWithValue("@IdCarrello", idCarrello);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                    string insertQuery = "INSERT INTO Carrello (IdUtente, IdProdotto, Quantità, PrezzoTotProdotto) VALUES (@UserId, @ProductId, @Quantita, @PrezzoTotaleProdotto)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@UserId", userId);
                    insertCmd.Parameters.AddWithValue("@ProductId", productId);
                    insertCmd.Parameters.AddWithValue("@Quantita", quantità);
                    insertCmd.Parameters.AddWithValue("@PrezzoTotaleProdotto", prezzoTotaleProdotto);

                    insertCmd.ExecuteNonQuery();
                }
            }

            string messaggio = "Prodotto aggiunto al carrello con successo!";
            ClientScript.RegisterStartupScript(this.GetType(), "mostraMessaggioConferma", "mostraMessaggioConferma('" + messaggio + "');", true);

            ddlQuantitàDetails.SelectedValue = "1";
            CalcolaPrezzoTotale();
        }
    }
}