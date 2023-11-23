using Cons_2.Data;
using Cons_2.Modelos;
using MySql.Data.MySqlClient;

namespace Cons_2.Servicios{
    public class ServicioUsuario
    {
        public List<Usuario> GetTopTenUsers()
        {
            List<Usuario> topTenUsers = new List<Usuario>();

            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                string query = "SELECT * FROM usuarios ORDER BY userId LIMIT 10";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario Usuario = new Usuario
                            {
                                UserId = reader.GetInt32("userId"),
                                Login = reader.GetString("Login"),
                                Nombre = reader.GetString("Nombre"),
                                Paterno = reader.GetString("Paterno"),
                                Materno = reader.GetString("Materno")
                            };

                            topTenUsers.Add(Usuario);
                        }
                    }
                }
            }

            return topTenUsers;
        }
    }

}