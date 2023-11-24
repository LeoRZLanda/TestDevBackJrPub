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
    
    
        public static bool AgregarNuevoUsuario(NuevoUsuario nuevoUsuario)
        {
            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                int rowsAffected = 0;

                int Id = ObtenerSigId();

                DateTime Today = DateTime.Today;

                MySqlCommand command = new MySqlCommand(@"INSERT INTO usuarios (Login, Nombre, Paterno, Materno) 
                                                        VALUES (@Login ,@Nombre, @Paterno, @Materno); 
                                                        INSERT INTO empleados (userId, Sueldo, FechaIngreso) 
                                                        VALUES (LAST_INSERT_ID(), @Sueldo, @FechaIngreso)", connection);

                command.Parameters.AddWithValue("@Login", "user" + Id);
                command.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                command.Parameters.AddWithValue("@Paterno", nuevoUsuario.Paterno);
                command.Parameters.AddWithValue("@Materno", nuevoUsuario.Materno);
                command.Parameters.AddWithValue("@Sueldo", nuevoUsuario.Sueldo);
                command.Parameters.AddWithValue("@FechaIngreso", Today);

                rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                return rowsAffected > 0;
            }
        }

        private static int ObtenerSigId(){

            int UserId = 1;

            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                string query = "SELECT MAX(userId) + 1 AS MAXUserId FROM usuarios";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            UserId = reader.GetInt32("MAXUserId");
                            return UserId;
                        }
                    }
                }
            }

            return UserId;
        }
    

        public static bool ExisteUsuario(NuevoUsuario nuevoUsuario){

            bool usuarioExiste = false;


            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(@"SELECT COUNT(*) FROM usuarios 
                                                        WHERE nombre = @nombre 
                                                        AND paterno = @paterno 
                                                        AND materno = @materno 
                                                        AND userId != @userId", connection);

                command.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                command.Parameters.AddWithValue("@paterno", nuevoUsuario.Paterno);
                command.Parameters.AddWithValue("@materno", nuevoUsuario.Materno);
                command.Parameters.AddWithValue("@userId", nuevoUsuario.UserId);

                int result = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();

                if (result > 0)
                {
                    usuarioExiste = true;
                    return usuarioExiste;
                }
            }

            return usuarioExiste;
        }

    }

}