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
    public class DonorController : ApiController
    {
        private MalariaApp2Entities db = new MalariaApp2Entities();

        // GET: api/Donor
        public IQueryable<Donor> GetDonors()
        {
            return db.Donors;
        }

        // GET: api/Donor/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult GetDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }

        // PUT: api/Donor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonor(int id, Donor donor)
        {
            if (id != donor.DonorID)
            {
                return BadRequest();
            }

            db.Entry(donor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(id))
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

        // POST: api/Donor
        [ResponseType(typeof(Donor))]
        public IHttpActionResult PostDonor(Donor donor)
        {
            db.Donors.Add(donor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donor.DonorID }, donor);
        }

        // DELETE: api/Donor/5
        [ResponseType(typeof(Donor))]
        public IHttpActionResult DeleteDonor(int id)
        {
            Donor donor = db.Donors.Find(id);
            if (donor == null)
            {
                return NotFound();
            }

            db.Donors.Remove(donor);
            db.SaveChanges();

            return Ok(donor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonorExists(int id)
        {
            return db.Donors.Count(e => e.DonorID == id) > 0;
        }
    }
}