using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Services
{
    public class InfraccionesTotalService
    {
        static private DGTEntities db = new DGTEntities();

        static public dynamic ObtenerInfraccionesHabituales(int numInfracciones)
        {
            try
            {
                List<InfraccionVehiculo> liInfVeh = new List<InfraccionVehiculo>();
                liInfVeh = db.InfraccionVehiculo.ToList();

                var liInfracciones = liInfVeh
                    .GroupBy(n => n.Infracciones.descripcion)
                    .Select(n => new
                    {
                        descripcion = n.Key,
                        total = n.Count()
                    }
                    )
                    .OrderByDescending(n => n.total);

                List<InfraccionTotal> liInfTot = new List<InfraccionTotal>();

                int i = 0;

                foreach (var reg in liInfracciones)
                {
                    i++;
                    InfraccionTotal oinfTot = new InfraccionTotal(reg.descripcion, reg.total);
                    liInfTot.Add(oinfTot);
                    if (i == numInfracciones)
                        break;
                }
                return liInfTot;
            }
            catch
            {
                return null;
            }
        }
    }
}