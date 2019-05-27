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
using WebAPI.Models;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [System.Web.Http.Authorize]
    public class AreaAffectedController : ApiController
    {
        private MalariaApp2Entities db = new MalariaApp2Entities();

        // GET: api/AreaAffected
        public IQueryable<AreaAffected> GetAreaAffecteds()
        {
            return db.AreaAffecteds;
        }

        // GET: api/AreaAffected/5
        [ResponseType(typeof(AreaAffected))]
        public IHttpActionResult GetAreaAffected(int id)
        {
            AreaAffected areaAffected = db.AreaAffecteds.Find(id);
            if (areaAffected == null)
            {
                return NotFound();
            }

            return Ok(areaAffected);
        }

        // PUT: api/AreaAffected/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAreaAffected(int id, AreaAffected areaAffected)
        {
            if (id != areaAffected.AreaID)
            {
                return BadRequest();
            }

            db.Entry(areaAffected).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaAffectedExists(id))
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

        // POST: api/AreaAffected
        [ResponseType(typeof(AreaAffected))]
        public IHttpActionResult PostAreaAffected(AreaAffected areaAffected)
        {
            db.AreaAffecteds.Add(areaAffected);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = areaAffected.AreaID }, areaAffected);
        }

        // DELETE: api/AreaAffected/5
        [ResponseType(typeof(AreaAffected))]
        public IHttpActionResult DeleteAreaAffected(int id)
        {
            AreaAffected areaAffected = db.AreaAffecteds.Find(id);
            if (areaAffected == null)
            {
                return NotFound();
            }

            db.AreaAffecteds.Remove(areaAffected);
            db.SaveChanges();

            return Ok(areaAffected);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaAffectedExists(int id)
        {
            return db.AreaAffecteds.Count(e => e.AreaID == id) > 0;
        }
    }
}