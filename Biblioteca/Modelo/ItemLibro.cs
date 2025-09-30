using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Biblioteca.Modelo
{
    public class ItemLibro
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumenInfo Informacion { get; set; }
    }
}
