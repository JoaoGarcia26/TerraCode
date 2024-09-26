using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class PosClassificacaoRepository
    {
        private string _connectionString;
        public PosClassificacaoRepository()
        {
            _connectionString = DatabaseConnectionString.ConnectionString;
        }
        public bool CreatePosClassificacao(PosClassificacao posClassificacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO PosClassificacao (PreClassificacaoId, Categoria, Quantidade, Data)
                              VALUES (@PreClassificacaoId, @Categoria, @Quantidade, @Data)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PreClassificacaoId", posClassificacao.PreClassificacaoId);
                    cmd.Parameters.AddWithValue("@Categoria", posClassificacao.Categoria);
                    cmd.Parameters.AddWithValue("@Quantidade", posClassificacao.Quantidade);
                    cmd.Parameters.AddWithValue("@Data", posClassificacao.Data);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        public List<PosClassificacao> GetAllPosClassificacoes()
        {
            var posClassificacoes = new List<PosClassificacao>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM PosClassificacao", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        posClassificacoes.Add(new PosClassificacao
                        {
                            Id = (int)reader["Id"],
                            PreClassificacaoId = (int)reader["PreClassificacaoId"],
                            Categoria = reader["Categoria"].ToString(),
                            Quantidade = reader["Quantidade"] != DBNull.Value ? Convert.ToSingle(reader["Quantidade"]) : 0,
                            Data = (DateTime)reader["Data"]
                        });
                    }
                }
            }
            return posClassificacoes;
        }
    }
}
