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
    public class InfraccionesController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // POST: api/Infracciones
        [ResponseType(typeof(Infracciones))]
        public IHttpActionResult PostInfracciones(Infracciones infracciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Infracciones.Add(infracciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = infracciones.id }, infracciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        
    }
}