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

                                quantitaTotaleProdotti += quantita;
                            }

                            reader.Close();
                        }
                    }
                }
                else
                {
                }

                ltlTotaleCarrello.Text = $"{totaleCarrello.ToString("C")}";
            }
        }

    }
}
