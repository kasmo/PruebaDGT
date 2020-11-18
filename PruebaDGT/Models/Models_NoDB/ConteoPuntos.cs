using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Models.ModelosPropios
{
    public class ConteoPuntos
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public List<ListaInfracciones> ListaInfracciones{ get; set; }
    }

    public class ListaInfracciones
    {
        public string Infraccion { get; set; }
        public DateTime Fecha { get; set; }
        public int? PuntosRestantes { get; set; }
        public int PuntosRestados { get; set; }
    }
}