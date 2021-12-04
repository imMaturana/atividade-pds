using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class VendaDAO : IDAO<Venda>
    {
        private static Connection conn = new Connection();
        public void Delete(Venda t)
        {
            try
            {
                conn.Query($"DELETE FROM venda WHERE cod_vend = '{t.Id}'").ExecuteNonQuery();
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

        public Venda GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM venda WHERE cod_vend = '{id}'")
                    .ExecuteReader();

                Venda venda = new Venda();

                while (reader.Read()) venda = new Venda
                {
                    Id = reader.GetUInt32("cod_vend"),
                    FuncionarioId = reader.GetUInt32("cod_func_fk"),
                    ClienteId = reader.GetUInt32("cod_cli_fk"),
                    Data = reader.GetDateTime("data_vend"),
                    FormaPagamento = reader.GetString("forma_pagamento_vend"),
                    Valor = reader.GetDouble("valor_total_vend")
                };

                return venda;
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

        public void Insert(Venda t)
        {
            try
            {
                conn.Query($"INSERT INTO venda VALUES (null, '{t.FuncionarioId}', '{t.ClienteId}', '{t.Data}', '{t.FormaPagamento}', '{t.Valor}')")
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

        public List<Venda> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM venda").ExecuteReader();

                List<Venda> vendas = new List<Venda>();

                while (reader.Read()) vendas.Add(new Venda
                {
                    Id = reader.GetUInt32("cod_vend"),
                    FuncionarioId = reader.GetUInt32("cod_func_fk"),
                    ClienteId = reader.GetUInt32("cod_cli_fk"),
                    Data = reader.GetDateTime("data_vend"),
                    FormaPagamento = reader.GetString("forma_pagamento_func"),
                    Valor = reader.GetDouble("valor_total_vend"),
                });

                return vendas;
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

        public void Update(Venda t)
        {
            try
            {
                conn.Query($"UPDATE venda SET cod_func_fk = '{t.FuncionarioId}', cod_cli_fk = '{t.ClienteId}', data_vend = '{t.Data}', forma_pagamento_vend = '{t.FormaPagamento}', valor_total_vend = '{t.Valor}' WHERE cod_vend = '{t.Id}'")
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