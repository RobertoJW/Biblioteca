using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
    public class Favoritos
    {
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
