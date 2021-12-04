using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class UsuarioDAO : IDAO<Usuario>
    {
        private static Connection conn = new Connection();
        public void Delete(Usuario t)
        {
            try
            {
                conn.Query($"DELETE FROM usuario WHERE cod_usu = '{t.Id}'").ExecuteNonQuery();
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

        public Usuario GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM usuario WHERE cod_usu = '{id}'").ExecuteReader();

                Usuario usuario = new Usuario();

                while (reader.Read()) usuario = new Usuario
                {
                    Id = reader.GetUInt32("cod_usu"),
                    Nome = reader.GetString("usuario_usu"),
                    Senha = reader.GetString("senha_usu"),
                    FuncionarioId = reader.GetUInt32("cod_func_fk"),
                };

                return usuario;
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

        public void Insert(Usuario t)
        {
            try
            {
                conn.Query($"INSERT INTO usuario VALUES (null, '{t.Nome}', '{t.Senha}', '{t.FuncionarioId}')").ExecuteNonQuery();
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

        public List<Usuario> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM usuario").ExecuteReader();

                List<Usuario> usuarios = new List<Usuario>();

                while (reader.Read()) usuarios.Add(new Usuario
                {
                    Id = reader.GetUInt32("cod_usu"),
                    Nome = reader.GetString("usuario_usu"),
                    Senha = reader.GetString("senha_usu"),
                    FuncionarioId = reader.GetUInt32("cod_func_fk"),
                });

                return usuarios;
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

        public void Update(Usuario t)
        {
            try
            {
                conn.Query($"UPDATE usuario SET usuario_usu = '{t.Nome}', senha_usu = '{t.Senha}', cod_func_fk = '{t.FuncionarioId}' WHERE cod_usu = '{t.Id}'")
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