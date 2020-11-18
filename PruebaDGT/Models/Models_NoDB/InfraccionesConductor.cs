using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Models
{
    public class InfraccionesConductor
    {
        public InfraccionesConductor(string nombre, string dni, string infraccion, DateTime fecha)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.infraccion = infraccion;
            this.fecha = fecha;
        }

        public string nombre { get; set;}
        public string dni { get; set; }
        public string infraccion { get; set; }
        public DateTime fecha { get; set; }
    }
}