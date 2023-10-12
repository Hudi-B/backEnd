using Microsoft.EntityFrameworkCore;

namespace carsAPI.Models
{
    public class CarContext : DbContext
    {
        public CarContext() { }
        public CarContext(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.50.54; database=db_cars; user=root; password=admin", ServerVersion.AutoDetect("server=192.168.50.54; database=db_cars; user=root; password=admin"));
            }
        }

        public DbSet<Car> Cars { get; set; } = null!;
    }
}
