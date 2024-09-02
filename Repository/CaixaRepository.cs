using System.Data.SqlClient;
using System;

namespace TerraCode.Repository
{
    public class CaixaRepository
    {
        private string connectionString;
        public CaixaRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }
        public bool AtualizarQuantidadeCaixas(int quantidadeAlteracao)
        {
            try
            {
                string selectQuery = "SELECT COUNT(*) FROM Caixas WHERE Id = 1";
                string insertQuery = "INSERT INTO Caixas (Id, QuantidadeCaixas) VALUES (1, 0)";
                string updateQuery = "UPDATE Caixas SET QuantidadeCaixas = QuantidadeCaixas + @QuantidadeAlteracao WHERE Id = 1";

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
