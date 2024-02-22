using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class Login : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }
        public Login()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Carrello"] != null)
            {
                Response.Cookies["Carrello"].Expires = DateTime.Now.AddDays(-1);
            }

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (ValidateUser(email, password))
            {
                int IdUtente = GetUserIdByEmail(email);
                Session["IdUtente"] = IdUtente;

                if (IsAdmin(email))
                {
                    Response.Redirect("admin.aspx?IdUtente=" + IdUtente);
                }
                else
                {
                    Response.Redirect("Home.aspx?IdUtente=" + IdUtente);
                }
            }
            else
            {
                Response.Write("<script>alert('Email o password non valide. Riprova.');</script>");
            }
        }

        public int GetUserIdByEmail(string email)
        {
            int IdUtente = -1;

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT IdUtente FROM ListaUtenti WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    IdUtente = Convert.ToInt32(result);
                }
            }

            return IdUtente;
        }

        private bool ValidateUser(string email, string password)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ListaUtenti WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        private bool IsAdmin(string email)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Admin FROM ListaUtenti WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToBoolean(result);
                }
                else
                {
                    return false;
                }
            }
        }
        protected void chkVisualizzaPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizzaPassword.Checked)
            {
                txtPassword.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtPassword.TextMode = TextBoxMode.Password;
            }
        }
        protected void btnAccediConGoogle_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoogleCallback.aspx");
        }
        protected void btnAccediConFacebook_Click(object sender, EventArgs e)
        {
            string redirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home.aspx";
            string facebookClientId = Configuration["FacebookClientId"];
            string facebookAuthorizationUrl = "https://www.facebook.com/v12.0/dialog/oauth?client_id=" + facebookClientId + "&redirect_uri=" + redirectUri + "&response_type=code&scope=email&state=facebook";
            Response.Redirect(facebookAuthorizationUrl);
        }

    }
}