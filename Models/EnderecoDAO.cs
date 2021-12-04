using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class AddressDAO : IDAO<Endereco>
    {
        private static Connection conn = new Connection();
        public void Delete(Endereco t)
        {
            try
            {
                conn.Query($"DELETE FROM endereco WHERE cod_end = '{t.Id}'")
                    .ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Endereco GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM endereco WHERE cod_end = '{id}'").ExecuteReader();

                Endereco endereco = new Endereco();

                while (reader.Read())
                {
                    endereco =  new Endereco {
                        Id = reader.GetUInt32("cod_end"),
                        Rua = reader.GetString("rua_end"),
                        Numero = reader.GetString("numero_end"),
                        Bairro = reader.GetString("bairro_end"),
                        Cidade = reader.GetString("cidade_end"),
                        Estado = reader.GetString("estado_end")
                    };
                }

                return endereco;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Insert(Endereco t)
        {
            try
            {
                conn.Query($"INSERT INTO endereco VALUES (null, '{t.Rua}', '{t.Numero}', '{t.Bairro}', '{t.Cidade}', '{t.Estado}')")
                    .ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Endereco> List()
        {
            try
            {
                MySqlCommand query = conn.Query("SELECT * FROM endereco");
                MySqlDataReader reader = query.ExecuteReader();

                List<Endereco> enderecos = new List<Endereco>();

                while(reader.Read())
                {
                    enderecos.Add(new Endereco
                    {
                        Id = reader.GetUInt32("cod_end"),
                        Rua = reader.GetString("rua_end"),
                        Numero = reader.GetString("numero_end"),
                        Bairro = reader.GetString("bairro_end"),
                        Cidade = reader.GetString("cidade_end"),
                        Estado = reader.GetString("estado_end")
                    });
                }

                return enderecos;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Endereco t)
        {
            try
            {
                conn.Query($"UPDATE endereco SET rua_end = '{t.Rua}', numero_end = '{t.Numero}', bairro_end = '{t.Bairro}', cidade_end = '{t.Cidade}', estado_end = '{t.Estado}' WHERE id_end = '{t.Id}'")
                    .ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}