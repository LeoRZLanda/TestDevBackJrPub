using Cons_2.Modelos;
using CsvHelper;
using System.Globalization;

namespace Cons_2.Servicios{
    public class ServicioCsv{
        public static void GenerarArchivoCsv(List<Empleado> empleados)
        {
            using (var writer = new StreamWriter("empleados.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(empleados);
                }
            }
        }
    }
}