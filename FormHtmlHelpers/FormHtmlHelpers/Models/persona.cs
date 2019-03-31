using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormHtmlHelpers.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int cedula { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string apellido { get; set; }
        [Range(15, 99, ErrorMessage = "Debe ser mayor a 15 años")]
        public int edad { get; set; }
        public string telefono { get; set; }
        [EmailAddress]
        public string correo { get; set; }
        public string genero { get; set; }
        public string estado_civil { get; set; }
        public int idhobby { get; set; }
        public string hobby { get; set; }
        public bool chekeado { get; set; }
     
    }
}