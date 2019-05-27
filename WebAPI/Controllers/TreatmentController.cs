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
    public class TreatmentController : ApiController
    {
        private MalariaApp2Entities db = new MalariaApp2Entities();

        // GET: api/Treatment
        public IQueryable<Treatment> GetTreatments()
        {
            return db.Treatments;
        }

        // GET: api/Treatment/5
        [ResponseType(typeof(Treatment))]
        public IHttpActionResult GetTreatment(int id)
        {
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return NotFound();
            }

            return Ok(treatment);
        }

        // PUT: api/Treatment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreatment(int id, Treatment treatment)
        {
            if (id != treatment.TreatmentID)
            {
                return BadRequest();
            }

            db.Entry(treatment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(id))
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

        // POST: api/Treatment
        [ResponseType(typeof(Treatment))]
        public IHttpActionResult PostTreatment(Treatment treatment)
        {
            db.Treatments.Add(treatment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treatment.TreatmentID }, treatment);
        }

        // DELETE: api/Treatment/5
        [ResponseType(typeof(Treatment))]
        public IHttpActionResult DeleteTreatment(int id)
        {
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return NotFound();
            }

            db.Treatments.Remove(treatment);
            db.SaveChanges();

            return Ok(treatment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatmentExists(int id)
        {
            return db.Treatments.Count(e => e.TreatmentID == id) > 0;
        }
    }
}