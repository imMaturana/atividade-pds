using System;
using MySqlConnector;

namespace ds_atividade.Database
{
    class Connection
    {
        private static string host = "localhost";
        private static uint port = 3306;
        private static string user = "root";
        private static string password = "root";
        private static string database = "bd_system";
        private static MySqlConnection? connection;
        private static MySqlCommand? command;

        public Connection()
        {
            try
            {
                connection = new MySqlConnection($"server={host};port={port};database={database};user={user};password={password}");
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query(string sql)
        {
            try
            {
                command = new MySqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = sql;
                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            connection?.Close();
        }
    }
}