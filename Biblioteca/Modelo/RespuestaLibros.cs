using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Biblioteca.Modelo
{
    public class RespuestaLibros
    {
        [JsonPropertyName("items")]
        public List<ItemLibro> Libros { get; set; }
    }
}
