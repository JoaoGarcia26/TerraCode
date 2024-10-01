using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class PLRepository
    {
        private string connectionString;

        public PLRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreatePL(string nome, int fazendaId, string dataDoPlantio, float hectarePlantados, string observacoes, int safraId)
        {
            try
            {
                string query = "INSERT INTO PLs (Nome, FazendaId, DataDoPlantio, HectarePlantados, Observacoes, IdSafra) " +
                               "VALUES (@Nome, @FazendaId, @DataDoPlantio, @HectarePlantados, @Observacoes, @IdSafra)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@FazendaId", fazendaId);
                    command.Parameters.AddWithValue("@DataDoPlantio", dataDoPlantio);
                    command.Parameters.AddWithValue("@HectarePlantados", hectarePlantados);
                    command.Parameters.AddWithValue("@Observacoes", observacoes);
                    command.Parameters.AddWithValue("@IdSafra", safraId);

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

        public PL GetPLById(int id)
        {
            PL pl = null;

            try
            {
                string query = "SELECT * FROM PLs WHERE Id = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pl = new PL
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                DataDoPlantio = reader.GetString(reader.GetOrdinal("DataDoPlantio")),
                                HectarePlantados = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("HectarePlantados"))),
                                Observacoes = reader.GetString(reader.GetOrdinal("Observacoes")),
                                IdSafra = reader.GetInt32(reader.GetOrdinal("IdSafra")),
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
            return pl;
        }

        public PL GetPLByIDeFazenda(int id, string nomeFazenda)
        {
            PL pl = null;

            try
            {
                string query = @"SELECT p.* FROM PLs p INNER JOIN Fazendas f ON p.FazendaId = f.Id WHERE p.Id = @Id AND f.Nome = @NomeFazenda;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NomeFazenda", nomeFazenda);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pl = new PL
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                DataDoPlantio = reader.GetString(reader.GetOrdinal("DataDoPlantio")),
                                HectarePlantados = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("HectarePlantados"))),
                                Observacoes = reader.GetString(reader.GetOrdinal("Observacoes")),
                                IdSafra = reader.GetInt32(reader.GetOrdinal("IdSafra")),
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
            return pl;
        }

        public PL GetPLByNomeeFazenda(string nomePl, string nomeFazenda)
        {
            PL pl = null;

            try
            {
                string query = @"SELECT p.* FROM PLs p INNER JOIN Fazendas f ON p.FazendaId = f.Id WHERE p.Nome = @NomePl AND f.Nome = @NomeFazenda;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NomePl", nomePl);
                    command.Parameters.AddWithValue("@NomeFazenda", nomeFazenda);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pl = new PL
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                DataDoPlantio = reader.GetString(reader.GetOrdinal("DataDoPlantio")),
                                HectarePlantados = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("HectarePlantados"))),
                                Observacoes = reader.GetString(reader.GetOrdinal("Observacoes")),
                                IdSafra = reader.GetInt32(reader.GetOrdinal("IdSafra")),
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
            return pl;
        }

        public List<PL> GetAllPLsByFazenda(string nomeFazenda)
        {
            List<PL> pls = new List<PL>();

            try
            {
                string query = @"SELECT p.* FROM PLs p INNER JOIN Fazendas f ON p.FazendaId = f.Id
                                WHERE f.Nome = @NomeFazenda;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NomeFazenda", nomeFazenda);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PL pl = new PL
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                DataDoPlantio = reader.GetString(reader.GetOrdinal("DataDoPlantio")),
                                HectarePlantados = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("HectarePlantados"))),
                                Observacoes = reader.GetString(reader.GetOrdinal("Observacoes")),
                                IdSafra = reader.GetInt32(reader.GetOrdinal("IdSafra")),
                            };
                            pls.Add(pl);
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

            return pls;
        }


        public List<PL> GetAllPLs()
        {
            List<PL> pls = new List<PL>();

            try
            {
                string query = "SELECT * FROM PLs;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PL pl = new PL
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                DataDoPlantio = reader.GetString(reader.GetOrdinal("DataDoPlantio")),
                                HectarePlantados = Convert.ToSingle(reader.GetValue(reader.GetOrdinal("HectarePlantados"))),
                                Observacoes = reader.GetString(reader.GetOrdinal("Observacoes")),
                                IdSafra = reader.GetInt32(reader.GetOrdinal("IdSafra")),
                            };

                            pls.Add(pl);
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

            return pls;
        }

        public bool UpdatePL(int id, string nome, int fazendaId, DateTime dataDoPlantio, float hectarePlantados, string observacoes, int safraId)
        {
            try
            {
                string query = "UPDATE PLs SET Nome = @Nome, FazendaId = @FazendaId, DataDoPlantio = @DataDoPlantio, " +
                               "HectarePlantados = @HectarePlantados, Observacoes = @Observacoes, IdSafra = @IdSafra WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@FazendaId", fazendaId);
                    command.Parameters.AddWithValue("@DataDoPlantio", dataDoPlantio);
                    command.Parameters.AddWithValue("@HectarePlantados", hectarePlantados);
                    command.Parameters.AddWithValue("@Observacoes", observacoes);
                    command.Parameters.AddWithValue("@IdSafra", safraId);

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

        public bool DeletePL(int id)
        {
            try
            {
                string query = "DELETE FROM PLs WHERE Id = @Id";

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
