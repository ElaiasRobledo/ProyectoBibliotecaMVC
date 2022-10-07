namespace TpBiblioteca.Models
{
    public class Generos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Libros>? libros { get; set; }
    }
}
