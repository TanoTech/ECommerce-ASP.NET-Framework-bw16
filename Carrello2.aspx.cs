using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
                    string carrelloCookieValue = Request.Cookies["Carrello"].Value;

                    MatchCollection matches = Regex.Matches(carrelloCookieValue, @"(?<idProdotto>\d+)=(?<quantita>\d+)");

                    List<int> idProdotti = new List<int>();
                    foreach (Match match in matches)
                    {
                        int idProdotto = int.Parse(match.Groups["idProdotto"].Value);
                        idProdotti.Add(idProdotto);
                    }

                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append("SELECT * FROM Prodotti WHERE IdProdotto IN (");
                    foreach (int idProdotto in idProdotti)
                    {
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
