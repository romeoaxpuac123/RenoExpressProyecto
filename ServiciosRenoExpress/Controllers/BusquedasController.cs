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
using System.Web.Http.Cors;

namespace ServiciosRenoExpress.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class BusquedasController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();
        public IHttpActionResult Busqueda(Models.Request.BusquedaRequest modelo)
        {
            switch (modelo.TipoBusqueda)
            {
                case 1:                   
                    return CreatedAtRoute("DefaultApi", new { Sucursal = modelo.Codigo_Sucursal }, new { Productos = db.ProductosPorCategoria(modelo.Codigo_Sucursal,modelo.ParametroBusqueda) });
                case 2:
                    return CreatedAtRoute("DefaultApi", new { Sucursal = modelo.Codigo_Sucursal }, new { Productos = db.ProductosPorNombre(modelo.Codigo_Sucursal,modelo.ParametroBusqueda)});
                case 3:
                    return CreatedAtRoute("DefaultApi", new { Sucursal = modelo.Codigo_Sucursal }, new { Productos = db.ProductosPorCodigo(modelo.Codigo_Sucursal,Convert.ToInt32(modelo.ParametroBusqueda))});                
                default:
                    return Ok("ERROR");
            }
        }
    }
}
