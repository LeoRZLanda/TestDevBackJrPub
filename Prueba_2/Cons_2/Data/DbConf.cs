using MySql.Data.MySqlClient;

namespace Cons_2.Data{
    public static class DbConf
    {
        private static string _connectionString = "Server=localhost;Database=TestDevBackJr;User=root;Password=Password";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}