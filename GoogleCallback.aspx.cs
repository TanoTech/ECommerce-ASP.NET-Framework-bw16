using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace BW16C
{
    public partial class GoogleCallback : Page
    {
        private IConfiguration Configuration { get; }

        public GoogleCallback()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Carrello"] != null)
            {
                Response.Cookies["Carrello"].Expires = DateTime.Now.AddDays(-1);
            }

            string registeredEmail = GenerateRandomEmail();
            RegisterGoogleUser(registeredEmail);
            PerformGoogleLogin(registeredEmail);
        }

        private void RegisterGoogleUser(string registeredEmail)
        {
            string password = "ciao";

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ListaUtenti (Email, Password, Image, Admin, NomeUtente) VALUES (@Email, @Password, @Image, @Admin, @NomeUtente)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", registeredEmail);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Image", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Google_%22G%22_logo.svg/1024px-Google_%22G%22_logo.svg.png");
                command.Parameters.AddWithValue("@Admin", false);
                command.Parameters.AddWithValue("@NomeUtente", "UtenteGoogle");

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Registrazione utente Google effettuata con successo");
            }
        }

        private void PerformGoogleLogin(string registeredEmail)
        {
            string password = "ciao";

            bool loginSuccessful = ValidateUser(registeredEmail, password);
            if (loginSuccessful)
            {
                int userId = GetUserIdByEmail(registeredEmail);
                Session["IdUtente"] = userId;

                Response.Redirect("Loading.aspx");
            }
            else
            {
                Response.Write("<script>alert('Errore durante il login con Google.');</script>");
            }
        }

        private string GenerateRandomEmail()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomString = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            string randomEmail = $"{randomString}@google.com";

            return randomEmail;
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

        private int GetUserIdByEmail(string email)
        {
            int userId = -1;

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
                    userId = Convert.ToInt32(result);
                }
            }

            return userId;
        }
    }
}