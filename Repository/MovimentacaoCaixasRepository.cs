using System;
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
                    (CaixaId, QuantidadeCaixas, DataMovimentacao, TipoMovimentacao, FazendaOrigemId, FazendaDestinoId, PLId, MotoristaId, VeiculoId, Observacoes)
                    VALUES 
                    (@CaixaId, @QuantidadeCaixas, @DataMovimentacao, @TipoMovimentacao, @FazendaOrigemId, @FazendaDestinoId, @PLId, @MotoristaId, @VeiculoId, @Observacoes)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CaixaId", movimentacao.CaixaId);
                    command.Parameters.AddWithValue("@QuantidadeCaixas", movimentacao.QuantidadeCaixas);
                    command.Parameters.AddWithValue("@DataMovimentacao", movimentacao.DataMovimentacao);
                    command.Parameters.AddWithValue("@TipoMovimentacao", movimentacao.TipoMovimentacao);
                    command.Parameters.AddWithValue("@FazendaOrigemId", movimentacao.FazendaOrigemId);
                    command.Parameters.AddWithValue("@FazendaDestinoId", movimentacao.FazendaDestinoId);
                    command.Parameters.AddWithValue("@PLId", (object)movimentacao.PLId ?? DBNull.Value);
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
    }
}
