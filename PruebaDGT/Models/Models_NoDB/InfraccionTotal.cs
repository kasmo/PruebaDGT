using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Models
{
    public class InfraccionTotal
    {
        public InfraccionTotal(string descripcion, int total)
        {
            this.Descripcion = descripcion;
            this.Total = total;
        }

        public string Descripcion { get; set;}
        public int Total { get; set; }

    }
}