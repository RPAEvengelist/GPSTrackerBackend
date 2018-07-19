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
        //public static IList<LocationModel> locations = new List<LocationModel>();
        // GET: api/GPS
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ServiceScheduler.ScheduledTasks.Where(i => i.Status == Status.Scheduled).Select(i => i.ServiceId);
        }

        // GET: api/GPS/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            ServiceScheduler.PopulateData();
            return "rawdata added";
        }

        // POST: api/GPS
        //[HttpPost]
        //public IActionResult Post([FromBody]LocationModel value)
        //{
        //    locations.Add(value);
        //    return Ok(value);
        //}
        [HttpPost]
        public IActionResult Post([FromBody]ServiceScheduler value, string postType)
        {
            var service = ServiceScheduler.ScheduledTasks.First(i => i.ServiceId == value.ServiceId.ToUpper());
            if (postType == "start")
            {
                service.ActualStartDateTime = value.ActualStartDateTime;
                service.Status = Status.Started;
            }
            if (postType == "stop")
            {
                service.ActualEndDateTime = value.ActualEndDateTime;
                service.Status = Status.Completed;
            }
            if (postType == "cancelled")
            {
                service.ActualStartDateTime = value.ActualStartDateTime;
                service.ActualEndDateTime = value.ActualEndDateTime;
                service.Status = Status.Cancelled;
            }
            if (value.WorkerTracker != null && value.WorkerTracker.Any())
            {
                if (service.WorkerTracker == null)
                    service.WorkerTracker = new List<LocationTracker>();

                service.WorkerTracker.Add(new LocationTracker
                {
                    Latitude = value.WorkerTracker.First().Latitude,
                    Longitude = value.WorkerTracker.First().Longitude,
                    Time = DateTime.Now,
                    TrackerType = postType == "sos" ? TrackerType.SOS : TrackerType.Regular
                });
            }
            return Ok();
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
