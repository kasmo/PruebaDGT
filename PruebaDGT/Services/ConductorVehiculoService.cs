using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Services
{
    public class ConductorVehiculoService
    {
        static private DGTEntities db = new DGTEntities();
        static public string ObtenerConductorHabitual(string matricula)
        {
            List<ConductorVehiculo> lConductores = db.ConductorVehiculo
                .Where(x => x.matricula == matricula)
                .ToList();

            if (lConductores.Count == 1)
            {
                ConductorVehiculo oConductorHabitual = lConductores.ElementAt(0);
                return oConductorHabitual.dni;
            }
            else
            {
                return null;
            }
        }

        static public bool ComprobarMaxConductores(ConductorVehiculo conductorVehiculo)
        {
            try
            {
                int conductores = db.ConductorVehiculo
                    .Where(x => x.dni == conductorVehiculo.dni)
                    .ToList().Count;

                return conductores < 5;
            }
            catch
            {
                return false;
            }
        }

        static public bool ComprobarDuplicidad(ConductorVehiculo conductorVehiculo)
        {
            try
            {
                int registro = db.ConductorVehiculo
                    .Where(x => x.dni == conductorVehiculo.dni)
                    .Where(x => x.matricula == conductorVehiculo.matricula)
                    .ToList().Count;

                return registro < 1;
            }
            catch
            {
                return false;
            }
        }
    }

    
}