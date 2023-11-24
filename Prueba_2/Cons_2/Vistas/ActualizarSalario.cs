using Cons_2.Modelos;
using Cons_2.Servicios;

namespace Cons_2.Vistas{
    public class ActualizarSalario{

        public static void Vista(){

            Console.WriteLine("\nMenu para actualizar salario de un usuario \n");

            Console.WriteLine("Introduzca el ID del usuario cuyo salario desea actualizar");

            Console.Write("\nuserId: ");

            int userId = int.Parse(Console.ReadLine());

            bool existeUserId = ServicioEmpleado.ValidarUsuario(userId);

            if(existeUserId){
                Console.WriteLine("\nIntroduzca el nuevo salario para el usuario " + userId);

                Console.Write("\nNuevo Salario:");

                decimal nuevoSalario = decimal.Parse(Console.ReadLine());

                bool resultado = ServicioEmpleado.ActualizarSalario(userId, nuevoSalario);

                if (resultado)
                {
                    Console.WriteLine("\nSalario actualizado correctamente.\n");
                }
                else
                {
                    Console.WriteLine("\nNo se pudo actualizar el salario.\n");
                }
            }
            else{
                Console.WriteLine("\nDisculpa pero el usuario " + userId + " no existe\n");
            }

        }

    }
}