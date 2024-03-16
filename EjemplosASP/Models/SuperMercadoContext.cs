using Microsoft.EntityFrameworkCore;

namespace EjemplosASP.Models
{
    public class SuperMercadoContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public SuperMercadoContext()
        {
            
        }
        public SuperMercadoContext(DbContextOptions<SuperMercadoContext> opciones) : base(opciones)
        {
            
        }
    }
}
