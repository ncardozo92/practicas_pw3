using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_app.Models
{
    public class Universidad
    {
        public int Id { get; set; }//las llaves contienen los metodos getters y setters
        public string Nombre { get; set; }//solo es necesario obtener y asignar sin usar getNombre o SetNombre
        public string Direccion { get; set; }
        public int CantidadCarreras { get; set; }
    }
}