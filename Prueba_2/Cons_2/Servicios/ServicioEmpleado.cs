using Cons_2.Data;
using Cons_2.Modelos;
using MySql.Data.MySqlClient;

namespace Cons_2.Servicios{
    public class ServicioEmpleado{
        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(@"SELECT u.userId, u.Login, CONCAT(u.Nombre, ' ', u.Paterno, ' ', u.Materno) as NombreCompleto, 
                                                        e.Sueldo, e.FechaIngreso FROM empleados e JOIN usuarios u ON e.userId = u.userId", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Empleado empleado = new Empleado
                        {
                            Login = reader.GetString("Login"),
                            NombreCompleto = reader.GetString("NombreCompleto"),
                            Sueldo = reader.GetDecimal("Sueldo"),
                            FechaIngreso = reader.GetDateTime("FechaIngreso")
                        };

                        empleados.Add(empleado);
                    }
                }
            }

            return empleados;
        }
    
        public static bool ActualizarSalario(int userId, decimal nuevoSalario)
        {
            using (MySqlConnection connection = DbConf.GetConnection())
            {
                connection.Open();

                int rowsAffected = 0;
                DateTime Today = DateTime.Today;

                Console.WriteLine("Estamos actualizando salario");

                if(ValidarUsuario(userId) && TieneSueldo(userId)){
                    Console.WriteLine("Existe y tiene sueldo");
                    MySqlCommand command = new MySqlCommand(@"UPDATE empleados 
                                                            SET Sueldo = @nuevoSalario 
                                                            WHERE userId = @userId", connection);

                    command.Parameters.AddWithValue("@nuevoSalario", nuevoSalario);
                    command.Parameters.AddWithValue("@userId", userId);

                    rowsAffected = command.ExecuteNonQuery();
                }
                if(ValidarUsuario(userId) && !TieneSueldo(userId)){
                    Console.WriteLine("Existe como usuario pero no como empleado y no tiene sueldo");
                    MySqlCommand command = new MySqlCommand(@"INSERT INTO empleados (userId,Sueldo, FechaIngreso) 
                                                            VALUES (@userId,@Sueldo, @FechaIngreso)", connection);

                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@Sueldo", nuevoSalario);
                    command.Parameters.AddWithValue("@FechaIngreso", Today);

                    rowsAffected = command.ExecuteNonQuery();
                }

                connection.Close();

                return rowsAffected > 0;
            }
        }

        public static bool ValidarUsuario(int UserId){


            using (MySqlConnection connection = DbConf.GetConnection()){

                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM usuarios WHERE userId = @userId", connection);

                command.Parameters.AddWithValue("@userId", UserId);

                // Ejecuta la consulta
                MySqlDataReader reader = command.ExecuteReader();

                // Verifica si se encontró algún usuario con el userId especificado
                bool usuarioEncontrado = reader.HasRows;

                // Cierra la conexión y devuelve el resultado
                reader.Close();
                connection.Close();
            

                return usuarioEncontrado;
            }
        }
    
    
        public static bool TieneSueldo(int UserId){

            using (MySqlConnection connection = DbConf.GetConnection()){

                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT Sueldo FROM empleados WHERE userId = @userId", connection);

                command.Parameters.AddWithValue("@userId", UserId);

                // Ejecuta la consulta
                MySqlDataReader reader = command.ExecuteReader();

                // Verifica si se encontró algún usuario con el userId especificado
                bool sueldoEncontrado = reader.HasRows;

                // Cierra la conexión y devuelve el resultado
                reader.Close();
                connection.Close();
            

                return sueldoEncontrado;
            }

        }
    
    }
}