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
    public class InventarioController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();
        public IHttpActionResult Inventario(Models.Request.InventarioRequest modelo)
        {
           // System.Diagnostics.Debug.WriteLine(modelo);
            
            decimal Promedio = Convert.ToDecimal((db.Promedio(modelo.Codigo_Sucursal).FirstOrDefault()));
            int Total = Convert.ToInt32((db.TotalJuguetes(modelo.Codigo_Sucursal).FirstOrDefault()));
            System.Diagnostics.Debug.WriteLine(Promedio);
            System.Diagnostics.Debug.WriteLine(Total);
            return CreatedAtRoute("DefaultApi", new { Sucursal = modelo.Codigo_Sucursal }, new { Total = Total, Promedio = Promedio, Productos = db.CatalogoSucursal(modelo.Codigo_Sucursal) });
            //return Ok("EXITO");
        }
    }
}
