using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_app.Models
{
    public class Empleado
    {
        [Required( ErrorMessage = "dato obligatorio")]
        public string Nombre { get; set;}

        public int Edad { get; set; }
        [EmailAddress(ErrorMessage = "escribalo bien")]
        public string Email { get; set; }
    }
}