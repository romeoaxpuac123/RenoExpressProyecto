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
    public class Producto_SucursalController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();

        // GET: api/Producto_Sucursal
        public IQueryable<Producto_Sucursal> GetProducto_Sucursal()
        {
            return db.Producto_Sucursal;
        }

        // GET: api/Producto_Sucursal/5
        [ResponseType(typeof(Producto_Sucursal))]
        public IHttpActionResult GetProducto_Sucursal(int id)
        {
            Producto_Sucursal producto_Sucursal = db.Producto_Sucursal.Find(id);
            if (producto_Sucursal == null)
            {
                return NotFound();
            }

            return Ok(producto_Sucursal);
        }

        // PUT: api/Producto_Sucursal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto_Sucursal(int id, Producto_Sucursal producto_Sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto_Sucursal.Codigo_Producto)
            {
                return BadRequest();
            }

            db.Entry(producto_Sucursal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Producto_SucursalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producto_Sucursal
        [ResponseType(typeof(Producto_Sucursal))]
        public IHttpActionResult PostProducto_Sucursal(Producto_Sucursal producto_Sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Producto_Sucursal.Add(producto_Sucursal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Producto_SucursalExists(producto_Sucursal.Codigo_Producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = producto_Sucursal.Codigo_Producto }, producto_Sucursal);
        }

        // DELETE: api/Producto_Sucursal/5
        [ResponseType(typeof(Producto_Sucursal))]
        public IHttpActionResult DeleteProducto_Sucursal(int id)
        {
            Producto_Sucursal producto_Sucursal = db.Producto_Sucursal.Find(id);
            if (producto_Sucursal == null)
            {
                return NotFound();
            }

            db.Producto_Sucursal.Remove(producto_Sucursal);
            db.SaveChanges();

            return Ok(producto_Sucursal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Producto_SucursalExists(int id)
        {
            return db.Producto_Sucursal.Count(e => e.Codigo_Producto == id) > 0;
        }
    }
}