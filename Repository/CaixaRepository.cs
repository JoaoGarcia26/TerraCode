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

        public int RetornaTotalDeCaixas()
        {
            try
            {
                string query = "SELECT QuantidadeCaixas FROM Caixas WHERE Id = 1";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    var resultado = command.ExecuteScalar();
                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao obter estoque disponível: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral ao obter estoque disponível: " + ex.Message);
                return 0;
            }
        }
        public bool AtualizarQuantidadeCaixas(int quantidadeAlteracao)
        {
            try
            {
                string selectQuery = "SELECT COUNT(*) FROM Caixas WHERE Id = 1";
                string insertQuery = "INSERT INTO Caixas (Id, QuantidadeCaixas) VALUES (1, 0)";
                string updateQuery = "UPDATE Caixas SET QuantidadeCaixas = QuantidadeCaixas + (@QuantidadeAlteracao) WHERE Id = 1";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(selectQuery, connection);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count == 0)
                    {
                        command = new SqlCommand(insertQuery, connection);
                        command.ExecuteNonQuery();
                    }

                    command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@QuantidadeAlteracao", quantidadeAlteracao);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
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
