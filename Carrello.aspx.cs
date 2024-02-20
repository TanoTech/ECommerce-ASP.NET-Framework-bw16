using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarrello();
            }
        }

        private void BindCarrello()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureConnectionString"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT p.*, c.Quantità, c.PrezzoTotProdotto FROM Prodotti p INNER JOIN Carrello c ON p.IdProdotto = c.IdProdotto", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptCarrello.DataSource = dt;
                    rptCarrello.DataBind();
                }
            }
        }

        protected void AggiungiQuantita_Click(object sender, EventArgs e)
        {
            Button btnAggiungi =(Button)sender;
            string idProdotto = btnAggiungi.CommandArgument;

            AggiungiProdottoAlCarrello();
            BindCarrello();
        }

        private void AggiungiProdottoAlCarrello(String IdProdotto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureConnectionString"].ToString();
        }

        protected void RimuoviProdotto_Click(object sender, EventArgs e)
        {
            Button btnRimuovi = (Button)sender;
            string idProdotto = btnRimuovi.CommandArgument;

            RimuoviProdottoDalCarrello();
            BindCarrello();
        }


    }
}