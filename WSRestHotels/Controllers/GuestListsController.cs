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
using WSRestHotels;

namespace WSRestHotels.Controllers
{
    public class GuestListsController : ApiController
    {
        private HotelContext2 db = new HotelContext2();

        // GET: api/GuestLists
        [ActionName("DefaultAction")]
        public IQueryable<GuestList> GetGuestLists()
        {
            return db.GuestLists;
        }

        // GET: api/GuestLists/2014-10-22  yyyy-mm-dd
        [ActionName("DefaultAction")]
        public IQueryable<GuestListDTO> GetGuestList(DateTime id)
        {
            var guestList = from guests in db.GuestLists
                            where (guests.Date_From <= id) && (guests.Date_To >= id)
                            select new GuestListDTO
                            {
                                GuestName = guests.GuestName,
                                HotelName = guests.HotelName,
                                RoomNo = guests.Room_No

                            };



            return guestList;
        }

        // PUT: api/GuestLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestList(string id, GuestList guestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestList.HotelName)
            {
                return BadRequest();
            }

            db.Entry(guestList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestListExists(id))
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

        // POST: api/GuestLists
        [ResponseType(typeof(GuestList))]
        public IHttpActionResult PostGuestList(GuestList guestList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestLists.Add(guestList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestListExists(guestList.HotelName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestList.HotelName }, guestList);
        }

        // DELETE: api/GuestLists/5
        [ResponseType(typeof(GuestList))]
        public IHttpActionResult DeleteGuestList(string id)
        {
            GuestList guestList = db.GuestLists.Find(id);
            if (guestList == null)
            {
                return NotFound();
            }

            db.GuestLists.Remove(guestList);
            db.SaveChanges();

            return Ok(guestList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestListExists(string id)
        {
            return db.GuestLists.Count(e => e.HotelName == id) > 0;
        }
    }
}