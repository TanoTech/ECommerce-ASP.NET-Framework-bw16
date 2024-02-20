using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.Extensions.Configuration;

namespace BW16C
{
    public partial class Carrello : System.Web.UI.Page
    {

        private IConfiguration Configuration { get; }

        public Carrello()
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
                BindCarrello();
            }
        }

        private void BindCarrello()
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Prodotti.IdProdotto, Prodotti.Nome, Prodotti.Brand, Prodotti.Dettagli, Prodotti.ImgUrl, Prodotti.Prezzo, Prodotti.Rating, Carrello.Quantità " +
                                                    "FROM Carrello " +
                                                    "INNER JOIN Prodotti ON Carrello.IdProdotto = Prodotti.IdProdotto " +
                                                    "WHERE Carrello.IdUtente = @IdUtente", connection);

                command.Parameters.AddWithValue("@IdUtente", "1");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                rptCarrello.DataSource = dt;
                rptCarrello.DataBind();

                decimal totalCartPrice = CalculateTotalCartPrice(dt);
                lblTotalCartPrice.Text = string.Format("{0:C}", totalCartPrice);
            }
        }

        protected void AggiungiQuantità_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Aumenta la quantità del prodotto nel carrello
                SqlCommand increaseQuantityCommand = new SqlCommand("UPDATE Carrello SET Quantità = Quantità + 1 WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                increaseQuantityCommand.Parameters.AddWithValue("@IdUtente", "1");
                increaseQuantityCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                increaseQuantityCommand.ExecuteNonQuery();
            }

            BindCarrello();
        }


        protected void RimuoviSingolo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Controlla la quantità attuale del prodotto nel carrello
                SqlCommand checkQuantityCommand = new SqlCommand("SELECT Quantità FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                checkQuantityCommand.Parameters.AddWithValue("@IdUtente", "1");
                checkQuantityCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                int currentQuantity = Convert.ToInt32(checkQuantityCommand.ExecuteScalar());

                // Se la quantità è maggiore di 1, rimuovi una singola quantità
                if (currentQuantity > 1)
                {
                    SqlCommand removeOneCommand = new SqlCommand("UPDATE Carrello SET Quantità = Quantità - 1 WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                    removeOneCommand.Parameters.AddWithValue("@IdUtente", "1");
                    removeOneCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                    removeOneCommand.ExecuteNonQuery();
                }
                else // Se la quantità è 1, rimuovi completamente il prodotto dal carrello
                {
                    SqlCommand removeProductCommand = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                    removeProductCommand.Parameters.AddWithValue("@IdUtente", "1");
                    removeProductCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                    removeProductCommand.ExecuteNonQuery();
                }
            }

            BindCarrello();
        }

        protected void RimuoviDefinitivamente_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProdotto = Convert.ToInt32(btn.CommandArgument);

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Rimuovi completamente il prodotto dal carrello
                SqlCommand removeProductCommand = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                removeProductCommand.Parameters.AddWithValue("@IdUtente", "1");
                removeProductCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                removeProductCommand.ExecuteNonQuery();
            }

            BindCarrello();
        }



        protected void RimuoviTutti_Click(object sender, EventArgs e)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Elimina tutti i prodotti dal carrello per l'utente corrente
                SqlCommand command = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente", connection);
                command.Parameters.AddWithValue("@IdUtente", "1");
                command.ExecuteNonQuery();
            }

            BindCarrello();
        }

        protected decimal CalculateTotalCartPrice(DataTable cartData)
        {
            decimal total = 0;

            foreach (DataRow row in cartData.Rows)
            {
                decimal price = Convert.ToDecimal(row["Prezzo"]);
                int quantity = Convert.ToInt32(row["Quantità"]);
                total += price * quantity;
            }

            return total;
        }

    }
}