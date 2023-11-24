using Cons_2.Servicios;
using Cons_2.Modelos;

namespace Cons_2.Vistas{
    public class AgregarUsuario{
        
        public static void Vista(){

            int nuevoUsuarioId;
            string nuevoUsuarioNombre;
            string nuevoUsuarioPaterno;
            string nuevoUsuarioMaterno;
            decimal nuevoUsuarioSueldo;

            Console.WriteLine("\nMenu agregar usuario \n");

            Console.Write("\nProporcioname los siguientes datos del usuario a agregar");

            Console.Write("\nNombre: ");
            nuevoUsuarioNombre = Console.ReadLine();

            Console.Write("\nAppelido Paterno: ");
            nuevoUsuarioPaterno = Console.ReadLine();

            Console.Write("\nApellido Materno: ");
            nuevoUsuarioMaterno = Console.ReadLine();

            Console.Write("\nSalario: ");
            nuevoUsuarioSueldo = decimal.Parse(Console.ReadLine());

            Console.Write("\nUserId: ");
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
                    Console.WriteLine("\nEl nuevo usuario se agrego exitosamente\n");
                }
                else{
                    Console.WriteLine("\nEl nuevo usuario  no se agrego\n");
                }

            }
            else{
                Console.WriteLine("\nEl usuario con Nombre completo o su Id que agregaste ya estan en uso\n");
            }

        }

    }
}