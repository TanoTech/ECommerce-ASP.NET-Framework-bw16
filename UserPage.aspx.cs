using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BW16C
{
    public partial class UserPage : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public UserPage()
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
                    int IdUtente = (int)Session["IdUtente"];
                    string nomeUtente = GetUserName(IdUtente);
                    UserNameLiteral.Text = nomeUtente;

                    PopulateUserData(IdUtente);
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = (int)Session["IdUtente"];
                string email = EmailTextBox.Text;
                string password = PasswordTextBox.Text;
                string nome = NomeTextBox.Text;
                string image= ImmagineTextBox.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(image))
                {
                    return;
                }

                UpdateUserData(IdUtente, email, password, nome, image);
            }
        }

        public string GetUserName(int IdUtente)
        {
            string userName = "";

            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT NomeUtente FROM ListaUtenti WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userName = reader.GetString(0);
                    }
                }
            }

            return userName;
        }

        private void PopulateUserData(int IdUtente)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Email, NomeUtente, Image FROM ListaUtenti WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                        {
                            ImmagineTextBox.Text = reader.GetString(reader.GetOrdinal("Image"));
                            UserImage.Src = reader.GetString(reader.GetOrdinal("Image"));
                        }

                        EmailTextBox.Text = reader.GetString(reader.GetOrdinal("Email"));
                        NomeTextBox.Text = reader.GetString(reader.GetOrdinal("NomeUtente"));
                    }
                }
            }
        }

        private void UpdateUserData(int IdUtente, string email, string password, string nome, string image)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListaUtenti SET Email = @Email, Password = @Password, NomeUtente = @Nome, Image = @Image WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Image", image);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}