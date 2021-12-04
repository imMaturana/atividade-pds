using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class ClienteDAO : IDAO<Cliente>
    {
        private static Connection conn = new Connection();
        public void Delete(Cliente t)
        {
            try
            {
                conn.Query($"DELETE FROM cliente WHERE cod_cli = '{t.Id}'")
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

        public Cliente GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM cliente WHERE cod_cli = '{id}'").ExecuteReader();

                Cliente cliente = new Cliente();

                while(reader.Read())
                {
                    cliente = new Cliente
                    {
                        Id = reader.GetUInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        Cpf = reader.GetString("cpf_cli"),
                        Rg = reader.GetString("rg_cli"),
                        DataNascimento = DateTime.Parse(reader.GetString("datanasc_cli")),
                        TelefoneFixo = reader.GetString("telefone_fixo_cli"),
                        TelefoneCelular = reader.GetString("telefone_celular_cli"),
                        Email = reader.GetString("email_cli"),
                        SexoId = reader.GetUInt32("cod_sex_fk"),
                        EnderecoId = reader.GetUInt32("cod_end_fk"),
                    };
                }

                return cliente;
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

        public void Insert(Cliente t)
        {
            try
            {
                conn.Query($"INSERT INTO cliente VALUES (null, '{t.Nome}', '{t.Cpf}', '{t.Rg}', '{t.DataNascimento.ToString("yyyy-MM-dd")}', '{t.TelefoneFixo}', '{t.TelefoneCelular}', '{t.Email}', '{t.SexoId}', '{t.EnderecoId}')")
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

        public List<Cliente> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM cliente").ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = reader.GetUInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        Cpf = reader.GetString("cpf_cli"),
                        Rg = reader.GetString("rg_cli"),
                        DataNascimento = reader.GetDateTime("datanasc_cli"),
                        TelefoneFixo = reader.GetString("telefone_fixo_cli"),
                        TelefoneCelular = reader.GetString("telefone_celular_cli"),
                        Email = reader.GetString("email_cli"),
                        SexoId = reader.GetUInt32("cod_sex_fk"),
                        EnderecoId = reader.GetUInt32("cod_end_fk"),
                    });
                }

                return clientes;
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

        public void Update(Cliente t)
        {
            try
            {
                conn.Query($"UPDATE cliente SET nome_cli = '{t.Nome}', cpf_cli = '{t.Cpf}', rg_cli = '{t.Rg}', datanasc_cli = '{t.DataNascimento.ToString("yyyy-MM-dd")}', telefone_fixo_cli = '{t.TelefoneFixo}', telefone_celular_cli = '{t.TelefoneCelular}', email_cli = '{t.Email}', cod_sex_fk = '{t.SexoId}', cod_end_fk = '{t.EnderecoId}'")
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