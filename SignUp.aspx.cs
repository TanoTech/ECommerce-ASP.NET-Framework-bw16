using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace ECommerce
{
    public partial class SignUp : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public SignUp()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string nomeUtente = txtNomeUte.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Le password non coincidono. Riprova.');</script>");
                return;
            }

            if (!IsValidEmail(email))
            {
                Response.Write("<script>alert('Inserisci un indirizzo email valido.');</script>");
                return;
            }

            RegisterUser(email, password, nomeUtente);
            Response.Redirect("Login.aspx");
        }
        private bool IsValidEmail(string email)
        {
            string emailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegexPattern);
        }

        private void RegisterUser(string email, string password, string nomeUtente)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ListaUtenti (Email, Password, Admin, NomeUtente) VALUES (@Email, @Password, 0, @NomeUtente)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@NomeUtente", nomeUtente);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Registrazione effettuata con successo");
            }
        }

        protected void chkVisualizzaPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVisualizzaPassword.Checked)
            {
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtConfirmPassword.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                txtPassword.TextMode = TextBoxMode.Password;
                txtConfirmPassword.TextMode = TextBoxMode.Password;
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
