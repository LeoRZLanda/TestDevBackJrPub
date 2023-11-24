using Cons_2.Vistas;

namespace Cons_2.Vistas{
    public class Index{

        bool valido = false;

        Console.WriteLine("Bienvenido a la solución para TestDevBackJr")

        
        do{
            Console.WriteLine("\nSelecciona la opción de tu interes");   
            Console.WriteLine("""
                1. Listar top 10 usuarios de la base antes creada 
                2. Generar un archivo csv con las siguienets campos con su información(Login, Nombre completo, sueldo, fecha Ingreso)
                3. Poder actualizar el salario del algun usuario especifico
                4. Poder Tener una opcion para agregar un nuevo usuario y se pueda asiganar el salario y la fecha de ingreso por default el dia de hoy
                5. Salir.
            """);

            string opcion = Console.ReadLine();

            if(isDigit(opcion) == true && opcion.Length > 0 && opcion != null){


                case "1":
                    ListarTopTenUser();

                case "2":
                    

                case "3":
                    agregarUsuario();

                case "4":
                    agregarUsuario();

                case "5":
                    Console.WriteLine("Vuleva pronto\n");
                    valido = true;
                break;

                default:
                    Console.WriteLine("Opcion invalida");
                    valido = false;
                break;
            }



        } while(!valido); 
        
        

    

    }
}