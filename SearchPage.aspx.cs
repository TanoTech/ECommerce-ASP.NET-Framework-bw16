using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class SearchPage : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public SearchPage()
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
                LoadSearchResults();
            }
        }

        public void LoadSearchResults()
        {
            string searchQuery;
            if (Request.QueryString["s"] == "" || Request.QueryString["s"] == null)
            {
                searchQuery = "";
            }
            else
            {
                searchQuery = Request.QueryString["s"].ToLower();
            }

            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");
            List<dynamic> searchResults = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();    
                string query = $"SELECT * FROM Prodotti WHERE Nome LIKE '%{searchQuery}%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchResults.Add(new
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

                SearchRepeater.DataSource = searchResults;
                SearchRepeater.DataBind();
            }
        }
    }
}