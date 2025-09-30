using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Biblioteca.Modelo
{
    public class VolumenInfo
    {
        [JsonPropertyName("title")]
        public string Titulo { get; set; }

        [JsonPropertyName("authors")]
        public List<string> Autores { get; set; } = new List<string>();

        [JsonPropertyName("publisher")]
        public string? Editorial { get; set; }

        [JsonPropertyName("publishedDate")]
        public string? FechaPublicacion { get; set; }

        [JsonPropertyName("description")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("language")]
        public string Idioma { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Genero { get; set; } = new List<string>();

        [JsonPropertyName("averageRating")]
        public decimal? Rating { get; set; }

        [JsonPropertyName("imageLinks")]
        public EnlaceImagenes? Imagenes { get; set; }
    }
}
