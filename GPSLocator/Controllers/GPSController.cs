using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPSLocator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPSLocator.Controllers
{
    [Produces("application/json")]
    [Route("api/GPS")]
    public class GPSController : Controller
    {
        public static IList<LocationModel> locations = new List<LocationModel>();
        // GET: api/GPS
        [HttpGet]
        public IEnumerable<LocationModel> Get()
        {
            return locations;
        }

        // GET: api/GPS/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/GPS
        [HttpPost]
        public IActionResult Post([FromBody]LocationModel value)
        {
            locations.Add(value);
            return Ok(value);
        }
        
        // PUT: api/GPS/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
