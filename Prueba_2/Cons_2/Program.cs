using Cons_2.Servicios;
using Cons_2.Modelos;

namespace Cons_2{
    class Program
    {
        static void Main(string[] args)
        {

            // 1. Listar top 10 usuarios de la base antes creada 

            /*ServicioUsuario Su = new ServicioUsuario();
            List<Usuario> topTenUsers = Su.GetTopTenUsers();

            foreach (Usuario usuario in topTenUsers)
            {
                Console.WriteLine($"UserId: {usuario.UserId}, Login: {usuario.Login}, Nombre: {usuario.Nombre}, Paterno: {usuario.Paterno}, Materno: {usuario.Materno}");
            } */

            // 2. Generar un archivo csv con las siguienets campos con su información(Login, Nombre completo, sueldo, fecha Ingreso)

            /*List<Empleado> empleados = ServicioEmpleado.ObtenerEmpleados();
            ServicioCsv.GenerarArchivoCsv(empleados);*/

            // 3. Poder actualizar el salario del algun usuario especifico
            /*
            Console.WriteLine("Introduzca el ID del usuario cuyo salario desea actualizar:");
            int userId = int.Parse(Console.ReadLine());

            bool existeUserId = ServicioEmpleado.ValidarUsuario(userId);

            if(existeUserId){
                Console.WriteLine("Introduzca el nuevo salario para el usuario " + userId + ":");
                decimal nuevoSalario = decimal.Parse(Console.ReadLine());

                bool resultado = ServicioEmpleado.ActualizarSalario(userId, nuevoSalario);

                if (resultado)
                {
                    Console.WriteLine("Salario actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo actualizar el salario.");
                }
            }
            else{
                Console.WriteLine("Disculpa pero el usuario " + userId + " no existe");
            }
            */

            // 4. Poder Tener una opcion para agregar un nuevo usuario y se pueda asiganar el salario y la fecha de ingreso por default el dia de hoy
            int nuevoUsuarioId;
            string nuevoUsuarioNombre;
            string nuevoUsuarioPaterno;
            string nuevoUsuarioMaterno;
            decimal nuevoUsuarioSueldo;

            Console.WriteLine("Menu agregar usuario\n");

            Console.Write("Proporcioname el nombre del nuevo usuario:");
            nuevoUsuarioNombre = Console.ReadLine();

            Console.Write("Proporcioname el apellido paterno del nuevo usuario:");
            nuevoUsuarioPaterno = Console.ReadLine();

            Console.Write("Proporcioname el apellido materno del nuevo usuario:");
            nuevoUsuarioMaterno = Console.ReadLine();

            Console.Write("Proporcioname el salario del nuevo usuario:");
            nuevoUsuarioSueldo = decimal.Parse(Console.ReadLine());

            Console.Write("Proporcioname el Id del nuevo usuario:");
            nuevoUsuarioId = int.Parse(Console.ReadLine());

            NuevoUsuario nuevoUsuario = new NuevoUsuario() {
                UserId = nuevoUsuarioId,
                Nombre = nuevoUsuarioNombre,
                Paterno = nuevoUsuarioPaterno,
                Materno = nuevoUsuarioMaterno,
                Sueldo = nuevoUsuarioSueldo
            };

            if(!ServicioUsuario.ExisteUsuario(nuevoUsuario)){

                if(ServicioUsuario.AgregarNuevoUsuario(nuevoUsuario)){
                    Console.WriteLine("El nuevo usuario se agrego exitosamente");
                }
                else{
                    Console.WriteLine("El nuevo usuario  no se agrego");
                }

            }
            else{
                Console.WriteLine("El usuario con Nombre completo o su Id que agregaste ya estan en uso");
            }




            
        }
    }
}