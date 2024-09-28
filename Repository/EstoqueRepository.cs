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
                                         Escovado3, Borrado20kg, Escovado2_3, Industrial20kg, Dente20kg)
                    VALUES (@Data, @Evento, @DocNr, @Extra8, @Cat8, @Especial8, @Escovado8, @Comercial8,
                            @Extra7, @Cat7, @Especial7, @Escovado7, @Comercial7,
                            @Extra6, @Cat6, @Especial6, @Escovado6, @Comercial6,
                            @Extra5, @Cat5, @Especial5, @Escovado5, @Comercial5,
                            @Extra4, @Cat4, @Especial4, @Escovado4, @Comercial4,
                            @Escovado3, @Borrado20kg, @Escovado2_3, @Industrial20kg, @Dente20kg)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
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
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg"))
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
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg"))
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
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg"))
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
                        Dente20kg = @Dente20kg
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

        public List<Estoque> RetornaEstoquesFiltrado(DateTime? dataInicial, DateTime? dataFinal, string evento, string documento)
        {
            List<Estoque> estoques = new List<Estoque>();

            try
            {
                string query = @"
                    SELECT * FROM Estoque
                    WHERE (@DataInicial IS NULL OR CAST(Data AS DATE) >= CAST(@DataInicial AS DATE))
                    AND (@DataFinal IS NULL OR CAST(Data AS DATE) <= CAST(@DataFinal AS DATE))
                    AND (@Evento IS NULL OR Evento LIKE '%' + @Evento + '%')
                    AND (@Documento IS NULL OR DocNr LIKE '%' + @Documento + '%')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DataInicial", (object)dataInicial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DataFinal", (object)dataFinal ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Evento", string.IsNullOrEmpty(evento) ? (object)DBNull.Value : evento);
                    command.Parameters.AddWithValue("@Documento", string.IsNullOrEmpty(documento) ? (object)DBNull.Value : documento);

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
                                Dente20kg = reader.GetInt32(reader.GetOrdinal("Dente20kg"))
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
