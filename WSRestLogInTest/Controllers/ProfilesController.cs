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
using WSRestLogInTest;

namespace WSRestLogInTest.Controllers
{
    public class ProfilesController : ApiController
    {
        private ProfileContext db = new ProfileContext();

        // GET: api/Profiles
        public IQueryable<Profile> GetProfiles()
        {
           
            return db.Profiles;
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        [Route("api/Profiles/{userName}/{password}")]
        public IHttpActionResult GetProfile(string username, string password)
        {
            Profile profile = null;
            foreach (var user in db.Profiles)
            {
                if (user.Username.Trim().Equals(username) && user.Password.Trim().Equals(password))
                    profile = user;

            }
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

   }
}