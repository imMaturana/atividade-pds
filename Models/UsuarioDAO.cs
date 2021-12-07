using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySql.Data.MySqlClient;

namespace ds_atividade.Models
{
    class UsuarioDAO : IDAO<Usuario>
    {
        private static Connection conn;

        public UsuarioDAO()
        {
            conn = new Connection();
        }

        public bool IsAvailable(Usuario t)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM usuario WHERE nome_usu = '{t.Nome}'").ExecuteReader();

                if (reader.HasRows) return true;
                return false;
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

        public bool CanLogin(Usuario t)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM usuario WHERE nome_usu = '{t.Nome}' AND senha_usu = '{t.Senha}'").ExecuteReader();

                if (reader.HasRows) return true;
                return false;
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

        public void Delete(Usuario t)
        {
            try
            {
                conn.Query($"DELETE FROM usuario WHERE cod_usu = '{t.Id}'")
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

        public Usuario GetById(uint id)
        {
            try
            {
                Usuario usuario = new Usuario();

                MySqlDataReader reader = conn.Query($"SELECT * FROM usuario WHERE cod_usu = '{id}'").ExecuteReader();

                while (reader.Read()) usuario = new Usuario
                {
                    Id = reader.GetUInt32("cod_usu"),
                    Nome = reader.GetString("usuario_usu"),
                    Senha = reader.GetString("senha_usu"),
                    Funcionario = new FuncionarioDAO().GetById(reader.GetUInt32("cod_func_fk")),
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
                conn.Query($"INSERT INTO usuario VALUES (null, '{t.Nome}', '{t.Senha}', '{t.Funcionario.Id}')")
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

        public List<Usuario> List()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                MySqlDataReader reader = conn.Query("SELECT * FROM usuario").ExecuteReader();

                while (reader.Read()) 
                {
                    FuncionarioDAO funcionarioDAO = new FuncionarioDAO();

                    usuarios.Add(new Usuario
                    {
                        Id = reader.GetUInt32("cod_usu"),
                        Nome = reader.GetString("usuario_usu"),
                        Senha = reader.GetString("senha_usu"),
                        Funcionario = funcionarioDAO.GetById(reader.GetUInt32("cod_func_fk")),
                    });
                }

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
                conn.Query($"UPDATE usuario SET usuario_usu = '{t.Nome}', senha_usu = '{t.Senha}', cod_func_fk = '{t.Funcionario.Id}' WHERE cod_usu = '{t.Id}'")
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