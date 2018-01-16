using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tp_propio.Models
{
    public class ReservaMetadata
    {
        [Required(ErrorMessage = "el campo no puede ser nulo.")]
        [Range(1,100,ErrorMessage ="Debe ingresar un valor mayor a 0.")]
        public int CantPersonas { get; set; }
    }
}