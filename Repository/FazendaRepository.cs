using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class FazendaRepository
    {
        private string connectionString;

        public FazendaRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateFazenda(string nome, string localizacao, float Hectare)
        {
            try
            {
                string query = "INSERT INTO Fazendas (Nome, Localizacao, Hectare) VALUES (@Nome, @Localizacao, @Hectare)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Localizacao", localizacao);
                    command.Parameters.AddWithValue("@Hectare", Hectare);

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

        public Fazenda GetFazendaById(int id)
        {
            Fazenda fazenda = null;

            try
            {
                string query = "SELECT * FROM Fazendas WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fazenda = new Fazenda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Localizacao = reader.GetString(reader.GetOrdinal("Localizacao")),
                                Hectare = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("Hectare")))
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
            return fazenda;
        }

        public Fazenda GetFazendaByNome(string nome)
        {
            Fazenda fazenda = null;

            try
            {
                string query = "SELECT * FROM Fazendas WHERE Nome = @Nome;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fazenda = new Fazenda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Localizacao = reader.GetString(reader.GetOrdinal("Localizacao")),
                                Hectare = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("Hectare")))
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
            return fazenda;
        }

        public List<Fazenda> GetAllFazendas()
        {
            List<Fazenda> fazendas = new List<Fazenda>();

            try
            {
                string query = "SELECT * FROM Fazendas;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fazenda fazenda = new Fazenda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Localizacao = reader.GetString(reader.GetOrdinal("Localizacao")),
                                Hectare = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("Hectare")))
                        };

                            fazendas.Add(fazenda);
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
            return fazendas;
        }

        public bool UpdateFazenda(int id, string nome, string localizacao, float Hectare)
        {
            try
            {
                string query = "UPDATE Fazendas SET Nome = @Nome, Localizacao = @Localizacao, Hectare = @Hectare WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Localizacao", localizacao);
                    command.Parameters.AddWithValue("@Hectare", Hectare);

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

        public bool DeleteFazenda(int id)
        {
            try
            {
                string query = "DELETE FROM Fazendas WHERE Id = @Id";

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
