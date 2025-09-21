using Biblioteca.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteca.Servicios
{
    public class AppDbContext : DbContext
    {
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=biblioteca;user=root;password=1234",
                new MySqlServerVersion(new Version(8, 0, 33))
            );
        }
    }
}
