using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Modelo
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<string>? Genero { get; set; } = new List<string>();

        public List<string>? Idiomas { get; set; } = new List<string>();
        public int Ventas { get; set; }
        public decimal Rating { get; set; }

        // string porque guardaremos la imagen con una ruta
        public string Portada { get; set; }

    }
}


	
