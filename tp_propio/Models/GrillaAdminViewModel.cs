using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_propio.Models
{
    public class GrillaAdminViewModel
    {
        public List<Paquete> Paquetes { get; set; }
        public int Paginas { get; set; }
        public int PaginaActual { get; set; }
    }
}