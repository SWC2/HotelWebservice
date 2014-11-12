using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSRestHotels.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        [ActionName("DefaultAction")]
        [HttpGet]
        public IEnumerable<string> Foo1()
        {
            return new string[] { "Foo1", "value1" };
        }
        
        // GET: api/Test/Foo2
        [Route("api/Test/Foo2")] 
        [HttpGet]
        public IEnumerable<string> Foo2()
        {
            return new string[] { "Foo2", "value2" };
        }

        // GET: api/Test/Foo3
        [Route("api/Test/Foo3")]
        [HttpGet]
        public IEnumerable<string> Foo3()
        {
            return new string[] { "Foo3", "value3" };
        }
        

        // GET: api/Test/1
        [ActionName("DefaultAction")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
