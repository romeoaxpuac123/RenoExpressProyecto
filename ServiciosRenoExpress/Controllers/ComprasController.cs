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
            
            string Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime DateObject = Convert.ToDateTime(Fecha);
            int numerorder = Convert.ToInt32((db.CrearCompra(0, DateObject)).FirstOrDefault());
            foreach (Models.Request.CompraRequest Dato1 in modelo)
            {
                db.RegistrarDetalleCompra(numerorder, Dato1.Codigo_Producto, Dato1.Codigo_Sucursal, Dato1.Cantidad, Dato1.Cantidad, DateObject);
                db.TotalCompra(numerorder, Dato1.Codigo_Producto, Dato1.Cantidad);
            }
            return Ok("EXITO");
        }
    }
}
