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
    public class SponsorController : ApiController
    {
        private MalariaApp2Entities db = new MalariaApp2Entities();

        // GET: api/Sponsor
        public IQueryable<Sponsor> GetSponsors()
        {
            return db.Sponsors;
        }

        // GET: api/Sponsor/5
        [ResponseType(typeof(Sponsor))]
        public IHttpActionResult GetSponsor(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return Ok(sponsor);
        }

        // PUT: api/Sponsor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSponsor(int id, Sponsor sponsor)
        {
            if (id != sponsor.SponsorID)
            {
                return BadRequest();
            }

            db.Entry(sponsor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(id))
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

        // POST: api/Sponsor
        [ResponseType(typeof(Sponsor))]
        public IHttpActionResult PostSponsor(Sponsor sponsor)
        {
            db.Sponsors.Add(sponsor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sponsor.SponsorID }, sponsor);
        }

        // DELETE: api/Sponsor/5
        [ResponseType(typeof(Sponsor))]
        public IHttpActionResult DeleteSponsor(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            db.Sponsors.Remove(sponsor);
            db.SaveChanges();

            return Ok(sponsor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SponsorExists(int id)
        {
            return db.Sponsors.Count(e => e.SponsorID == id) > 0;
        }
    }
}