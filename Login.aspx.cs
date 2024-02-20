using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;

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
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (ValidateUser(email, password))
            {
                if (IsAdmin(email))
                {
                    Response.Redirect("admin.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Email o password non valide. Riprova.');</script>");
            }
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
