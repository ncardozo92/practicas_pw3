using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaDB.Models
{
    public class EquiposMetadata
    {
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Cantidad de jugadores necesaria")]
        public int CantidadIntegrantes { get; set; }
        [Required(ErrorMessage = "Fecha obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "fecha debe tener formato aaaa-mm-dd")]
        public System.DateTime FechaCreacion { get; set; }
    }
}