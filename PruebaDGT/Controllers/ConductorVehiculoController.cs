using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaDGT.Models;
using PruebaDGT.Services;

namespace PruebaDGT.Controllers
{
    public class ConductorVehiculoController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // POST: api/ConductorVehiculo
        [ResponseType(typeof(ConductorVehiculo))]
        public IHttpActionResult PostConductorVehiculo(ConductorVehiculo conductorVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ValidarComprobaciones(conductorVehiculo))
                return BadRequest(ModelState);

            db.ConductorVehiculo.Add(conductorVehiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conductorVehiculo.id }, conductorVehiculo);
        }


        // ---------------- Métodos auxiliares ----------------------
        #region Métodos auxiliares 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValidarComprobaciones(ConductorVehiculo conductorVehiculo)
        {
            try
            {
                bool esCorrecto;

                //Check num máximo de conductores habituales
                esCorrecto = ConductorVehiculoService.ComprobarMaxConductores(conductorVehiculo);
                if (!esCorrecto)
                    return false;

                //Por problema al crear modelo, check si ya existe el conductor en ese vehículo
                esCorrecto = ConductorVehiculoService.ComprobarDuplicidad(conductorVehiculo);
                if (!esCorrecto)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}