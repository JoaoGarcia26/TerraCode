using System.Data.SqlClient;
using System;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class CaixaRepository
    {
        private string connectionString;

        public CaixaRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool DiminuirCaixas(int fazendaId, int quantidade)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Fazendas
                        SET CaixasDisponiveis = CaixasDisponiveis - @quantidade
                        WHERE Id = @fazendaId AND CaixasDisponiveis >= @quantidade";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fazendaId", fazendaId);
                    command.Parameters.AddWithValue("@quantidade", quantidade);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro SQL ao diminuir caixas: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral ao diminuir caixas: {ex.Message}");
                return false;
            }
        }

        public bool AumentarCaixas(int fazendaId, int quantidade)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Fazendas
                        SET CaixasDisponiveis = CaixasDisponiveis + @quantidade
                        WHERE Id = @fazendaId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fazendaId", fazendaId);
                    command.Parameters.AddWithValue("@quantidade", quantidade);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro SQL ao aumentar caixas: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral ao aumentar caixas: {ex.Message}");
                return false;
            }
        }

        public int ObterCaixasDisponiveis(int fazendaId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT CaixasDisponiveis
                        FROM Fazendas
                        WHERE Id = @fazendaId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fazendaId", fazendaId);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro SQL ao obter caixas disponíveis: {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro geral ao obter caixas disponíveis: {ex.Message}");
                return 0;
            }
        }
    }
}