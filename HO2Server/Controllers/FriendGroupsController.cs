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
    public class FriendGroupsController : ApiController
    {
        private HO2Context db = new HO2Context();

        // GET: api/FriendGroups
        public IQueryable<FriendGroup> GetGroups()
        {
            return db.Groups;
        }

        // GET: api/FriendGroups/5
        [ResponseType(typeof(FriendGroup))]
        public async Task<IHttpActionResult> GetFriendGroup(int id)
        {
            FriendGroup friendGroup = await db.Groups.FindAsync(id);
            if (friendGroup == null)
            {
                return NotFound();
            }

            return Ok(friendGroup);
        }

        // PUT: api/FriendGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFriendGroup(int id, FriendGroup friendGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friendGroup.FriendGroupId)
            {
                return BadRequest();
            }

            db.Entry(friendGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendGroupExists(id))
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

        // POST: api/FriendGroups
        [ResponseType(typeof(FriendGroup))]
        public async Task<IHttpActionResult> PostFriendGroup(FriendGroup friendGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(friendGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = friendGroup.FriendGroupId }, friendGroup);
        }

        // DELETE: api/FriendGroups/5
        [ResponseType(typeof(FriendGroup))]
        public async Task<IHttpActionResult> DeleteFriendGroup(int id)
        {
            FriendGroup friendGroup = await db.Groups.FindAsync(id);
            if (friendGroup == null)
            {
                return NotFound();
            }

            db.Groups.Remove(friendGroup);
            await db.SaveChangesAsync();

            return Ok(friendGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendGroupExists(int id)
        {
            return db.Groups.Count(e => e.FriendGroupId == id) > 0;
        }
    }
}