using Microsoft.EntityFrameworkCore;
using TpBiblioteca.Models;

namespace TpBiblioteca.Models
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Biblioteca;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public List<Libros> Libros { get; set; }
        public List<Generos> generos { get; set; }
        public List<Autores> autores{ get; set; }
        public DbSet<TpBiblioteca.Models.Libros> Libros_1 { get; set; }
        public DbSet<TpBiblioteca.Models.Autores> Autores { get; set; }
        public DbSet<TpBiblioteca.Models.Generos> Generos { get; set; }

    }
}
