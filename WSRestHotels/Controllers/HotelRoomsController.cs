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
    public class HotelRoomsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/HotelRooms
        [ActionName("DefaultAction")]
        public IQueryable<HotelRoom> GetHotelRooms()
        {
            return db.HotelRooms;
        }

        // GET: api/HotelRooms/5
        [ActionName("DefaultAction")]
        [ResponseType(typeof(HotelRoom))]
        public IHttpActionResult GetHotelRoom(string id)
        {
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return Ok(hotelRoom);
        }

        // PUT: api/HotelRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelRoom(string id, HotelRoom hotelRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelRoom.Name)
            {
                return BadRequest();
            }

            db.Entry(hotelRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomExists(id))
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

        // POST: api/HotelRooms
        [ResponseType(typeof(HotelRoom))]
        public IHttpActionResult PostHotelRoom(HotelRoom hotelRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelRooms.Add(hotelRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HotelRoomExists(hotelRoom.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotelRoom.Name }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [ResponseType(typeof(HotelRoom))]
        public IHttpActionResult DeleteHotelRoom(string id)
        {
            HotelRoom hotelRoom = db.HotelRooms.Find(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            db.HotelRooms.Remove(hotelRoom);
            db.SaveChanges();

            return Ok(hotelRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelRoomExists(string id)
        {
            return db.HotelRooms.Count(e => e.Name == id) > 0;
        }
    }
}