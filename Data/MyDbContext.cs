using Microsoft.EntityFrameworkCore;
using VBNET_Core3_project.Models;

namespace VBNET_Core3_project.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cliente> clientes { get; set; } 
        public DbSet<Prestamo> prestamos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<TipoPrestamo> tipoprestamos { get; set; }
    }
}
