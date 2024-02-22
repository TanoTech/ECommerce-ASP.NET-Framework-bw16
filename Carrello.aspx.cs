using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
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
                if (Session["IdUtente"] != null)
                {
                    int IdUtente = Convert.ToInt32(Session["IdUtente"]);
                    BindCarrello();
                }

            }
        }
        private void BindCarrello()
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = Convert.ToInt32(Session["IdUtente"]);
                string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT Prodotti.IdProdotto, Prodotti.Nome, Prodotti.Brand, Prodotti.Dettagli, Prodotti.ImgUrl, Prodotti.Prezzo, Prodotti.Rating, Carrello.Quantità " +
                                                        "FROM Carrello " +
                                                        "INNER JOIN Prodotti ON Carrello.IdProdotto = Prodotti.IdProdotto " +
                                                        "WHERE Carrello.IdUtente = @IdUtente", connection);

                    command.Parameters.AddWithValue("@IdUtente", IdUtente);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rptCarrello.DataSource = dt;
                    rptCarrello.DataBind();

                    decimal totalCartPrice = CalculateTotalCartPrice(dt);
                    lblTotalCartPrice.Text = string.Format("{0:C}", totalCartPrice);
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void AggiungiQuantità_Click(object sender, EventArgs e)
        {
            int IdUtente = Convert.ToInt32(Session["IdUtente"]);

            if (Session["IdUtente"] != null)

            {
                Button btn = (Button)sender;
                int idProdotto = Convert.ToInt32(btn.CommandArgument);

                string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand increaseQuantityCommand = new SqlCommand("UPDATE Carrello SET Quantità = Quantità + 1 WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                    increaseQuantityCommand.Parameters.AddWithValue("@IdUtente", IdUtente);
                    increaseQuantityCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                    increaseQuantityCommand.ExecuteNonQuery();
                    var MasterPage = this.Master as Templates.Master;
                    if (MasterPage != null)
                    {
                        MasterPage.ShowAdmin();
                        MasterPage.UpdateCounter();
                    }
                }

                BindCarrello();
            }

        }


        protected void RimuoviSingolo_Click(object sender, EventArgs e)
        {
            int IdUtente = Convert.ToInt32(Session["IdUtente"]);

            if (Session["IdUtente"] != null)
            {
                Button btn = (Button)sender;
                int idProdotto = Convert.ToInt32(btn.CommandArgument);

                string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand checkQuantityCommand = new SqlCommand("SELECT Quantità FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                    checkQuantityCommand.Parameters.AddWithValue("@IdUtente", IdUtente);
                    checkQuantityCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                    int currentQuantity = Convert.ToInt32(checkQuantityCommand.ExecuteScalar());


                    if (currentQuantity > 1)
                    {
                        SqlCommand removeOneCommand = new SqlCommand("UPDATE Carrello SET Quantità = Quantità - 1 WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                        removeOneCommand.Parameters.AddWithValue("@IdUtente", IdUtente);
                        removeOneCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                        removeOneCommand.ExecuteNonQuery();
                        var MasterPage = this.Master as Templates.Master;
                        if (MasterPage != null)
                        {
                            MasterPage.ShowAdmin();
                            MasterPage.UpdateCounter();
                        }
                    }

                    else

                    {
                        SqlCommand removeProductCommand = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                        removeProductCommand.Parameters.AddWithValue("@IdUtente", IdUtente);
                        removeProductCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                        removeProductCommand.ExecuteNonQuery();
                        var MasterPage = this.Master as Templates.Master;
                        if (MasterPage != null)
                        {
                            MasterPage.ShowAdmin();
                            MasterPage.UpdateCounter();
                        }
                    }
                }

                BindCarrello();
            }

        }

        protected void RimuoviDefinitivamente_Click(object sender, EventArgs e)
        {
            int IdUtente = Convert.ToInt32(Session["IdUtente"]);
            if (Session["IdUtente"] != null)
            {
                Button btn = (Button)sender;
                int idProdotto = Convert.ToInt32(btn.CommandArgument);

                string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand removeProductCommand = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente AND IdProdotto = @IdProdotto", connection);
                    removeProductCommand.Parameters.AddWithValue("@IdUtente", IdUtente);
                    removeProductCommand.Parameters.AddWithValue("@IdProdotto", idProdotto);
                    removeProductCommand.ExecuteNonQuery();
                    var MasterPage = this.Master as Templates.Master;
                    if (MasterPage != null)
                    {
                        MasterPage.ShowAdmin();
                        MasterPage.UpdateCounter();
                    }
                }

                BindCarrello();
            }

        }



        protected void RimuoviTutti_Click(object sender, EventArgs e)
        {
            int IdUtente = Convert.ToInt32(Session["IdUtente"]);
            if (Session["IdUtente"] != null)
            {
                string connectionString = Configuration.GetConnectionString("AzureConnectionString");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM Carrello WHERE IdUtente = @IdUtente", connection);
                    command.Parameters.AddWithValue("@IdUtente", IdUtente);
                    command.ExecuteNonQuery();
                    var MasterPage = this.Master as Templates.Master;
                    if (MasterPage != null)
                    {
                        MasterPage.ShowAdmin();
                        MasterPage.UpdateCounter();
                    }
                }

                BindCarrello();
            }

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


        protected void btnProcediPagamento_Click(object sender, EventArgs e)
        {
            RimuoviTutti_Click(sender, e);
            Response.Redirect("Checkout.aspx");
        }

    }
}