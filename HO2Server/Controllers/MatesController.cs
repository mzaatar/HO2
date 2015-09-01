using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HO2Server.DAL;
using HO2Server.Models.Business;

namespace HO2Server.Controllers
{
    public class MatesController : ApiController
    {
        private HO2Context db = new HO2Context();

        // GET: api/Mates
        public IQueryable<Mate> GetMates()
        {
            return db.Mates;
        }

        // GET: api/Mates/5
        [ResponseType(typeof(Mate))]
        public async Task<IHttpActionResult> GetMate(int id)
        {
            Mate mate = await db.Mates.FindAsync(id);
            if (mate == null)
            {
                return NotFound();
            }

            return Ok(mate);
        }

        // PUT: api/Mates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMate(int id, Mate mate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mate.MateId)
            {
                return BadRequest();
            }

            db.Entry(mate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateExists(id))
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

        // POST: api/Mates
        [ResponseType(typeof(Mate))]
        public async Task<IHttpActionResult> PostMate(Mate mate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mates.Add(mate);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mate.MateId }, mate);
        }

        // DELETE: api/Mates/5
        [ResponseType(typeof(Mate))]
        public async Task<IHttpActionResult> DeleteMate(int id)
        {
            Mate mate = await db.Mates.FindAsync(id);
            if (mate == null)
            {
                return NotFound();
            }

            db.Mates.Remove(mate);
            await db.SaveChangesAsync();

            return Ok(mate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateExists(int id)
        {
            return db.Mates.Count(e => e.MateId == id) > 0;
        }
    }
}