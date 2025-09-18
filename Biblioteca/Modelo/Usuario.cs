using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string? FotoPerfil { get; set; }

        public virtual Favoritos? Favoritos { get; set; }

        public Usuario(string nombre, string correo, string clave, string fotoperfil)
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Clave = clave;
            this.FotoPerfil = fotoperfil;
        }
    }
}
