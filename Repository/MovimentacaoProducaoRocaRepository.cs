using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class MovimentacaoProducaoRocaRepository
    {
        private string connectionString;

        public MovimentacaoProducaoRocaRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateMovimentacao(int motoristaId, int veiculoId, int fazendaId, int plId, float pesoTotal, int numCaixas, DateTime dataEntrada)
        {
            try
            {
                string query = "INSERT INTO ProducaoDaRoca (MotoristaId, VeiculoId, FazendaId, PLId, PesoTotal, NumCaixas, DataEntrada) VALUES (@MotoristaId, @VeiculoId, @FazendaId, @PLId, @PesoTotal, @NumCaixas, @DataEntrada)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MotoristaId", motoristaId);
                    command.Parameters.AddWithValue("@VeiculoId", veiculoId);
                    command.Parameters.AddWithValue("@FazendaId", fazendaId);
                    command.Parameters.AddWithValue("@PLId", plId);
                    command.Parameters.AddWithValue("@PesoTotal", pesoTotal);
                    command.Parameters.AddWithValue("@NumCaixas", numCaixas);
                    command.Parameters.AddWithValue("@DataEntrada", dataEntrada);

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

        public MovimentacaoProducaoRoca GetMovimentacaoById(int id)
        {
            MovimentacaoProducaoRoca movimentacao = null;

            try
            {
                string query = "SELECT * FROM ProducaoDaRoca WHERE IdEntrada = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            movimentacao = new MovimentacaoProducaoRoca
                            {
                                IdEntrada = reader.GetInt32(reader.GetOrdinal("IdEntrada")),
                                DataEntrada = reader.GetDateTime(reader.GetOrdinal("DataEntrada")),
                                MotoristaId = reader.GetInt32(reader.GetOrdinal("MotoristaId")),
                                VeiculoId = reader.GetInt32(reader.GetOrdinal("VeiculoId")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId")),
                                PesoTotal = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("PesoTotal"))),
                                NumCaixas = reader.GetInt32(reader.GetOrdinal("NumCaixas"))
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
            return movimentacao;
        }

        public List<MovimentacaoProducaoRoca> GetAllMovimentacoes()
        {
            List<MovimentacaoProducaoRoca> movimentacoes = new List<MovimentacaoProducaoRoca>();

            try
            {
                string query = "SELECT * FROM ProducaoDaRoca;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MovimentacaoProducaoRoca movimentacao = new MovimentacaoProducaoRoca
                            {
                                IdEntrada = reader.GetInt32(reader.GetOrdinal("IdEntrada")),
                                DataEntrada = reader.GetDateTime(reader.GetOrdinal("DataEntrada")),
                                MotoristaId = reader.GetInt32(reader.GetOrdinal("MotoristaId")),
                                VeiculoId = reader.GetInt32(reader.GetOrdinal("VeiculoId")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId")),
                                PesoTotal = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("PesoTotal"))),
                                NumCaixas = reader.GetInt32(reader.GetOrdinal("NumCaixas"))
                            };

                            movimentacoes.Add(movimentacao);
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
            return movimentacoes;
        }

        public bool UpdateMovimentacao(int idEntrada, int motoristaId, int veiculoId, int fazendaId, int plId, float pesoTotal, int numCaixas, DateTime dataEntrada)
        {
            try
            {
                string query = "UPDATE ProducaoDaRoca SET MotoristaId = @MotoristaId, VeiculoId = @VeiculoId, FazendaId = @FazendaId, PLId = @PLId, PesoTotal = @PesoTotal, NumCaixas = @NumCaixas, DataEntrada = @DataEntrada WHERE IdEntrada = @IdEntrada";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdEntrada", idEntrada);
                    command.Parameters.AddWithValue("@MotoristaId", motoristaId);
                    command.Parameters.AddWithValue("@VeiculoId", veiculoId);
                    command.Parameters.AddWithValue("@FazendaId", fazendaId);
                    command.Parameters.AddWithValue("@PLId", plId);
                    command.Parameters.AddWithValue("@PesoTotal", pesoTotal);
                    command.Parameters.AddWithValue("@NumCaixas", numCaixas);
                    command.Parameters.AddWithValue("@DataEntrada", dataEntrada);

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

        public bool DeleteMovimentacao(int idEntrada)
        {
            try
            {
                string query = "DELETE FROM ProducaoDaRoca WHERE IdEntrada = @IdEntrada";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdEntrada", idEntrada);

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
