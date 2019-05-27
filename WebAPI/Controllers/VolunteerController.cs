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
    public class VolunteerController : ApiController
    {
        private MalariaApp2Entities db = new MalariaApp2Entities();

        // GET: api/Volunteer
        public IQueryable<Volunteer> GetVolunteers()
        {
            return db.Volunteers;
        }

        // GET: api/Volunteer/5
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult GetVolunteer(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return Ok(volunteer);
        }

        // PUT: api/Volunteer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVolunteer(int id, Volunteer volunteer)
        {
            if (id != volunteer.VolunteerID)
            {
                return BadRequest();
            }

            db.Entry(volunteer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(id))
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

        // POST: api/Volunteer
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult PostVolunteer(Volunteer volunteer)
        {
            db.Volunteers.Add(volunteer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = volunteer.VolunteerID }, volunteer);
        }

        // DELETE: api/Volunteer/5
        [ResponseType(typeof(Volunteer))]
        public IHttpActionResult DeleteVolunteer(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            db.Volunteers.Remove(volunteer);
            db.SaveChanges();

            return Ok(volunteer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VolunteerExists(int id)
        {
            return db.Volunteers.Count(e => e.VolunteerID == id) > 0;
        }
    }
}