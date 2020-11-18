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
    public class InfraccionVehiculoController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // POST: api/InfraccionVehiculoes
        [ResponseType(typeof(InfraccionVehiculo))]
        public IHttpActionResult PostInfraccionVehiculo(InfraccionVehiculo infraccionVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (DescontarPuntos(infraccionVehiculo))
            {
                db.InfraccionVehiculo.Add(infraccionVehiculo);
                db.SaveChanges();
            }
            else
            {
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = infraccionVehiculo.id }, infraccionVehiculo);
        }




        // ---------------- Métodos auxiliares ------------------
        #region Métodos auxiliares
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DescontarPuntos(InfraccionVehiculo infraccionVehiculo)
        {
            try
            {
                // Si no ha informado conductor, se busca si solo hay uno habitual
                if (string.IsNullOrEmpty(infraccionVehiculo.dniConductor))
                {
                    infraccionVehiculo.dniConductor = ConductorVehiculoService.ObtenerConductorHabitual(infraccionVehiculo.matricula);
                }

                //Si se ha informado conductor o se ha detectado el habitual, se le restan los puntos
                if (!string.IsNullOrEmpty(infraccionVehiculo.dniConductor))
                {
                    //Se obtienen los puntos a restar de la infracción
                    int puntos = InfraccionesService.ObtenerPuntos(infraccionVehiculo.idInfraccion);

                    //Se devuelve true si se restan los puntos con éxito
                    return ConductoresService.RestarPuntos(infraccionVehiculo.dniConductor, puntos);
                }

                // No se ha podido asignar el conductor
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