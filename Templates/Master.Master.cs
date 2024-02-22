using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace BW16C.Templates
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private IConfiguration Configuration { get; }

        public Master()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");
            houseAdmin.Visible = false;

            if (!IsPostBack)
            {
                ShowUserPicture();
                ShowAdmin();
                UpdateCounter();
            }
        }

        public void CheckIfAdmin()
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");
            if (Session["IdUtente"] != null)
            {
                string IdUtente = Session["IdUtente"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    string query = $"SELECT Admin FROM ListaUtenti WHERE IdUtente = {IdUtente}";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                bool isAdmin = reader.GetBoolean(reader.GetOrdinal("Admin"));
                                if (!isAdmin)
                                {
                                    Response.Redirect("/Home.aspx");
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                Response.Redirect("/Home.aspx");
            }
        }

        public void ShowUserPicture()
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");
            if (Session["IdUtente"] != null)
            {
                loginBtnDiv.Visible = false;
                string IdUtente = Session["IdUtente"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    string query = $"SELECT Image FROM ListaUtenti WHERE IdUtente = {IdUtente}";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                string userImgUrl = reader["Image"].ToString();
                                userPic.Attributes["src"] = userImgUrl;
                            }
                        }
                    }

                }
            }
            else
            {
                profilePic.Visible = false;
                loginBtnDiv.Visible = true;
            }
        }

        public void ShowAdmin()
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");

            if (Session["IdUtente"] != null)
            {
                string IdUtente = Session["IdUtente"].ToString();
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    string query = $"SELECT Admin FROM ListaUtenti WHERE IdUtente = {IdUtente}";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                bool isAdmin = reader.GetBoolean(reader.GetOrdinal("Admin"));
                                if (isAdmin)
                                {
                                    houseAdmin.Visible = true;
                                }
                            }
                        }
                    }

                }
            }
        }

        public void UpdateCounter()
        {
            if (Session["IdUtente"] != null)
            {
                string IdUtente = Session["IdUtente"].ToString();
                string connectionDB = Configuration.GetConnectionString("AzureConnectionString");

                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    string query = $"SELECT count(*) as totCart FROM Carrello WHERE IdUtente = {IdUtente}";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                cartCounter.Text = reader["totCart"].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                cartCounter.Text = "0";
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Login.aspx");
        }
    }
}