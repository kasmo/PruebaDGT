using PruebaDGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaDGT.Services;

namespace PruebaDGT.Controllers
{
    public class InfraccionTotalController : ApiController
    {
        private DGTEntities db = new DGTEntities();

        // GET: api/InfraccionTotal
        public List<InfraccionTotal> Get()
        {
            List<InfraccionTotal> liInfTot = InfraccionesTotalService.ObtenerInfraccionesHabituales(5);

            return liInfTot;
        }
    }
}
