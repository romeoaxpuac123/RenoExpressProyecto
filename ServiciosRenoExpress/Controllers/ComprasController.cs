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
using ServiciosRenoExpress.Models;

namespace ServiciosRenoExpress.Controllers
{
    public class ComprasController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();
        [HttpPost]
        public IHttpActionResult RegistrarCompra(ICollection<Models.Request.CompraRequest>  modelo )
        {
            return Ok("EXITO");
        }
    }
}
