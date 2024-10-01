using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TerraCode.Model;

namespace TerraCode.Repository
{
    public class EstoqueRepository
    {
        private string connectionString;

        public EstoqueRepository()
        {
            connectionString = DatabaseConnectionString.ConnectionString;
        }

        public bool CreateEstoque(Estoque estoque)
        {
            try
            {
                string query = @"
            INSERT INTO Estoque (Data, Evento, DocNr, Extra8, Cat8, Especial8, Escovado8, Comercial8,
                                 Extra7, Cat7, Especial7, Escovado7, Comercial7,
                                 Extra6, Cat6, Especial6, Escovado6, Comercial6,
                                 Extra5, Cat5, Especial5, Escovado5, Comercial5,
                                 Extra4, Cat4, Especial4, Escovado4, Comercial4,
                                 Escovado3, Borrado20kg, Escovado2_3, Industrial20kg, Dente20kg, FazendaId, PLId)
            VALUES (@Data, @Evento, @DocNr, @Extra8, @Cat8, @Especial8, @Escovado8, @Comercial8,
                    @Extra7, @Cat7, @Especial7, @Escovado7, @Comercial7,
                    @Extra6, @Cat6, @Especial6, @Escovado6, @Comercial6,
                    @Extra5, @Cat5, @Especial5, @Escovado5, @Comercial5,
                    @Extra4, @Cat4, @Especial4, @Escovado4, @Comercial4,
                    @Escovado3, @Borrado20kg, @Escovado2_3, @Industrial20kg, @Dente20kg, @FazendaId, @PLId)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Data", estoque.Data);
                    command.Parameters.AddWithValue("@Evento", estoque.Evento);
                    command.Parameters.AddWithValue("@DocNr", estoque.DocNr);
                    command.Parameters.AddWithValue("@Extra8", estoque.Extra8 ?? 0);
                    command.Parameters.AddWithValue("@Cat8", estoque.Cat8 ?? 0);
                    command.Parameters.AddWithValue("@Especial8", estoque.Especial8 ?? 0);
                    command.Parameters.AddWithValue("@Escovado8", estoque.Escovado8 ?? 0);
                    command.Parameters.AddWithValue("@Comercial8", estoque.Comercial8 ?? 0);

                    command.Parameters.AddWithValue("@Extra7", estoque.Extra7 ?? 0);
                    command.Parameters.AddWithValue("@Cat7", estoque.Cat7 ?? 0);
                    command.Parameters.AddWithValue("@Especial7", estoque.Especial7 ?? 0);
                    command.Parameters.AddWithValue("@Escovado7", estoque.Escovado7 ?? 0);
                    command.Parameters.AddWithValue("@Comercial7", estoque.Comercial7 ?? 0);

                    command.Parameters.AddWithValue("@Extra6", estoque.Extra6 ?? 0);
                    command.Parameters.AddWithValue("@Cat6", estoque.Cat6 ?? 0);
                    command.Parameters.AddWithValue("@Especial6", estoque.Especial6 ?? 0);
                    command.Parameters.AddWithValue("@Escovado6", estoque.Escovado6 ?? 0);
                    command.Parameters.AddWithValue("@Comercial6", estoque.Comercial6 ?? 0);

                    command.Parameters.AddWithValue("@Extra5", estoque.Extra5 ?? 0);
                    command.Parameters.AddWithValue("@Cat5", estoque.Cat5 ?? 0);
                    command.Parameters.AddWithValue("@Especial5", estoque.Especial5 ?? 0);
                    command.Parameters.AddWithValue("@Escovado5", estoque.Escovado5 ?? 0);
                    command.Parameters.AddWithValue("@Comercial5", estoque.Comercial5 ?? 0);

                    command.Parameters.AddWithValue("@Extra4", estoque.Extra4 ?? 0);
                    command.Parameters.AddWithValue("@Cat4", estoque.Cat4 ?? 0);
                    command.Parameters.AddWithValue("@Especial4", estoque.Especial4 ?? 0);
                    command.Parameters.AddWithValue("@Escovado4", estoque.Escovado4 ?? 0);
                    command.Parameters.AddWithValue("@Comercial4", estoque.Comercial4 ?? 0);

                    command.Parameters.AddWithValue("@Escovado3", estoque.Escovado3 ?? 0);
                    command.Parameters.AddWithValue("@Borrado20kg", estoque.Borrado20kg ?? 0);
                    command.Parameters.AddWithValue("@Escovado2_3", estoque.Escovado2_3 ?? 0);
                    command.Parameters.AddWithValue("@Industrial20kg", estoque.Industrial20kg ?? 0);
                    command.Parameters.AddWithValue("@Dente20kg", estoque.Dente20kg ?? 0);
                    command.Parameters.AddWithValue("@FazendaId", estoque.FazendaId);
                    command.Parameters.AddWithValue("@PLId", estoque.PLId);

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

        public Dictionary<string, int> GetEstoqueAtual(int fazendaId, int plId, string evento)
        {
            var estoqueAtual = new Dictionary<string, int>();
            string query = @"
            SELECT 
                SUM(Extra8) AS TotalExtra8,
                SUM(Cat8) AS TotalCat8,
                SUM(Especial8) AS TotalEspecial8,
                SUM(Escovado8) AS TotalEscovado8,
                SUM(Comercial8) AS TotalComercial8,
                SUM(Extra7) AS TotalExtra7,
                SUM(Cat7) AS TotalCat7,
                SUM(Especial7) AS TotalEspecial7,
                SUM(Escovado7) AS TotalEscovado7,
                SUM(Comercial7) AS TotalComercial7,
                SUM(Extra6) AS TotalExtra6,
                SUM(Cat6) AS TotalCat6,
                SUM(Especial6) AS TotalEspecial6,
                SUM(Escovado6) AS TotalEscovado6,
                SUM(Comercial6) AS TotalComercial6,
                SUM(Extra5) AS TotalExtra5,
                SUM(Cat5) AS TotalCat5,
                SUM(Especial5) AS TotalEspecial5,
                SUM(Escovado5) AS TotalEscovado5,
                SUM(Comercial5) AS TotalComercial5,
                SUM(Extra4) AS TotalExtra4,
                SUM(Cat4) AS TotalCat4,
                SUM(Especial4) AS TotalEspecial4,
                SUM(Escovado4) AS TotalEscovado4,
                SUM(Comercial4) AS TotalComercial4,
                SUM(Escovado3) AS TotalEscovado3,
                SUM(Borrado20kg) AS TotalBorrado20kg,
                SUM(Escovado2_3) AS TotalEscovado2_3,
                SUM(Industrial20kg) AS TotalIndustrial20kg,
                SUM(Dente20kg) AS TotalDente20kg
            FROM Estoque
            WHERE FazendaId = @FazendaId AND PLId = @PLId AND Evento = @Evento
            GROUP BY FazendaId, PLId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FazendaId", fazendaId);
                command.Parameters.AddWithValue("@PLId", plId);
                command.Parameters.AddWithValue("@Evento", evento);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        estoqueAtual["Extra 8"] = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        estoqueAtual["Cat 8"] = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        estoqueAtual["Especial 8"] = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        estoqueAtual["Escovado 8"] = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        estoqueAtual["Comercial 8"] = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        estoqueAtual["Extra 7"] = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                        estoqueAtual["Cat 7"] = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                        estoqueAtual["Especial 7"] = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                        estoqueAtual["Escovado 7"] = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        estoqueAtual["Comercial 7"] = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        estoqueAtual["Extra 6"] = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
                        estoqueAtual["Cat 6"] = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                        estoqueAtual["Especial 6"] = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                        estoqueAtual["Escovado 6"] = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
                        estoqueAtual["Comercial 6"] = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
                        estoqueAtual["Extra 5"] = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                        estoqueAtual["Cat 5"] = reader.IsDBNull(16) ? 0 : reader.GetInt32(16);
                        estoqueAtual["Especial 5"] = reader.IsDBNull(17) ? 0 : reader.GetInt32(17);
                        estoqueAtual["Escovado 5"] = reader.IsDBNull(18) ? 0 : reader.GetInt32(18);
                        estoqueAtual["Comercial 5"] = reader.IsDBNull(19) ? 0 : reader.GetInt32(19);
                        estoqueAtual["Extra 4"] = reader.IsDBNull(20) ? 0 : reader.GetInt32(20);
                        estoqueAtual["Cat 4"] = reader.IsDBNull(21) ? 0 : reader.GetInt32(21);
                        estoqueAtual["Especial 4"] = reader.IsDBNull(22) ? 0 : reader.GetInt32(22);
                        estoqueAtual["Escovado 4"] = reader.IsDBNull(23) ? 0 : reader.GetInt32(23);
                        estoqueAtual["Comercial 4"] = reader.IsDBNull(24) ? 0 : reader.GetInt32(24);
                        estoqueAtual["Escovado 3"] = reader.IsDBNull(25) ? 0 : reader.GetInt32(25);
                        estoqueAtual["Borrado 20kg"] = reader.IsDBNull(26) ? 0 : reader.GetInt32(26);
                        estoqueAtual["Escovado 2/3"] = reader.IsDBNull(27) ? 0 : reader.GetInt32(27);
                        estoqueAtual["Industrial 20kg"] = reader.IsDBNull(28) ? 0 : reader.GetInt32(28);
                        estoqueAtual["Dente 20kg"] = reader.IsDBNull(29) ? 0 : reader.GetInt32(29);
                    }
                }
            }
            return estoqueAtual;
        }

        public Estoque GetEstoqueById(int id)
        {
            Estoque estoque = null;

            try
            {
                string query = "SELECT * FROM Estoque WHERE ID = @Id;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estoque = new Estoque
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Evento = reader.GetString(reader.GetOrdinal("Evento")),
                                DocNr = reader.GetString(reader.GetOrdinal("DocNr")),
                                Extra8 = reader.GetInt32(reader.GetOrdinal("Extra8")),
                                Cat8 = reader.GetInt32(reader.GetOrdinal("Cat8")),
                                Especial8 = reader.GetInt32(reader.GetOrdinal("Especial8")),
                                Escovado8 = reader.GetInt32(reader.GetOrdinal("Escovado8")),
                                Comercial8 = reader.GetInt32(reader.GetOrdinal("Comercial8")),
                                Extra7 = reader.GetInt32(reader.GetOrdinal("Extra7")),
                                Cat7 = reader.GetInt32(reader.GetOrdinal("Cat7")),
                                Especial7 = reader.GetInt32(reader.GetOrdinal("Especial7")),
                                Escovado7 = reader.GetInt32(reader.GetOrdinal("Escovado7")),
                                Comercial7 = reader.GetInt32(reader.GetOrdinal("Comercial7")),
                                Extra6 = reader.GetInt32(reader.GetOrdinal("Extra6")),
                                Cat6 = reader.GetInt32(reader.GetOrdinal("Cat6")),
                                Especial6 = reader.GetInt32(reader.GetOrdinal("Especial6")),
                                Escovado6 = reader.GetInt32(reader.GetOrdinal("Escovado6")),
                                Comercial6 = reader.GetInt32(reader.GetOrdinal("Comercial6")),
                                Extra5 = reader.GetInt32(reader.GetOrdinal("Extra5")),
                                Cat5 = reader.GetInt32(reader.GetOrdinal("Cat5")),
                                Especial5 = reader.GetInt32(reader.GetOrdinal("Especial5")),
                                Escovado5 = reader.GetInt32(reader.GetOrdinal("Escovado5")),
                                Comercial5 = reader.GetInt32(reader.GetOrdinal("Comercial5")),
                                Extra4 = reader.GetInt32(reader.GetOrdinal("Extra4")),
                                Cat4 = reader.GetInt32(reader.GetOrdinal("Cat4")),
                                Especial4 = reader.GetInt32(reader.GetOrdinal("Especial4")),
                                Escovado4 = reader.GetInt32(reader.GetOrdinal("Escovado4")),
                                Comercial4 = reader.GetInt32(reader.GetOrdinal("Comercial4")),
                                Escovado3 = reader.GetInt32(reader.GetOrdinal("Escovado3")),
                                Borrado20kg = reader.GetInt32(reader.GetOrdinal("Borrado20kg")),
                                Escovado2_3 = reader.GetInt32(reader.GetOrdinal("Escovado2_3")),
                                Industrial20kg = reader.GetInt32(reader.GetOrdinal("Industrial20kg")),
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId"))
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
            return estoque;
        }

        public Estoque GetEstoqueByNumDoc(string numDoc)
        {
            Estoque estoque = null;

            try
            {
                string query = "SELECT * FROM Estoque WHERE DocNr = @NumDoc;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NumDoc", numDoc);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estoque = new Estoque
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Evento = reader.GetString(reader.GetOrdinal("Evento")),
                                DocNr = reader.GetString(reader.GetOrdinal("DocNr")),
                                Extra8 = reader.GetInt32(reader.GetOrdinal("Extra8")),
                                Cat8 = reader.GetInt32(reader.GetOrdinal("Cat8")),
                                Especial8 = reader.GetInt32(reader.GetOrdinal("Especial8")),
                                Escovado8 = reader.GetInt32(reader.GetOrdinal("Escovado8")),
                                Comercial8 = reader.GetInt32(reader.GetOrdinal("Comercial8")),
                                Extra7 = reader.GetInt32(reader.GetOrdinal("Extra7")),
                                Cat7 = reader.GetInt32(reader.GetOrdinal("Cat7")),
                                Especial7 = reader.GetInt32(reader.GetOrdinal("Especial7")),
                                Escovado7 = reader.GetInt32(reader.GetOrdinal("Escovado7")),
                                Comercial7 = reader.GetInt32(reader.GetOrdinal("Comercial7")),
                                Extra6 = reader.GetInt32(reader.GetOrdinal("Extra6")),
                                Cat6 = reader.GetInt32(reader.GetOrdinal("Cat6")),
                                Especial6 = reader.GetInt32(reader.GetOrdinal("Especial6")),
                                Escovado6 = reader.GetInt32(reader.GetOrdinal("Escovado6")),
                                Comercial6 = reader.GetInt32(reader.GetOrdinal("Comercial6")),
                                Extra5 = reader.GetInt32(reader.GetOrdinal("Extra5")),
                                Cat5 = reader.GetInt32(reader.GetOrdinal("Cat5")),
                                Especial5 = reader.GetInt32(reader.GetOrdinal("Especial5")),
                                Escovado5 = reader.GetInt32(reader.GetOrdinal("Escovado5")),
                                Comercial5 = reader.GetInt32(reader.GetOrdinal("Comercial5")),
                                Extra4 = reader.GetInt32(reader.GetOrdinal("Extra4")),
                                Cat4 = reader.GetInt32(reader.GetOrdinal("Cat4")),
                                Especial4 = reader.GetInt32(reader.GetOrdinal("Especial4")),
                                Escovado4 = reader.GetInt32(reader.GetOrdinal("Escovado4")),
                                Comercial4 = reader.GetInt32(reader.GetOrdinal("Comercial4")),
                                Escovado3 = reader.GetInt32(reader.GetOrdinal("Escovado3")),
                                Borrado20kg = reader.GetInt32(reader.GetOrdinal("Borrado20kg")),
                                Escovado2_3 = reader.GetInt32(reader.GetOrdinal("Escovado2_3")),
                                Industrial20kg = reader.GetInt32(reader.GetOrdinal("Industrial20kg")),
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId"))
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
            return estoque;
        }

        public List<Estoque> GetAllEstoques()
        {
            List<Estoque> estoques = new List<Estoque>();

            try
            {
                string query = "SELECT * FROM Estoque;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estoque estoque = new Estoque
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Evento = reader.GetString(reader.GetOrdinal("Evento")),
                                DocNr = reader.GetString(reader.GetOrdinal("DocNr")),
                                Extra8 = reader.GetInt32(reader.GetOrdinal("Extra8")),
                                Cat8 = reader.GetInt32(reader.GetOrdinal("Cat8")),
                                Especial8 = reader.GetInt32(reader.GetOrdinal("Especial8")),
                                Escovado8 = reader.GetInt32(reader.GetOrdinal("Escovado8")),
                                Comercial8 = reader.GetInt32(reader.GetOrdinal("Comercial8")),
                                Extra7 = reader.GetInt32(reader.GetOrdinal("Extra7")),
                                Cat7 = reader.GetInt32(reader.GetOrdinal("Cat7")),
                                Especial7 = reader.GetInt32(reader.GetOrdinal("Especial7")),
                                Escovado7 = reader.GetInt32(reader.GetOrdinal("Escovado7")),
                                Comercial7 = reader.GetInt32(reader.GetOrdinal("Comercial7")),
                                Extra6 = reader.GetInt32(reader.GetOrdinal("Extra6")),
                                Cat6 = reader.GetInt32(reader.GetOrdinal("Cat6")),
                                Especial6 = reader.GetInt32(reader.GetOrdinal("Especial6")),
                                Escovado6 = reader.GetInt32(reader.GetOrdinal("Escovado6")),
                                Comercial6 = reader.GetInt32(reader.GetOrdinal("Comercial6")),
                                Extra5 = reader.GetInt32(reader.GetOrdinal("Extra5")),
                                Cat5 = reader.GetInt32(reader.GetOrdinal("Cat5")),
                                Especial5 = reader.GetInt32(reader.GetOrdinal("Especial5")),
                                Escovado5 = reader.GetInt32(reader.GetOrdinal("Escovado5")),
                                Comercial5 = reader.GetInt32(reader.GetOrdinal("Comercial5")),
                                Extra4 = reader.GetInt32(reader.GetOrdinal("Extra4")),
                                Cat4 = reader.GetInt32(reader.GetOrdinal("Cat4")),
                                Especial4 = reader.GetInt32(reader.GetOrdinal("Especial4")),
                                Escovado4 = reader.GetInt32(reader.GetOrdinal("Escovado4")),
                                Comercial4 = reader.GetInt32(reader.GetOrdinal("Comercial4")),
                                Escovado3 = reader.GetInt32(reader.GetOrdinal("Escovado3")),
                                Borrado20kg = reader.GetInt32(reader.GetOrdinal("Borrado20kg")),
                                Escovado2_3 = reader.GetInt32(reader.GetOrdinal("Escovado2_3")),
                                Industrial20kg = reader.GetInt32(reader.GetOrdinal("Industrial20kg")),
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId"))
                            };

                            estoques.Add(estoque);
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
            return estoques;
        }

        public bool UpdateEstoque(Estoque estoque)
        {
            try
            {
                string query = @"
                    UPDATE Estoque SET 
                        Data = @Data,
                        Evento = @Evento,
                        DocNr = @DocNr,
                        Extra8 = @Extra8,
                        Cat8 = @Cat8,
                        Especial8 = @Especial8,
                        Escovado8 = @Escovado8,
                        Comercial8 = @Comercial8,
                        Extra7 = @Extra7,
                        Cat7 = @Cat7,
                        Especial7 = @Especial7,
                        Escovado7 = @Escovado7,
                        Comercial7 = @Comercial7,
                        Extra6 = @Extra6,
                        Cat6 = @Cat6,
                        Especial6 = @Especial6,
                        Escovado6 = @Escovado6,
                        Comercial6 = @Comercial6,
                        Extra5 = @Extra5,
                        Cat5 = @Cat5,
                        Especial5 = @Especial5,
                        Escovado5 = @Escovado5,
                        Comercial5 = @Comercial5,
                        Extra4 = @Extra4,
                        Cat4 = @Cat4,
                        Especial4 = @Especial4,
                        Escovado4 = @Escovado4,
                        Comercial4 = @Comercial4,
                        Escovado3 = @Escovado3,
                        Borrado20kg = @Borrado20kg,
                        Escovado2_3 = @Escovado2_3,
                        Industrial20kg = @Industrial20kg,
                        Dente20kg = @Dente20kg,
                        FazendaId = @FazendaId,
                        PLId = @PLId
                    WHERE ID = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", estoque.ID);
                    command.Parameters.AddWithValue("@Data", estoque.Data);
                    command.Parameters.AddWithValue("@Evento", estoque.Evento);
                    command.Parameters.AddWithValue("@DocNr", estoque.DocNr);
                    command.Parameters.AddWithValue("@Extra8", estoque.Extra8);
                    command.Parameters.AddWithValue("@Cat8", estoque.Cat8);
                    command.Parameters.AddWithValue("@Especial8", estoque.Especial8);
                    command.Parameters.AddWithValue("@Escovado8", estoque.Escovado8);
                    command.Parameters.AddWithValue("@Comercial8", estoque.Comercial8);
                    command.Parameters.AddWithValue("@Extra7", estoque.Extra7);
                    command.Parameters.AddWithValue("@Cat7", estoque.Cat7);
                    command.Parameters.AddWithValue("@Especial7", estoque.Especial7);
                    command.Parameters.AddWithValue("@Escovado7", estoque.Escovado7);
                    command.Parameters.AddWithValue("@Comercial7", estoque.Comercial7);
                    command.Parameters.AddWithValue("@Extra6", estoque.Extra6);
                    command.Parameters.AddWithValue("@Cat6", estoque.Cat6);
                    command.Parameters.AddWithValue("@Especial6", estoque.Especial6);
                    command.Parameters.AddWithValue("@Escovado6", estoque.Escovado6);
                    command.Parameters.AddWithValue("@Comercial6", estoque.Comercial6);
                    command.Parameters.AddWithValue("@Extra5", estoque.Extra5);
                    command.Parameters.AddWithValue("@Cat5", estoque.Cat5);
                    command.Parameters.AddWithValue("@Especial5", estoque.Especial5);
                    command.Parameters.AddWithValue("@Escovado5", estoque.Escovado5);
                    command.Parameters.AddWithValue("@Comercial5", estoque.Comercial5);
                    command.Parameters.AddWithValue("@Extra4", estoque.Extra4);
                    command.Parameters.AddWithValue("@Cat4", estoque.Cat4);
                    command.Parameters.AddWithValue("@Especial4", estoque.Especial4);
                    command.Parameters.AddWithValue("@Escovado4", estoque.Escovado4);
                    command.Parameters.AddWithValue("@Comercial4", estoque.Comercial4);
                    command.Parameters.AddWithValue("@Escovado3", estoque.Escovado3);
                    command.Parameters.AddWithValue("@Borrado20kg", estoque.Borrado20kg);
                    command.Parameters.AddWithValue("@Escovado2_3", estoque.Escovado2_3);
                    command.Parameters.AddWithValue("@Industrial20kg", estoque.Industrial20kg);
                    command.Parameters.AddWithValue("@Dente20kg", estoque.Dente20kg);
                    command.Parameters.AddWithValue("@FazendaId", estoque.FazendaId);
                    command.Parameters.AddWithValue("@PLId", estoque.PLId);

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

        public List<Estoque> RetornaEstoquesFiltrado(DateTime? dataInicial, DateTime? dataFinal, string evento, string documento, int? fazendaId, int? plId, int? safraId)
        {
            List<Estoque> estoques = new List<Estoque>();
            Console.WriteLine($"{dataInicial} {dataFinal}, {evento}, {documento}, {fazendaId}, {plId}, {safraId}");

            try
            {
                string query = @"SELECT * FROM Estoque E
                        JOIN PLs P ON E.PLId = P.Id
                        WHERE (@DataInicial IS NULL OR CAST(E.Data AS DATE) >= CAST(@DataInicial AS DATE))
                          AND (@DataFinal IS NULL OR CAST(E.Data AS DATE) <= CAST(@DataFinal AS DATE))
                          AND (@Evento IS NULL OR E.Evento LIKE '%' + @Evento + '%')
                          AND (@Documento IS NULL OR E.DocNr LIKE '%' + @Documento + '%')
                          AND (@FazendaId IS NULL OR E.FazendaId = @FazendaId)
                          AND (@PLId IS NULL OR E.PLId = @PLId)
                          AND (@SafraId IS NULL OR P.IdSafra = @SafraId);";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DataInicial", (object)dataInicial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DataFinal", (object)dataFinal ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Evento", string.IsNullOrEmpty(evento) ? (object)DBNull.Value : evento);
                    command.Parameters.AddWithValue("@Documento", string.IsNullOrEmpty(documento) ? (object)DBNull.Value : documento);
                    command.Parameters.AddWithValue("@FazendaId", (object)fazendaId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PLId", (object)plId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SafraId", (object)safraId ?? DBNull.Value);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estoque estoque = new Estoque
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Evento = reader.GetString(reader.GetOrdinal("Evento")),
                                DocNr = reader.GetString(reader.GetOrdinal("DocNr")),
                                Extra8 = reader.GetInt32(reader.GetOrdinal("Extra8")),
                                Cat8 = reader.GetInt32(reader.GetOrdinal("Cat8")),
                                Especial8 = reader.GetInt32(reader.GetOrdinal("Especial8")),
                                Escovado8 = reader.GetInt32(reader.GetOrdinal("Escovado8")),
                                Comercial8 = reader.GetInt32(reader.GetOrdinal("Comercial8")),
                                Extra7 = reader.GetInt32(reader.GetOrdinal("Extra7")),
                                Cat7 = reader.GetInt32(reader.GetOrdinal("Cat7")),
                                Especial7 = reader.GetInt32(reader.GetOrdinal("Especial7")),
                                Escovado7 = reader.GetInt32(reader.GetOrdinal("Escovado7")),
                                Comercial7 = reader.GetInt32(reader.GetOrdinal("Comercial7")),
                                Extra6 = reader.GetInt32(reader.GetOrdinal("Extra6")),
                                Cat6 = reader.GetInt32(reader.GetOrdinal("Cat6")),
                                Especial6 = reader.GetInt32(reader.GetOrdinal("Especial6")),
                                Escovado6 = reader.GetInt32(reader.GetOrdinal("Escovado6")),
                                Comercial6 = reader.GetInt32(reader.GetOrdinal("Comercial6")),
                                Extra5 = reader.GetInt32(reader.GetOrdinal("Extra5")),
                                Cat5 = reader.GetInt32(reader.GetOrdinal("Cat5")),
                                Especial5 = reader.GetInt32(reader.GetOrdinal("Especial5")),
                                Escovado5 = reader.GetInt32(reader.GetOrdinal("Escovado5")),
                                Comercial5 = reader.GetInt32(reader.GetOrdinal("Comercial5")),
                                Extra4 = reader.GetInt32(reader.GetOrdinal("Extra4")),
                                Cat4 = reader.GetInt32(reader.GetOrdinal("Cat4")),
                                Especial4 = reader.GetInt32(reader.GetOrdinal("Especial4")),
                                Escovado4 = reader.GetInt32(reader.GetOrdinal("Escovado4")),
                                Comercial4 = reader.GetInt32(reader.GetOrdinal("Comercial4")),
                                Escovado3 = reader.GetInt32(reader.GetOrdinal("Escovado3")),
                                Borrado20kg = reader.GetInt32(reader.GetOrdinal("Borrado20kg")),
                                Escovado2_3 = reader.GetInt32(reader.GetOrdinal("Escovado2_3")),
                                Industrial20kg = reader.GetInt32(reader.GetOrdinal("Industrial20kg")),
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg")),
                                FazendaId = reader.GetInt32(reader.GetOrdinal("FazendaId")),
                                PLId = reader.GetInt32(reader.GetOrdinal("PLId"))
                            };
                            estoques.Add(estoque);
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
            return estoques;
        }

        public bool DeleteEstoque(int id)
        {
            try
            {
                string query = "DELETE FROM Estoque WHERE ID = @Id;";

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
