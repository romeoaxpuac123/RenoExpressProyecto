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
    public class FacturaController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();
        [HttpPost]
        public IHttpActionResult RegistrarFactura(ICollection<Models.Request.FacturaRequest> modelo)
        {
            System.Diagnostics.Debug.WriteLine(modelo.Count);
            string Fecha = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime DateObject = Convert.ToDateTime(Fecha);
            int numerorder = 0;
            foreach (Models.Request.FacturaRequest Dato1 in modelo)
            {
                numerorder = Convert.ToInt32((db.CrearFactura(0, DateObject, Dato1.Codigo_Cliente)).FirstOrDefault());
                break;
            }
            
            foreach (Models.Request.FacturaRequest Dato1 in modelo)
            {
                db.RegistrarVenta(numerorder, Dato1.Codigo_Producto, Dato1.Codigo_Sucursal, Dato1.Cantidad, Dato1.Cantidad, DateObject);
                db.TotalFactura(numerorder, Dato1.Codigo_Producto, Dato1.Cantidad);
            }
            
            return Ok(" FACTURA EXITOSA");
        }
    }
}
