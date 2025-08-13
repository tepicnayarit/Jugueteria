using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace JugueteAPI.Data
{
    namespace JugueteAPI.Data
    {
        public class DataContext : DbContext 
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            public DbSet<Juguete> Juguetes => Set<Juguete>();

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configuración de precisión para evitar truncamientos en SQL Server
                modelBuilder.Entity<Juguete>()
                    .Property(j => j.Precio)
                    .HasPrecision(10, 2);

                base.OnModelCreating(modelBuilder);
            }
        }



    }


}
