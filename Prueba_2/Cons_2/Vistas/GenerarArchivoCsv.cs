using Cons_2.Modelos;
using Cons_2.Servicios;

namespace Cons_2.Vistas{
    public class GenerarArchivoCsv{

        public static void Vista(){

            Console.WriteLine("\nGenerando archivo csv\n");

            List<Empleado> empleados = ServicioEmpleado.ObtenerEmpleados();
            ServicioCsv.GenerarArchivoCsv(empleados);

            Console.WriteLine("Archivo csv generado\n");

        }

    }
}