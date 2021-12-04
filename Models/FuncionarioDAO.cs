using System;
using System.Collections.Generic;
using ds_atividade.Intefaces;
using ds_atividade.Database;
using MySqlConnector;

namespace ds_atividade.Models
{
    class EmployeeDAO : IDAO<Funcionario>
    {
        private static Connection conn = new Connection();
        public void Delete(Funcionario t)
        {
            try
            {
                conn.Query($"DELETE FROM funcionario WHERE id = '{t.Id}'").ExecuteNonQuery();
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

        public Funcionario GetById(uint id)
        {
            try
            {
                MySqlDataReader reader = conn.Query($"SELECT * FROM funcionario WHERE cod_func = '{id}'").ExecuteReader();

                Funcionario funcionario = new Funcionario();

                while (reader.Read()) funcionario = new Funcionario
                {
                    Id = reader.GetUInt32("cod_func"),
                    Nome = reader.GetString("nome_func"),
                    Cpf = reader.GetString("cpf_func"),
                    Rg = reader.GetString("rg_func"),
                    DataNascimento = reader.GetDateTime("datanasc_func"),
                    TelefoneFixo = reader.GetString("telefone_func"),
                    Email = reader.GetString("email_func"),
                    TelefoneCelular = reader.GetString("celular_func"),
                    Funcao = reader.GetString("funcao_func"),
                    Salario = reader.GetDouble("salario_func"),
                    SexoId = reader.GetUInt32("cod_sex_fk"),
                    EnderecoId = reader.GetUInt32("cod_end_fk"),
                };

                return funcionario;
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

        public void Insert(Funcionario t)
        {
            try
            {
                conn.Query($"INSERT INTO funcionario VALUES (null, '{t.Nome}', '{t.Cpf}', '{t.Rg}', '{t.DataNascimento.ToString("yyyy-MM-dd")}', '{t.TelefoneFixo}', '{t.Email}', '{t.TelefoneCelular}', '{t.Funcao}', '{t.Salario}', '{t.SexoId}', '{t.EnderecoId}'")
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

        public List<Funcionario> List()
        {
            try
            {
                MySqlDataReader reader = conn.Query("SELECT * FROM funcionario").ExecuteReader();

                List<Funcionario> funcionarios = new List<Funcionario>();

                while (reader.Read()) funcionarios.Add(new Funcionario
                {
                    Id = reader.GetUInt32("cod_func"),
                    Nome = reader.GetString("nome_func"),
                    Cpf = reader.GetString("cpf_func"),
                    Rg = reader.GetString("rg_func"),
                    DataNascimento = reader.GetDateTime("datanasc_func"),
                    TelefoneFixo = reader.GetString("telefone_func"),
                    Email = reader.GetString("email_func"),
                    TelefoneCelular = reader.GetString("celular_func"),
                    Funcao = reader.GetString("funcao_func"),
                    Salario = reader.GetDouble("salario_func"),
                    SexoId = reader.GetUInt32("cod_sex_func"),
                    EnderecoId = reader.GetUInt32("cod_end_fk"),
                });

                return funcionarios;
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

        public void Update(Funcionario t)
        {
            try
            {
                conn.Query($"UPDATE funcionario SET nome_func = '{t.Nome}', cpf_func = '{t.Cpf}', rg_func = '{t.Rg}', datanasc_func = '{t.DataNascimento.ToString("yyyy-MM-dd")}', telefone_func = '{t.TelefoneFixo}', email_func = '{t.Email}', celular_func = '{t.TelefoneCelular}', funcao_func = '{t.Funcao}', salario_func = '{t.Salario}', cod_sex_fk = '{t.SexoId}', cod_end_fk = '{t.EnderecoId}' WHERE cod_func = '{t.Id}'")
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