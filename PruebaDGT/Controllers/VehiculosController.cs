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

namespace PruebaDGT.Controllers
{
    public class VehiculosController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // POST: api/Vehiculos
        [ResponseType(typeof(Vehiculos))]
        public IHttpActionResult PostVehiculos(Vehiculos vehiculos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehiculos.Add(vehiculos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VehiculosExists(vehiculos.matricula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vehiculos.matricula }, vehiculos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculosExists(string id)
        {
            return db.Vehiculos.Count(e => e.matricula == id) > 0;
        }
    }
}