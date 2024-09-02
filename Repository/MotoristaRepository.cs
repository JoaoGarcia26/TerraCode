using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class MotoristaRepository
    {
        private string connectionString;

        public MotoristaRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateMotorista(string nome, string endereco, string cnh, string cpf)
        {
            try
            {
                string query = "INSERT INTO Motorista (Nome, Endereco, CNH, CPF) " +
                               "VALUES (@Nome, @Endereco, @CNH, @CPF)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@CNH", cnh);
                    command.Parameters.AddWithValue("@CPF", cpf);

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

        public Motorista GetMotoristaById(int id)
        {
            Motorista motorista = null;

            try
            {
                string query = "SELECT * FROM Motorista WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            motorista = new Motorista
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                                CNH = reader.GetString(reader.GetOrdinal("CNH")),
                                CPF = reader.GetString(reader.GetOrdinal("CPF"))
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
            return motorista;
        }

        public Motorista GetMotoristaByNome(string nome)
        {
            Motorista motorista = null;

            try
            {
                string query = "SELECT * FROM Motorista WHERE Nome = @Nome;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            motorista = new Motorista
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                                CNH = reader.GetString(reader.GetOrdinal("CNH")),
                                CPF = reader.GetString(reader.GetOrdinal("CPF"))
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
            return motorista;
        }

        public List<Motorista> GetAllMotoristas()
        {
            List<Motorista> motoristas = new List<Motorista>();

            try
            {
                string query = "SELECT * FROM Motorista;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Motorista motorista = new Motorista
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Endereco = reader.GetString(reader.GetOrdinal("Endereco")),
                                CNH = reader.GetString(reader.GetOrdinal("CNH")),
                                CPF = reader.GetString(reader.GetOrdinal("CPF"))
                            };

                            motoristas.Add(motorista);
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

            return motoristas;
        }

        public bool UpdateMotorista(int id, string nome, string endereco, string cnh, string cpf)
        {
            try
            {
                string query = "UPDATE Motorista SET Nome = @Nome, Endereco = @Endereco, CNH = @CNH, CPF = @CPF " +
                               "WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@CNH", cnh);
                    command.Parameters.AddWithValue("@CPF", cpf);

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

        public bool DeleteMotorista(int id)
        {
            try
            {
                string query = "DELETE FROM Motorista WHERE Id = @Id";

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
