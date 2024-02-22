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
                    PopulateUserData(IdUtente);
                }
            }
        }

        protected void UpdateNameButton_Click(object sender, EventArgs e)
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = (int)Session["IdUtente"];
                string nome = NomeTextBox.Text;

                if (!string.IsNullOrEmpty(nome))
                {
                    UpdateUserName(IdUtente, nome);
                }
            }
        }

        protected void UpdateEmailButton_Click(object sender, EventArgs e)
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = (int)Session["IdUtente"];
                string email = EmailTextBox.Text;

                if (!string.IsNullOrEmpty(email))
                {
                    UpdateUserEmail(IdUtente, email);
                }
            }
        }

        protected void UpdatePasswordButton_Click(object sender, EventArgs e)
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = (int)Session["IdUtente"];
                string newPassword = NewPasswordTextBox.Text;

                if (!string.IsNullOrEmpty(newPassword))
                {
                    UpdatePassword(IdUtente, newPassword);
                }
            }
        }

        protected void UpdateImageButton_Click(object sender, EventArgs e)
        {
            if (Session["IdUtente"] != null)
            {
                int IdUtente = (int)Session["IdUtente"];
                string image = ImmagineTextBox.Text;

                if (!string.IsNullOrEmpty(image))
                {
                    UpdateUserImage(IdUtente, image);
                }
            }
        }

        private string GetUserName(int IdUtente)
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

        private void UpdateUserName(int IdUtente, string nome)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListaUtenti SET NomeUtente = @Nome WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                command.ExecuteNonQuery();
                PopulateUserData(IdUtente);
            }
        }

        private void UpdateUserEmail(int IdUtente, string email)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListaUtenti SET Email = @Email WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                command.ExecuteNonQuery();
                PopulateUserData(IdUtente);
            }
        }

        private void UpdatePassword(int IdUtente, string newPassword)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListaUtenti SET Password = @NewPassword WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewPassword", newPassword);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void UpdateUserImage(int IdUtente, string image)
        {
            string connectionString = Configuration.GetConnectionString("AzureConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ListaUtenti SET Image = @Image WHERE IdUtente = @IdUtente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Image", image);
                command.Parameters.AddWithValue("@IdUtente", IdUtente);

                connection.Open();
                command.ExecuteNonQuery();
                PopulateUserData(IdUtente);
                var MasterPage = this.Master as Templates.Master;
                if (MasterPage != null)
                {
                    MasterPage.ShowUserPicture();
                }
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
