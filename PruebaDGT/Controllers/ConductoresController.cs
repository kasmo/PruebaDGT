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
    public class ConductoresController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // POST: api/Conductores
        [ResponseType(typeof(Conductores))]
        public IHttpActionResult PostConductores(Conductores conductores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conductores.Add(conductores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ConductoresExists(conductores.dni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = conductores.dni }, conductores);
        }

        // ------------- Métodos auxiliares -------------
        #region Métodos auxiliares
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConductoresExists(string id)
        {
            return db.Conductores.Count(e => e.dni == id) > 0;
        }
        #endregion
    }
}