using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace BW16C
{
    public partial class EditProductPage : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var MasterPage = this.Master as Templates.Master;
                if (MasterPage != null)
                {
                    MasterPage.CheckIfAdmin();
                }
                if (Request.QueryString["productId"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["productId"]);
                    LoadProductDetails(productId);
                }
            }
        }

        public EditProductPage()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void LoadProductDetails(int productId)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "SELECT Nome, Brand, Dettagli, Prezzo, Rating, Categoria, ImgUrl FROM dbo.Prodotti WHERE IdProdotto = @IdProdotto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProdotto", productId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtProductName.Text = reader["Nome"].ToString();
                        txtProductBrand.Text = reader["Brand"].ToString();
                        txtProductDetails.Text = reader["Dettagli"].ToString();
                        txtProductPrice.Text = reader["Prezzo"].ToString();
                        txtProductRating.Text = reader["Rating"].ToString();
                        txtProductCategory.Text = reader["Categoria"].ToString();
                        txtImgUrl.Text = reader["ImgUrl"].ToString();
                        lblProductId.Text = productId.ToString();

                        //x immagine
                        string imgUrl = reader["ImgUrl"].ToString();
                        if (!string.IsNullOrEmpty(imgUrl))
                        {
                            imgProduct.ImageUrl = imgUrl;
                            imgProduct.Visible = true;
                        }
                        else
                        {
                            imgProduct.Visible = false;
                        }
                    }
                    reader.Close();
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(lblProductId.Text);
            string nome = txtProductName.Text;
            string brand = txtProductBrand.Text;
            string dettagli = txtProductDetails.Text;
            decimal prezzo = Convert.ToDecimal(txtProductPrice.Text);
            //modifica per poter lascaire spazi vuoti e modificare prodotti
            int rating;
            if (!int.TryParse(txtProductRating.Text, out rating))
            {
                rating = 0;
            }
            string categoria = txtProductCategory.Text;
            string imgUrl = txtImgUrl.Text;

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            string query = "UPDATE dbo.Prodotti SET Nome = @Nome, Brand = @Brand, Dettagli = @Dettagli, Prezzo = @Prezzo, Rating = @Rating, Categoria = @Categoria, ImgUrl = @ImgUrl WHERE IdProdotto = @IdProdotto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProdotto", productId);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.Parameters.AddWithValue("@Dettagli", dettagli);
                    command.Parameters.AddWithValue("@Prezzo", prezzo);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    command.Parameters.AddWithValue("@ImgUrl", imgUrl);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                    }
                }
            }
        }
    }
}
