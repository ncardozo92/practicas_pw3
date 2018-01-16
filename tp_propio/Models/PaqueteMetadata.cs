using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tp_propio.Models
{
    public class PaqueteMetadata
    {   
        [Required( ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de finalización es obligatoria")]
        public string FechaFin { get; set; }
        public bool Destacado { get; set; }
        [Required(ErrorMessage = "Debe ingresar la cantidad de lugares")]
        public int LugaresDisponibles { get; set; }
        [Required(ErrorMessage = "Debe ingresar el precio por persona")]
        public int PrecioPorPersona { get; set; }
        public string Foto { get; set; }
    }
}