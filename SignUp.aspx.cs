using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;

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
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (password != confirmPassword)
            {
                Response.Write("<script>alert('Le password non coincidono. Riprova.');</script>");
                return;
            }

            RegisterUser(email, password);
            Response.Redirect("Login.aspx");
        }

        private void RegisterUser(string email, string password)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ListaUtenti (Email, Password, Admin) VALUES (@Email, @Password, 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        protected void btnAccediConGoogle_Click(object sender, EventArgs e)
        {
            string redirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Home.aspx";
            string googleClientId = Configuration["GoogleClientId"];
            string googleAuthorizationUrl = "https://accounts.google.com/o/oauth2/auth?client_id=" + googleClientId + "&redirect_uri=" + redirectUri + "&response_type=code&scope=email%20profile&state=google";
            Response.Redirect(googleAuthorizationUrl);
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