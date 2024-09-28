using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class MovimentacaoCaixasRepository
    {
        private string connectionString;

        public MovimentacaoCaixasRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool RegistrarMovimentacao(MovimentacaoCaixas movimentacao)
        {
            try
            {
                string query = @"
                    INSERT INTO MovimentacaoCaixas 
                    (QuantidadeCaixas, DataMovimentacao, TipoMovimentacao, FazendaOrigemId, FazendaDestinoId, MotoristaId, VeiculoId, Observacoes)
                    VALUES 
                    (@QuantidadeCaixas, @DataMovimentacao, @TipoMovimentacao, @FazendaOrigemId, @FazendaDestinoId, @MotoristaId, @VeiculoId, @Observacoes)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@QuantidadeCaixas", movimentacao.QuantidadeCaixas);
                    command.Parameters.AddWithValue("@DataMovimentacao", movimentacao.DataMovimentacao);
                    command.Parameters.AddWithValue("@TipoMovimentacao", movimentacao.TipoMovimentacao);
                    command.Parameters.AddWithValue("@FazendaOrigemId", movimentacao.FazendaOrigemId);
                    command.Parameters.AddWithValue("@FazendaDestinoId", movimentacao.FazendaDestinoId);
                    command.Parameters.AddWithValue("@MotoristaId", (object)movimentacao.MotoristaId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@VeiculoId", (object)movimentacao.VeiculoId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Observacoes", (object)movimentacao.Observacoes ?? DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
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

        public List<MovimentacaoCaixas> ObterTodasMovimentacoes()
        {
            List<MovimentacaoCaixas> movimentacoes = new List<MovimentacaoCaixas>();

            try
            {
                string query = "SELECT * FROM MovimentacaoCaixas";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MovimentacaoCaixas movimentacao = new MovimentacaoCaixas()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("MovimentacaoId")),
                                QuantidadeCaixas = reader.GetInt32(reader.GetOrdinal("QuantidadeCaixas")),
                                DataMovimentacao = reader.GetDateTime(reader.GetOrdinal("DataMovimentacao")),
                                TipoMovimentacao = reader.GetString(reader.GetOrdinal("TipoMovimentacao")),
                                FazendaOrigemId = reader.GetInt32(reader.GetOrdinal("FazendaOrigemId")),
                                FazendaDestinoId = reader.GetInt32(reader.GetOrdinal("FazendaDestinoId")),
                                MotoristaId = reader.GetInt32(reader.GetOrdinal("MotoristaId")),
                                VeiculoId = reader.GetInt32(reader.GetOrdinal("VeiculoId")),
                                Observacoes = reader.IsDBNull(reader.GetOrdinal("Observacoes")) ? null : reader.GetString(reader.GetOrdinal("Observacoes")),
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
    }
}
