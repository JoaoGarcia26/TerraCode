using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class VendasRepository
    {
        private string connectionString;

        public VendasRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateVenda(DateTime data, string comprador, string motorista, string cpfMotorista, string placaVeiculo, string numDoc, Dictionary<string, int> listaVenda, int plId, int fazendaId, int? safraId)
        {
            try
            {
                if (listaVenda == null || listaVenda.Count == 0)
                {
                    Console.WriteLine("Nenhum produto foi fornecido para a venda.");
                    return false;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var item in listaVenda)
                    {
                        string produto = item.Key;
                        int quantidadeCaixas = item.Value;

                        if (quantidadeCaixas <= 0)
                        {
                            Console.WriteLine($"A quantidade para o produto '{produto}' deve ser maior que zero. Ignorando este produto.");
                            continue;
                        }

                        string query = "INSERT INTO Vendas (Data, Comprador, Motorista, CPFMotorista, PlacaVeiculo, Produto, QuantidadeCaixas, PLId, FazendaId, SafraId, NumDoc) " +
                                       "VALUES (@Data, @Comprador, @Motorista, @CPFMotorista, @PlacaVeiculo, @Produto, @QuantidadeCaixas, @PLId, @FazendaId, @SafraId, @NumDoc)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Data", data);
                            command.Parameters.AddWithValue("@Comprador", comprador);
                            command.Parameters.AddWithValue("@Motorista", motorista);
                            command.Parameters.AddWithValue("@CPFMotorista", cpfMotorista);
                            command.Parameters.AddWithValue("@PlacaVeiculo", placaVeiculo);
                            command.Parameters.AddWithValue("@Produto", produto);
                            command.Parameters.AddWithValue("@QuantidadeCaixas", quantidadeCaixas);
                            command.Parameters.AddWithValue("@PLId", plId);
                            command.Parameters.AddWithValue("@FazendaId", fazendaId);
                            command.Parameters.AddWithValue("@SafraId", (object)safraId ?? DBNull.Value);
                            command.Parameters.AddWithValue("@NumDoc", numDoc);

                            command.ExecuteNonQuery();
                        }
                    }
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

        public Venda GetVendaById(int id)
        {
            Venda venda = null;

            try
            {
                string query = "SELECT * FROM Vendas WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            venda = new Venda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Comprador = reader.GetString(reader.GetOrdinal("Comprador")),
                                Motorista = reader.IsDBNull(reader.GetOrdinal("Motorista")) ? null : reader.GetString(reader.GetOrdinal("Motorista")),
                                CPFMotorista = reader.IsDBNull(reader.GetOrdinal("CPFMotorista")) ? null : reader.GetString(reader.GetOrdinal("CPFMotorista")),
                                PlacaVeiculo = reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo")) ? null : reader.GetString(reader.GetOrdinal("PlacaVeiculo")),
                                Produto = reader.GetString(reader.GetOrdinal("Produto")),
                                NumDoc = reader.GetString(reader.GetOrdinal("NumDoc")),
                                QuantidadeCaixas = reader.GetInt32(reader.GetOrdinal("QuantidadeCaixas")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId")),
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
            return venda;
        }

        public List<Venda> GetAllVendas()
        {
            List<Venda> vendas = new List<Venda>();

            try
            {
                string query = "SELECT * FROM Vendas;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Venda venda = new Venda
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Comprador = reader.GetString(reader.GetOrdinal("Comprador")),
                                Motorista = reader.IsDBNull(reader.GetOrdinal("Motorista")) ? null : reader.GetString(reader.GetOrdinal("Motorista")),
                                CPFMotorista = reader.IsDBNull(reader.GetOrdinal("CPFMotorista")) ? null : reader.GetString(reader.GetOrdinal("CPFMotorista")),
                                PlacaVeiculo = reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo")) ? null : reader.GetString(reader.GetOrdinal("PlacaVeiculo")),
                                Produto = reader.GetString(reader.GetOrdinal("Produto")),
                                NumDoc = reader.GetString(reader.GetOrdinal("NumDoc")),
                                QuantidadeCaixas = reader.GetInt32(reader.GetOrdinal("QuantidadeCaixas")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId")),
                            };

                            vendas.Add(venda);
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

            return vendas;
        }

        public bool UpdateVenda(int id, DateTime data, string comprador, string motorista, string cpfMotorista, string placaVeiculo, string produto, int quantidadeCaixas, int plId)
        {
            try
            {
                string query = "UPDATE Vendas SET Data = @Data, Comprador = @Comprador, Motorista = @Motorista, " +
                               "CPFMotorista = @CPFMotorista, PlacaVeiculo = @PlacaVeiculo, Produto = @Produto, " +
                               "QuantidadeCaixas = @QuantidadeCaixas, PLId = @PLId WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Data", data);
                    command.Parameters.AddWithValue("@Comprador", comprador);
                    command.Parameters.AddWithValue("@Motorista", motorista);
                    command.Parameters.AddWithValue("@CPFMotorista", cpfMotorista);
                    command.Parameters.AddWithValue("@PlacaVeiculo", placaVeiculo);
                    command.Parameters.AddWithValue("@Produto", produto);
                    command.Parameters.AddWithValue("@QuantidadeCaixas", quantidadeCaixas);
                    command.Parameters.AddWithValue("@PLId", plId);

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

        public bool DeleteVenda(int id)
        {
            try
            {
                string query = "DELETE FROM Vendas WHERE Id = @Id";

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