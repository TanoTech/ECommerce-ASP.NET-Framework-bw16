using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class Home : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public Home()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");

            if (!IsPostBack)
            {
                if (Request.QueryString["IdUtente"] != null)
                {
                    int IdUtente = Convert.ToInt32(Request.QueryString["IdUtente"]);
                    string userName = GetUserName(IdUtente);
                    UserNameLiteral.Text = userName;
                }

                LoadProductsByCategory(5, ElettronicaRepeater, connectionDB);
                LoadProductsByCategory(6, CasaRepeater, connectionDB);
                LoadProductsByCategory(7, FaiDaTeRepeater, connectionDB);
                LoadProductsByCategory(8, SportRepeater, connectionDB);
                LoadProductsByCategory(9, AbitiEAccessoriRepeater, connectionDB);
                LoadProductsByCategory(10, SaluteEBellezzaRepeater, connectionDB);
                LoadProductsByCategory(11, IntrattenimentoRepeater, connectionDB);
                LoadProductsByCategory(12, BambiniRepeater, connectionDB);
                LoadProductsByCategory(13, AlimentazioneRepeater, connectionDB);
            }
        }

        private string GetUserName(int IdUtente)
        {
            string userName = "";

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT NomeUtente FROM ListaUtenti WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userName = reader.GetString(0);
                    }
                }
            }

            return userName;
        }

        private void LoadProductsByCategory(int categoryId, Repeater repeater, string connectionString)
        {
            List<dynamic> products = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = @CategoryId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                repeater.DataSource = products;
                repeater.DataBind();
            }
        }
    }
}
