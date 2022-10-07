namespace TpBiblioteca.Models
{
    public class Libros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string ImagenPortada { get; set; }
        public Generos? Generos { get; set; }
        public Autores? Autor { get; set; }
    }
}
