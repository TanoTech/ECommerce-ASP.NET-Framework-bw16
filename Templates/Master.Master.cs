using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
            string isAdmin = "";

            if (!IsPostBack)
            {
                houseAdmin.Visible = false;

                if (Session["IdUtente"] != null)
                {
                    string IdUtente = Session["IdUtente"].ToString();
                    using (SqlConnection connection = new SqlConnection(connectionDB))
                    {
                        string query = $"SELECT * FROM ListaUtenti WHERE IdUtente = {IdUtente}";
                        SqlCommand command = new SqlCommand(query, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    isAdmin = reader["IdUtente"].ToString();
                                }
                            }
                        }

                    }
                }

                if (isAdmin == "1")
                {
                    houseAdmin.Visible = true;
                }

            }
        }
    }
}