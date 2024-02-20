using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BW16C
{
    public partial class Home : System.Web.UI.Page
    {
        private IConfiguration Configuration { get; }

        public Home()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionDB = Configuration.GetConnectionString("AzureConnectionString");

            // ELETTRONICA
            List<dynamic> elettronica = new List<dynamic>();

            using(SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 5";

                using(SqlCommand cmd = new SqlCommand(query,conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            elettronica.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                ElettronicaRepeater.DataSource = elettronica;
                ElettronicaRepeater.DataBind();
            }

            // CASA
            List<dynamic> casa = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 6";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            casa.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                CasaRepeater.DataSource = casa;
                CasaRepeater.DataBind();
            }

            // FAI DA TE
            List<dynamic> faiDaTe = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 7";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            faiDaTe.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                FaiDaTeRepeater.DataSource = faiDaTe;
                FaiDaTeRepeater.DataBind();
            }

            // SPORT
            List<dynamic> sport = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 8";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sport.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                SportRepeater.DataSource = sport;
                SportRepeater.DataBind();
            }

            // ABITI E ACCESSORI
            List<dynamic> abitiEAccessori = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 9";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            abitiEAccessori.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                AbitiEAccessoriRepeater.DataSource = abitiEAccessori;
                AbitiEAccessoriRepeater.DataBind();
            }

            // SALUTE E BELLEZZA
            List<dynamic> saluteEBellezza = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 10";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            saluteEBellezza.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                SaluteEBellezzaRepeater.DataSource = saluteEBellezza;
                SaluteEBellezzaRepeater.DataBind();
            }

            // INTRATTENIMENTO
            List<dynamic> intrattenimento = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 11";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            intrattenimento.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                IntrattenimentoRepeater.DataSource = intrattenimento;
                IntrattenimentoRepeater.DataBind();
            }

            // BAMBINI
            List<dynamic> bambini = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 12";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bambini.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                BambiniRepeater.DataSource = bambini;
                BambiniRepeater.DataBind();
            }

            // ALIMENTAZIONE
            List<dynamic> alimentazione = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionDB))
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE Categoria = 13";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            alimentazione.Add(new
                            {
                                IdProdotto = reader["IdProdotto"],
                                Nome = reader["Nome"],
                                Brand = reader["Brand"],
                                Dettagli = reader["Dettagli"],
                                ImgUrl = reader["ImgUrl"],
                                Prezzo = reader["Prezzo"],
                                Rating = reader["Rating"],
                                Categoria = reader["Categoria"]
                            });
                        }
                    }
                }

                AlimentazioneRepeater.DataSource = alimentazione;
                AlimentazioneRepeater.DataBind();
            }
        }
    }
}