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
    public class VotesController : ApiController
    {
        private HO2Context db = new HO2Context();

        // GET: api/Votes
        public IQueryable<Vote> GetVotes()
        {
            return db.Votes;
        }

        //// GET: api/Group/Votes/5
        //[ResponseType(typeof(Vote))]
        //public IQueryable<Vote> GetGroupVotes(int groupId)
        //{
        //    IQueryable<Vote> votes = db.Votes.Where(v => v.FriendGroup.FriendGroupId == groupId);
           
        //    return votes;
        //}

        // GET: api/Votes/5
        [ResponseType(typeof(Vote))]
        public async Task<IHttpActionResult> GetVote(int id)
        {
            Vote vote = await db.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        // PUT: api/Votes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVote(int id, Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.VoteId)
            {
                return BadRequest();
            }

            db.Entry(vote).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
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

        // POST: api/Votes
        [ResponseType(typeof(Vote))]
        public async Task<IHttpActionResult> PostVote(Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Votes.Add(vote);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vote.VoteId }, vote);
        }

        // DELETE: api/Votes/5
        [ResponseType(typeof(Vote))]
        public async Task<IHttpActionResult> DeleteVote(int id)
        {
            Vote vote = await db.Votes.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            db.Votes.Remove(vote);
            await db.SaveChangesAsync();

            return Ok(vote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteExists(int id)
        {
            return db.Votes.Count(e => e.VoteId == id) > 0;
        }
    }
}