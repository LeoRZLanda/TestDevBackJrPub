using Cons_2.Servicios;
using Cons_2.Modelos;

namespace Cons_2{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioUsuario Su = new ServicioUsuario();
            List<Usuario> topTenUsers = Su.GetTopTenUsers();

            foreach (Usuario usuario in topTenUsers)
            {
                Console.WriteLine($"UserId: {usuario.UserId}, Login: {usuario.Login}, Nombre: {usuario.Nombre}, Paterno: {usuario.Paterno}, Materno: {usuario.Materno}");
            }
        }
    }
}