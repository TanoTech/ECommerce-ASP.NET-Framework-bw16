using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Carrello"] != null)
                {
                    string carrelloCookieValue = Server.HtmlEncode(Request.Cookies["Carrello"].Value);
                    string[] prodottiInCarrello = carrelloCookieValue.Split('&');

                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append("SELECT * FROM Prodotti WHERE IdProdotto IN (");

                    foreach (string prodotto in prodottiInCarrello)
                    {
                        string[] idQuantita = prodotto.Split('=');
                        int idProdotto = Convert.ToInt32(idQuantita[0]);
                        queryBuilder.Append(idProdotto + ",");
                    }

                    queryBuilder.Remove(queryBuilder.Length - 1, 1);
                    queryBuilder.Append(")");

                    string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(queryBuilder.ToString(), connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        StringBuilder carrelloHtml = new StringBuilder();
                        while (reader.Read())
                        {
                            int idProdotto = reader.GetInt32(0);
                            string nomeProdotto = reader.GetString(1);
                            decimal prezzo = reader.GetDecimal(5);

                            carrelloHtml.Append($"<div>Nome: {nomeProdotto}, Prezzo: {prezzo}</div>");
                        }

                        reader.Close();

                        if (carrelloHtml.Length > 0)
                        {
                            ltlCarrello.Text = carrelloHtml.ToString();
                        }
                        else
                        {
                            ltlCarrello.Text = "Il carrello è vuoto.";
                        }
                    }
                }
                else
                {
                    ltlCarrello.Text = "Il carrello è vuoto.";
                }
            }
        }
    }
}
