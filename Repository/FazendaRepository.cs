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

        public bool CreateFazenda(string nome, string localizacao, bool isBarracao)
        {
            try
            {
                string query = "INSERT INTO Fazendas (Nome, Localizacao, IsBarracao) VALUES (@Nome, @Localizacao, @IsBarracao)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Localizacao", localizacao);
                    command.Parameters.AddWithValue("@IsBarracao", isBarracao);

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
                                IsBarracao = reader.GetBoolean(reader.GetOrdinal("IsBarracao"))
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
                                IsBarracao = reader.GetBoolean(reader.GetOrdinal("IsBarracao"))
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
                string query = "SELECT * FROM Fazendas WHERE IsBarracao = 0;";

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
                                IsBarracao = reader.GetBoolean(reader.GetOrdinal("IsBarracao"))
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

        public bool UpdateFazenda(int id, string nome, string localizacao, bool isBarracao)
        {
            try
            {
                string query = "UPDATE Fazendas SET Nome = @Nome, Localizacao = @Localizacao, IsBarracao = @IsBarracao WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Localizacao", localizacao);
                    command.Parameters.AddWithValue("@IsBarracao", isBarracao);

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

        public List<Fazenda> GetSomenteBarracoes()
        {
            List<Fazenda> barracoes = new List<Fazenda>();

            try
            {
                string query = "SELECT * FROM Fazendas WHERE IsBarracao = 1;";

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
                                IsBarracao = reader.GetBoolean(reader.GetOrdinal("IsBarracao"))
                            };

                            barracoes.Add(fazenda);
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
            return barracoes;
        }
    }
}
