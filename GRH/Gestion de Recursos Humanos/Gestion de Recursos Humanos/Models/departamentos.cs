//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_de_Recursos_Humanos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class departamentos
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Remote("IsProductNameExist", "departamentos", AdditionalFields = "Id",
               ErrorMessage = "Este codigo de departamento ya esta en uso")]
        public string codigodepartamento { get; set; }
        public string nombre { get; set; }
    }
}
