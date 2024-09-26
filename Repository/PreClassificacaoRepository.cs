using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class PreClassificacaoRepository
    {
        private string _connectionString;

        public PreClassificacaoRepository()
        {
            _connectionString = DatabaseConnectionString.ConnectionString;
        }
        public bool CreatePreClassificacao(PreClassificacao preClassificacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO PreClassificacao (Data, FazendaId, PLId, TotalClassificado, PesoAlho8, PesoAlho7, PesoAlho6, PesoAlho5, PesoAlho4, PesoAlho3, PesoIndustrial, Descarte, Perda) VALUES (@Data, @FazendaId, @PLId, @TotalClassificado, @Alho8, @Alho7, @Alho6, @Alho5, @Alho4, @Alho3, @AlhoIndustrial, @Descarte, @Perda)", connection);
                command.Parameters.AddWithValue("@Data", preClassificacao.Data);
                command.Parameters.AddWithValue("@FazendaId", preClassificacao.FazendaId);
                command.Parameters.AddWithValue("@PLId", preClassificacao.PLId);
                command.Parameters.AddWithValue("@TotalClassificado", preClassificacao.TotalClassificado);
                command.Parameters.AddWithValue("@Alho8", preClassificacao.PesoAlho8);
                command.Parameters.AddWithValue("@Alho7", preClassificacao.PesoAlho7);
                command.Parameters.AddWithValue("@Alho6", preClassificacao.PesoAlho6);
                command.Parameters.AddWithValue("@Alho5", preClassificacao.PesoAlho5);
                command.Parameters.AddWithValue("@Alho4", preClassificacao.PesoAlho4);
                command.Parameters.AddWithValue("@Alho3", preClassificacao.PesoAlho3);
                command.Parameters.AddWithValue("@AlhoIndustrial", preClassificacao.PesoIndustrial);
                command.Parameters.AddWithValue("@Descarte", preClassificacao.Descarte);
                command.Parameters.AddWithValue("@Perda", preClassificacao.Perda);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public List<PreClassificacao> GetAllPreClassificacoes()
        {
            var preClassificacoes = new List<PreClassificacao>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM PreClassificacao", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var preClassificacao = new PreClassificacao
                        {
                            Id = (int)reader["Id"],
                            Data = (DateTime)reader["Data"],
                            FazendaId = (int)reader["FazendaId"],
                            PLId = (int)reader["PLId"],
                            TotalClassificado = reader["TotalClassificado"] != DBNull.Value ? Convert.ToSingle(reader["TotalClassificado"]) : 0,
                            PesoAlho8 = reader["PesoAlho8"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho8"]) : 0,
                            PesoAlho7 = reader["PesoAlho7"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho7"]) : 0,
                            PesoAlho6 = reader["PesoAlho6"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho6"]) : 0,
                            PesoAlho5 = reader["PesoAlho5"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho5"]) : 0,
                            PesoAlho4 = reader["PesoAlho4"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho4"]) : 0,
                            PesoAlho3 = reader["PesoAlho3"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho3"]) : 0,
                            PesoIndustrial = reader["PesoIndustrial"] != DBNull.Value ? Convert.ToSingle(reader["PesoIndustrial"]) : 0,
                            Descarte = reader["Descarte"] != DBNull.Value ? Convert.ToSingle(reader["Descarte"]) : 0,
                            Perda = reader["Perda"] != DBNull.Value ? Convert.ToSingle(reader["Perda"]) : 0
                        };
                        preClassificacoes.Add(preClassificacao);
                    }
                }
            }
            return preClassificacoes;
        }

        public PreClassificacao GetPreClassificacoesByData(DateTime dateTime)
        {
            var preRetornada = new PreClassificacao();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM PreClassificacao WHERE Data = @Data", connection);
                command.Parameters.AddWithValue("@Data", dateTime);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var preClassificacao = new PreClassificacao
                        {
                            Id = (int)reader["Id"],
                            Data = (DateTime)reader["Data"],
                            FazendaId = (int)reader["FazendaId"],
                            PLId = (int)reader["PLId"],
                            TotalClassificado = reader["TotalClassificado"] != DBNull.Value ? Convert.ToSingle(reader["TotalClassificado"]) : 0,
                            PesoAlho8 = reader["PesoAlho8"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho8"]) : 0,
                            PesoAlho7 = reader["PesoAlho7"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho7"]) : 0,
                            PesoAlho6 = reader["PesoAlho6"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho6"]) : 0,
                            PesoAlho5 = reader["PesoAlho5"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho5"]) : 0,
                            PesoAlho4 = reader["PesoAlho4"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho4"]) : 0,
                            PesoAlho3 = reader["PesoAlho3"] != DBNull.Value ? Convert.ToSingle(reader["PesoAlho3"]) : 0,
                            PesoIndustrial = reader["PesoIndustrial"] != DBNull.Value ? Convert.ToSingle(reader["PesoIndustrial"]) : 0,
                            Descarte = reader["Descarte"] != DBNull.Value ? Convert.ToSingle(reader["Descarte"]) : 0,
                            Perda = reader["Perda"] != DBNull.Value ? Convert.ToSingle(reader["Perda"]) : 0
                        };
                        preRetornada = preClassificacao;
                    }
                }
            }
            return preRetornada;
        }
    }
}
