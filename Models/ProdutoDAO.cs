using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class ProdutoDAO : IDAO<Produto>
    {
        private static Connection conn = new Connection();
        public void Delete(Produto t)
        {
            try
            {
                conn.Query($"DELETE FROM produto WHERE cod_prod = '{t.Id}'").ExecuteNonQuery();
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

        public Produto GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELETE * FROM produto WHERE cod_prod = '{id}'").ExecuteReader();

                Produto produto = new Produto();

                while (reader.Read()) produto = new Produto
                {
                    Id = reader.GetUInt32("cod_prod"),
                    Nome = reader.GetString("nome_prod"),
                    Descricao = reader.GetString("descricao_prod"),
                    Marca = reader.GetString("marca_prod"),
                    Valor = reader.GetDouble("valor_venda_prod"),
                };

                return produto;
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

        public void Insert(Produto t)
        {
            try
            {
                conn.Query($"INSERT INTO produto VALUES (null, '{t.Nome}', '{t.Descricao}', '{t.Marca}', '{t.Valor}'").ExecuteNonQuery();
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

        public List<Produto> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM produto").ExecuteReader();

                List<Produto> produtos = new List<Produto>();

                while (reader.Read()) produtos.Add(new Produto
                {
                    Id = reader.GetUInt32("cod_prod"),
                    Nome = reader.GetString("nome_prod"),
                    Descricao = reader.GetString("descricao_prod"),
                    Marca = reader.GetString("marca_prod"),
                    Valor = reader.GetDouble("valor_venda_prod"),
                });

                return produtos;
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

        public void Update(Produto t)
        {
            try
            {
                conn.Query($"UPDATE produto SET nome_prod = '{t.Nome}', descricao_prod = '{t.Descricao}', marca_prod = '{t.Marca}', valor_venda_prod = '{t.Valor}' WHERE cod_prod = '{t.Id}'")
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