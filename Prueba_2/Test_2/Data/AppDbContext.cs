using Microsoft.EntityFrameworkCore;
using Test_2.Models;

namespace Test_2.Data{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString;

        public AppDbContext(string DBConf)
        {
            connectionString = DBConf;
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}