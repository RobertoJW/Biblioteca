using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Biblioteca.Modelo
{
    public class EnlaceImagenes
    {
        [JsonPropertyName("thumbnail")]
        public string Portada { get; set; }
    }
}
