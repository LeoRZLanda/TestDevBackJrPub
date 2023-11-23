using Test_2.Interfaces;
using Test_2.Data;
using Test_2.Models;

namespace Test_2.Servicios{
    public class RepositorioUsuarios : IRepositorioUsuarios{
        
        private readonly string connectionString;

        private readonly AppDbContext appDbContext;

        public RepositorioUsuarios(IConfiguration configuration, AppDbContext appDbContext){
            connectionString = configuration.GetConnectionString("DefaultConnection");
            this.appDbContext = appDbContext;
        }

        public List<Usuario> Top10User(){
            //var using connection = new  MySqlConnection(connectionString);

            List<Usuario> topUsuarios = appDbContext.Usuarios.Take(10).ToList();

            return topUsuarios;
        }
    }
}