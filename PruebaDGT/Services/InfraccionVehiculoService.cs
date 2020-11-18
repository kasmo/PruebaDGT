using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Services
{
    public class InfraccionVehiculoService
    {
        static private DGTEntities db = new DGTEntities();

        //Se obtiene la lista de infracciones
        static public List<InfraccionVehiculo> getInfraccionVehiculoByDni(string dni)
        {
            try
            {
                List<InfraccionVehiculo> liInfVeh = db.InfraccionVehiculo
                    .Where(x => x.Conductores.dni == dni)
                    .OrderByDescending(x => x.fecha)
                    .ToList();

                return liInfVeh;
            }
            catch
            {
                return null;
            }
        }

    }
}