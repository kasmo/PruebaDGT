using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Services
{
    public class ConductoresService
    {
        static private DGTEntities db = new DGTEntities();

        static public bool RestarPuntos(string dni, int puntos)
        {
            try
            {
                Conductores oConductor = db.Conductores
                .Where(x => x.dni == dni)
                .First();

                oConductor.puntos -= puntos;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public Conductores GetConductor(string dni)
        {
            try
            {
                Conductores oConductor = db.Conductores
                    .Where(x => x.dni == dni)
                    .First();

                return oConductor;
            }
            catch
            {
                return null;
            }
        }
    }
}