namespace TpBiblioteca.Models
{
    public class Autores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Biografia { get; set; }
        public string Foto { get; set; }

        public List<Libros> libros { get; set; }
    }
}
