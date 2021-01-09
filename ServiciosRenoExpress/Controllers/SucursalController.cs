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
    public class SucursalController : ApiController
    {
        private RenoExpressDBEntities db = new RenoExpressDBEntities();

        // GET: api/Sucursal
        public IQueryable<Sucursal> GetSucursal()
        {
            return db.Sucursal;
        }

        // GET: api/Sucursal/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult GetSucursal(int id)
        {
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        // PUT: api/Sucursal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursal(int id, Sucursal sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal.Codigo_Sucursal)
            {
                return BadRequest();
            }

            db.Entry(sucursal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // POST: api/Sucursal
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult PostSucursal(Sucursal sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal.Add(sucursal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursal.Codigo_Sucursal }, sucursal);
        }

        // DELETE: api/Sucursal/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult DeleteSucursal(int id)
        {
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            db.Sucursal.Remove(sucursal);
            db.SaveChanges();

            return Ok(sucursal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalExists(int id)
        {
            return db.Sucursal.Count(e => e.Codigo_Sucursal == id) > 0;
        }
    }
}