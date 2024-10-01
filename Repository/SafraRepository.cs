using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class SafraRepository
    {
        private string connectionString;

        public SafraRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateSafra(string nome, int ano)
        {
            try
            {
                string query = "INSERT INTO Safra (Nome, Ano) VALUES (@Nome, @Ano);";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Ano", ano);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
                return false;
            }
        }

        public Safra GetSafraById(int id)
        {
            Safra safra = null;

            try
            {
                string query = "SELECT * FROM Safra WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            safra = new Safra
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Ano = reader.GetInt32(reader.GetOrdinal("Ano"))
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }
            return safra;
        }

        public Safra GetSafraByNome(string nome)
        {
            Safra safra = null;

            try
            {
                string query = "SELECT * FROM Safra WHERE Nome = @Nome;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            safra = new Safra
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Ano = reader.GetInt32(reader.GetOrdinal("Ano"))
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }
            return safra;
        }

        public List<Safra> GetAllSafras()
        {
            List<Safra> safras = new List<Safra>();

            try
            {
                string query = "SELECT * FROM Safra;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Safra safra = new Safra
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Ano = reader.GetInt32(reader.GetOrdinal("Ano"))
                            };
                            safras.Add(safra);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }

            return safras;
        }

        public bool UpdateSafra(int id, string nome, int ano)
        {
            try
            {
                string query = "UPDATE Safra SET Nome = @Nome, Ano = @Ano WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Ano", ano);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
                return false;
            }
        }

        public bool DeleteSafra(int id)
        {
            try
            {
                string query = "DELETE FROM Safra WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
                return false;
            }
        }
    }
}
