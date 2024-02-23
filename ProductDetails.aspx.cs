using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Extensions.Configuration;

namespace BW16C
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public ProductDetails()
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
                if (Request.QueryString["IdProdotto"] != null && int.TryParse(Request.QueryString["IdProdotto"], out int productId))
                {
                    PopulateProduct(productId);
                    CalcolaPrezzoTotale();
                }
                else
                {
                    Response.Redirect("WrongProduct.aspx");
                }
            }
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
                    lblProductNameDetails.Text = reader["Nome"].ToString().ToUpper();
                    lblBrandDetails.Text = reader["Brand"].ToString().ToUpper();
                    lblDetailsDetails.Text = reader["Dettagli"].ToString();
                    imgProductDetails.ImageUrl = reader["ImgUrl"].ToString();
                    lblPriceDetails.Text = reader["Prezzo"].ToString();
                    lblRatingDetails.Text = reader["Rating"].ToString();

                    double rating = Convert.ToDouble(reader["Rating"]);
                    int roundedRating = (int)Math.Floor(rating);
                    lblRatingDetails.Text = roundedRating.ToString();

                    string starHtml = GetStarRatingHtml(roundedRating);
                    starRating.InnerHtml = starHtml;

                    int categoryId = Convert.ToInt32(reader["Categoria"]);
                    string category = GetCategoryName(categoryId);
                    lblCategoryDetails.Text = category.ToUpper();
                }
                else
                {
                    Response.Redirect("WrongProduct.aspx");
                }

                reader.Close();
            }
        }

        protected string GetStarRatingHtml(int rating)
        {
            string starHtml = "";
            for (int i = 0; i < 5; i++)
            {
                if (i < rating)
                {
                    starHtml += "<span class='star-filled'>&#9733;</span>";
                }
                else
                {
                    starHtml += "<span class='star-empty'>&#9734;</span>";
                }
            }
            return starHtml;
        }

        protected void ddlQuantita_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcolaPrezzoTotale();
            var MasterPage = this.Master as Templates.Master;
            if (MasterPage != null)
            {
                MasterPage.ShowAdmin();
                MasterPage.UpdateCounter();
            }
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
            int quantità = Convert.ToInt32(ddlQuantitàDetails.SelectedValue);
            decimal prezzoProdotto = Convert.ToDecimal(lblPriceDetails.Text);
            decimal prezzoTotaleProdotto = prezzoProdotto * quantità;

            if (Session["IdUtente"] != null)
            {
                int userId = Convert.ToInt32(Session["IdUtente"]);
                AggiungiAlCarrelloUtente(userId, productId, quantità, prezzoTotaleProdotto);
            }
            else
            {
                AggiungiAlCarrelloCookie(productId, quantità, prezzoTotaleProdotto);
            }

            string messaggio = "Prodotto aggiunto al carrello con successo!";
            ClientScript.RegisterStartupScript(this.GetType(), "mostraMessaggioConferma", "mostraMessaggioConferma('" + messaggio + "');", true);

            ddlQuantitàDetails.SelectedValue = "1";
            CalcolaPrezzoTotale();
            var MasterPage = this.Master as Templates.Master;
            if (MasterPage != null)
            {
                MasterPage.ShowAdmin();
                MasterPage.UpdateCounter();
            }
        }

        private void AggiungiAlCarrelloCookie(int productId, int quantità, decimal prezzoTotaleProdotto)
        {
            HttpCookie carrelloCookie = Request.Cookies["Carrello"];

            string prodotto = productId.ToString();
            if (carrelloCookie.Values[prodotto] != null)
            {
                int quantitàEsistente = Convert.ToInt32(carrelloCookie.Values[prodotto]);
                quantità += quantitàEsistente;
            }
            carrelloCookie.Values[prodotto] = quantità.ToString();

            Response.Cookies.Add(carrelloCookie);
        }

        private void AggiungiAlCarrelloUtente(int userId, int productId, int quantità, decimal prezzoTotaleProdotto)
        {
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
                    decimal prezzoTotaleEsistente = Convert.ToDecimal(reader["PrezzoTotProdotto"]);

                    int nuovaQuantità = quantità + quantitàEsistente;
                    decimal nuovoPrezzoTotale = prezzoTotaleProdotto + prezzoTotaleEsistente;

                    reader.Close();
                    string updateQuery = "UPDATE Carrello SET Quantità = @NuovaQuantità, PrezzoTotProdotto = @NuovoPrezzoTotale WHERE IdCarrello = @IdCarrello";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@NuovaQuantità", nuovaQuantità);
                    updateCmd.Parameters.AddWithValue("@NuovoPrezzoTotale", nuovoPrezzoTotale);
                    updateCmd.Parameters.AddWithValue("@IdCarrello", idCarrello);

                    updateCmd.ExecuteNonQuery();
                    var MasterPage = this.Master as Templates.Master;
                    if (MasterPage != null)
                    {
                        MasterPage.ShowAdmin();
                        MasterPage.UpdateCounter();
                    }
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
                    var MasterPage = this.Master as Templates.Master;
                    if (MasterPage != null)
                    {
                        MasterPage.ShowAdmin();
                        MasterPage.UpdateCounter();
                    }
                }
            }
        }

        private string GetCategoryName(int categoryId)
        {
            string categoryName = "";
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [Categoria] FROM [dbo].[CategoriaProdotti] WHERE [ID] = @CategoryId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    categoryName = result.ToString();
                }
            }
            return categoryName;
        }
    }
}