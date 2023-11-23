using Test_2.Interfaces;
using Test_2.Data;
using System.Linq;

namespace Test_2.Servicios{
    public class RepositorioUsuarios : IRepositorioUsuarios{
        
        private readonly string connectionString;

        private AppDbContext appDbContext;

        public RepositorioUsuarios(IConfiguration configuration){
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public  Top10User(){
            //var using connection = new  MySqlConnection(connectionString);

            var DbContext = new AppDbContext(connectionString);

            var topUsuarios = DbContext.Usuarios.Take(10).ToList();

            return topUsuarios;
        }
    }
}