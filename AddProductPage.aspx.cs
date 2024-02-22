using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class AddProductPage : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public AddProductPage()
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
                var MasterPage = this.Master as Templates.Master;
                if (MasterPage != null)
                {
                    MasterPage.CheckIfAdmin();
                }
                //dropdown
                PopulateCategoriesDropdown();
            }
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string brand = txtBrand.Text;
            string dettagli = txtDettagli.Text;
            string imgUrl = txtImgUrl.Text;
            decimal prezzo = Convert.ToDecimal(txtPrezzo.Text);
            int rating = Convert.ToInt32(txtRating.Text);
            string categoria = ddlCategoria.SelectedValue;

            // nuovo prodotto
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "INSERT INTO dbo.Prodotti (Nome, Brand, Dettagli, ImgUrl, Prezzo, Rating, Categoria) VALUES (@Nome, @Brand, @Dettagli, @ImgUrl, @Prezzo, @Rating, @Categoria)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.Parameters.AddWithValue("@Dettagli", dettagli);
                    command.Parameters.AddWithValue("@ImgUrl", imgUrl);
                    command.Parameters.AddWithValue("@Prezzo", prezzo);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Categoria", categoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            Response.Redirect("Admin.aspx");
        }

        //recupero categorie x nuovo prodotto
        private void PopulateCategoriesDropdown()
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "SELECT ID, Categoria FROM bw16.dbo.CategoriaProdotti";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idCategoria = reader.GetInt32(0); 
                        string nomeCategoria = reader.GetString(1); 
                        ddlCategoria.Items.Add(new ListItem(nomeCategoria, idCategoria.ToString()));
                    }

                    reader.Close();
                }
            }
        }

    }
}
