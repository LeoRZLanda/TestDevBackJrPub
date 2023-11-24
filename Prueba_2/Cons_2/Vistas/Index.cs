using Cons_2.Servicios;

namespace Cons_2.Vistas{
    public class Index{

        public static void Vista(){

            bool valido = false;

            Console.WriteLine("Bienvenido a la solución para TestDevBackJr");

            
            do{
                Console.WriteLine("\nSelecciona la opción de tu interes.\n");   
                Console.WriteLine("1. Listar top 10 usuarios de la base antes creada."); 
                Console.WriteLine("2. Generar un archivo csv con las siguienets campos con su información(Login, Nombre completo, sueldo, fecha Ingreso).");
                Console.WriteLine("3. Poder actualizar el salario del algun usuario especifico.");
                Console.WriteLine("4. Poder Tener una opcion para agregar un nuevo usuario y se pueda asiganar el salario y la fecha de ingreso por default el dia de hoy.");
                Console.WriteLine("5. Salir.\n");

                Console.Write("Opcion: ");

                string opcion = Console.ReadLine();

                if(ServicioIsDigit.IsDigit(opcion) == true && opcion.Length > 0 && opcion != null){

                    switch(opcion){

                        case "1":
                            ListarTopTenUser.Vista();
                            break;

                        case "2":
                            GenerarArchivoCsv.Vista();
                            break;

                        case "3":
                            ActualizarSalario.Vista();
                            break;

                        case "4":
                            AgregarUsuario.Vista();
                            break;

                        case "5":
                            Console.WriteLine("\nVuleva pronto\n");
                            valido = true;
                            break;

                        default:
                            Console.WriteLine("\nOpcion invalida\n");
                            valido = false;
                            break;

                    }

                }



            } while(!valido);

        } 

    }
}