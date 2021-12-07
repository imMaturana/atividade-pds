using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySql.Data.MySqlClient;

namespace ds_atividade.Models
{
    class VendaItensDAO : IDAO<VendaItens>
    {
        private static Connection conn;

        public VendaItensDAO()
        {
            conn = new Connection();
        }

        public void Delete(VendaItens t)
        {
            try
            {
                conn.Query($"DELETE FROM venda_itens WHERE cod_itenv = '{t.Id}'").ExecuteNonQuery();
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

        public VendaItens GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM venda_itens WHERE cod_itenv = '{id}'").ExecuteReader();

                VendaItens vendaItens = new VendaItens();

                while (reader.Read()) vendaItens = new VendaItens
                {
                    Id = reader.GetUInt32("cod_itenv"),
                    Quantidade = reader.GetUInt32("quatidade_itenv"),
                    Valor = reader.GetDouble("valor_itenv"),
                    ValorTotal = reader.GetDouble("valor_total_itenv"),
                    ProdutoId = reader.GetUInt32("cod_prod_fk"),
                    VendaId = reader.GetUInt32("cod_vend_fk"),
                };

                return vendaItens;
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

        public void Insert(VendaItens t)
        {
            try
            {
                conn.Query($"INSERT INTO venda_itens VALUES (null, '{t.Quantidade}', '{t.Valor}', '{t.ValorTotal}', '{t.ProdutoId}', '{t.VendaId}')")
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

        public List<VendaItens> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM venda_itens").ExecuteReader();

                List<VendaItens> listaVendaItens = new List<VendaItens>();

                while (reader.Read()) listaVendaItens.Add(new VendaItens
                {
                    Id = reader.GetUInt32("cod_itenv"),
                    Quantidade = reader.GetUInt32("quatidade_itenv"),
                    Valor = reader.GetDouble("valor_itenv"),
                    ValorTotal = reader.GetDouble("valor_total_itenv"),
                    ProdutoId = reader.GetUInt32("cod_prod_fk"),
                    VendaId = reader.GetUInt32("cod_vend_fk"),
                });

                return listaVendaItens;
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

        public void Update(VendaItens t)
        {
            try
            {
                conn.Query($"UPDATE venda_itens SET quantidade_itenv = '{t.Quantidade}', valor_itenv = '{t.Valor}', valor_total_itenv = '{t.ValorTotal}', cod_prod_fk = '{t.ProdutoId}', cod_vend_fk = '{t.VendaId}' WHERE cod_itenv = '{t.Id}'")
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