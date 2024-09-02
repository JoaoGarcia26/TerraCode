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
                // Verifica o estoque disponível antes de registrar a movimentação
                int estoqueDisponivel = ObterEstoqueDisponivel(movimentacao.CaixaId);

                if (movimentacao.TipoMovimentacao == "Saída" && movimentacao.QuantidadeCaixas > estoqueDisponivel)
                {
                    Console.WriteLine("Erro: Estoque insuficiente.");
                    return false;
                }

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

        private int ObterEstoqueDisponivel(int caixaId)
        {
            try
            {
                string query = "SELECT QuantidadeCaixas FROM Caixas WHERE Id = @CaixaId";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CaixaId", caixaId);

                    connection.Open();
                    var resultado = command.ExecuteScalar();
                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                    return 0; // Se não houver resultado, considera que o estoque é 0
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao obter estoque disponível: " + ex.Message);
                return 0; // Retorna 0 em caso de erro
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral ao obter estoque disponível: " + ex.Message);
                return 0; // Retorna 0 em caso de erro
            }
        }
    }
}
