using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDGT.Services
{
    public class InfraccionesService
    {
        static private DGTEntities db = new DGTEntities();

        static public int ObtenerPuntos(int id)
        {
            try
            {
                Infracciones oInfracciones = db.Infracciones
                    .Where(x => x.id == id)
                    .First();

                return oInfracciones.puntos;
            }
            catch
            {
                return 0;
            }
        }
    }
}