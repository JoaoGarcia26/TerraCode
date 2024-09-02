using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class VeiculoRepository
    {
        private string connectionString;

        public VeiculoRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateVeiculo(string placa, string tipoVeiculo, int motoristaId)
        {
            try
            {
                string query = "INSERT INTO Veiculo (Placa, TipoVeiculo, MotoristaId) " +
                               "VALUES (@Placa, @TipoVeiculo, @MotoristaId)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Placa", placa);
                    command.Parameters.AddWithValue("@TipoVeiculo", tipoVeiculo);
                    command.Parameters.AddWithValue("@MotoristaId", motoristaId);

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

        public Veiculo GetVeiculoById(int id)
        {
            Veiculo veiculo = null;

            try
            {
                string query = "SELECT * FROM Veiculo WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            veiculo = new Veiculo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Placa = reader.GetString(reader.GetOrdinal("Placa")),
                                TipoVeiculo = reader.GetString(reader.GetOrdinal("TipoVeiculo")),
                                Motorista = new Motorista
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("MotoristaId"))
                                }
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
            return veiculo;
        }

        public Veiculo GetVeiculoByPlaca(string placa)
        {
            Veiculo veiculo = null;

            try
            {
                string query = "SELECT * FROM Veiculo WHERE Placa = @Placa;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Placa", placa);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            veiculo = new Veiculo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Placa = reader.GetString(reader.GetOrdinal("Placa")),
                                TipoVeiculo = reader.GetString(reader.GetOrdinal("TipoVeiculo")),
                                Motorista = new Motorista
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("MotoristaId"))
                                }
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
            return veiculo;
        }

        public List<Veiculo> GetAllVeiculos()
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            try
            {
                string query = "SELECT * FROM Veiculo;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Veiculo veiculo = new Veiculo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Placa = reader.GetString(reader.GetOrdinal("Placa")),
                                TipoVeiculo = reader.GetString(reader.GetOrdinal("TipoVeiculo")),
                                Motorista = new Motorista
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("MotoristaId"))
                                }
                            };

                            veiculos.Add(veiculo);
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

            return veiculos;
        }

        public List<Veiculo> GetAllVeiculosPorNomeMotorista(string nomeMotorista)
        {
            List<Veiculo> veiculos = new List<Veiculo>();

            try
            {
                string query = @"SELECT v.* FROM Veiculo v INNER JOIN Motorista m ON v.MotoristaId = m.Id
                                WHERE m.Nome = @NomeMotorista;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@NomeMotorista", nomeMotorista);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Veiculo veiculo = new Veiculo
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Placa = reader.GetString(reader.GetOrdinal("Placa")),
                                TipoVeiculo = reader.GetString(reader.GetOrdinal("TipoVeiculo")),
                                Motorista = new Motorista
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("MotoristaId"))
                                }
                            };

                            veiculos.Add(veiculo);
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

            return veiculos;
        }

        public bool UpdateVeiculo(int id, string placa, string tipoVeiculo, int motoristaId)
        {
            try
            {
                string query = "UPDATE Veiculo SET Placa = @Placa, TipoVeiculo = @TipoVeiculo, MotoristaId = @MotoristaId " +
                               "WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Placa", placa);
                    command.Parameters.AddWithValue("@TipoVeiculo", tipoVeiculo);
                    command.Parameters.AddWithValue("@MotoristaId", motoristaId);

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

        public bool DeleteVeiculo(int id)
        {
            try
            {
                string query = "DELETE FROM Veiculo WHERE Id = @Id";

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
