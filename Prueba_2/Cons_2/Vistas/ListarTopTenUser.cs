using Cons_2.Modelos;
using Cons_2.Servicios;
using System.Text;

namespace Cons_2.Vistas
{
    public class ListarTopTenUser
    {
        public static void Vista()
        {
            Console.WriteLine("\nA continuación se proporcionara un listado de los 10 primeros usuarios\n");

            List<Usuario> topTenUsers = ServicioUsuario.GetTopTenUsers();

            // Calcula la longitud máxima de las columnas
            int maxUserIdLength = topTenUsers.Max(u => u.UserId.ToString().Length) + 6;
            int maxLoginLength = topTenUsers.Max(u => u.Login.Length) + 4;
            int maxNombreLength = topTenUsers.Max(u => u.Nombre.Length) + 4;
            int maxPaternoLength = topTenUsers.Max(u => u.Paterno.Length) + 4;
            int maxMaternoLength = topTenUsers.Max(u => u.Materno.Length) + 4;

            // Crea la cabecera de la tabla
            StringBuilder table = new StringBuilder();
            table.AppendLine(
                "userId".PadRight(maxUserIdLength) + "Login".PadRight(maxLoginLength) + "Nombre".PadRight(maxNombreLength) +
                "Paterno".PadRight(maxPaternoLength) + "Materno".PadRight(maxMaternoLength));

            // Crea las filas de la tabla
            foreach (Usuario usuario in topTenUsers)
            {
                table.AppendLine(
                    usuario.UserId.ToString().PadLeft(3) + "     " + usuario.Login.PadRight(maxLoginLength) +
                    usuario.Nombre.PadRight(maxNombreLength) + usuario.Paterno.PadRight(maxPaternoLength) +
                    usuario.Materno.PadRight(maxMaternoLength));
            }

            // Imprime la tabla en la terminal
            Console.WriteLine(table.ToString());
        }
    }
}