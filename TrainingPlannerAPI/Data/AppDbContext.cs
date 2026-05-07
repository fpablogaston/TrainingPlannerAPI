using Microsoft.EntityFrameworkCore;
using TrainingPlannerAPI.Models;

namespace TrainingPlannerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) 
        {
        
        }
        
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rutina>().ToTable("rutinas");
            modelBuilder.Entity<Ejercicio>().ToTable("ejercicios");
        }
    }
}
