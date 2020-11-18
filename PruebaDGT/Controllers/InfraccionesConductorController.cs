using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaDGT.Models;
using PruebaDGT.Services;

namespace PruebaDGT.Controllers
{
    public class InfraccionesConductorController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // GET: api/InfraccionesConductor/5
        [ResponseType(typeof(InfraccionesConductor))]
        public List<InfraccionesConductor> GetInfraccionConductor(string id)
        {
            try
            {
                Conductores oConductor = ConductoresService.GetConductor(id);

                List<InfraccionesConductor> liInfCond = InformarListaInfraccionesConductor(oConductor);

                return liInfCond;
            }
            catch
            {
                return null;
            }
        }


        // ----------------- Métodos auxiliares-------------
        #region Métodos auxiliares
        private List<InfraccionesConductor> InformarListaInfraccionesConductor(Conductores oConductor)
        {
            try
            {
                List<InfraccionesConductor> liInfCond = new List<InfraccionesConductor>();

                foreach (InfraccionVehiculo oInfVeh in oConductor.InfraccionVehiculo)
                {
                    InfraccionesConductor oInfCond = new InfraccionesConductor(oConductor.nombre, oConductor.dni, oInfVeh.Infracciones.descripcion, oInfVeh.fecha);
                    liInfCond.Add(oInfCond);

                    return liInfCond;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
