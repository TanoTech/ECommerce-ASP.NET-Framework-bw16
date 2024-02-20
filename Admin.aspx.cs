using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class Admin : System.Web.UI.Page
    {
        private bool isDeletedSuccessfully = false;
        private IConfiguration Configuration { get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        public Admin()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void BindProducts()
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "SELECT IdProdotto, Nome, Brand, Dettagli, ImgUrl, Prezzo, Rating, Categoria FROM dbo.Prodotti";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProductPage.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int productId = Convert.ToInt32(btnDelete.CommandArgument);

            // Cancella il prodotto
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "DELETE FROM dbo.Prodotti WHERE IdProdotto = @IdProdotto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProdotto", productId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    isDeletedSuccessfully = rowsAffected > 0;
                }
            }

            // Aggiorna Lista
            BindProducts();
        }
    }
}