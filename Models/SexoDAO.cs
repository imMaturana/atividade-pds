using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySql.Data.MySqlClient;

namespace ds_atividade.Models
{
    class SexoDAO : IDAO<Sexo>
    {
        private static Connection conn;

        public SexoDAO()
        {
            conn = new Connection();
        }
        public void Delete(Sexo t)
        {
            try
            {
                conn.Query($"DELETE FROM sexo WHERE cod_sex = '{t.Id}'")
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

        public Sexo GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM sexo WHERE cod_sex = '{id}'").ExecuteReader();

                Sexo sexo = new Sexo();

                while (reader.Read()) sexo = new Sexo
                {
                    Id = reader.GetUInt32("cod_sex"),
                    Nome = reader.GetString("nome_sex"),
                };

                return sexo;
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

        public void Insert(Sexo t)
        {
            try
            {
                conn.Query($"INSERT INTO sexo VALUES (null, '{t.Nome}')")
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

        public List<Sexo> List()
        {
            MySqlDataReader reader = conn.Query("SELECT * FROM sexo").ExecuteReader();

            List<Sexo> sexos = new List<Sexo>();

            while (reader.Read()) sexos.Add(new Sexo
            {
                Id = reader.GetUInt32("cod_sex"),
                Nome = reader.GetString("nome_sex"),
            });

            return sexos;
        }

        public void Update(Sexo t)
        {
            try
            {
                conn.Query($"UPDATE sexo SET nome = '{t.Nome}' WHERE cod_sex = '{t.Id}'")
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