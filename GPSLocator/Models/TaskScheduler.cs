using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSLocator.Models
{
    public class TaskScheduler
    {
        public int Id { get; set; }
        public string ServiceId { get; set; }
        public ConfinedArea ConfinedArea { get; set; }
        public DateTime ScheduledStartDateTime { get; set; }
        public DateTime ScheduledEndDateTime { get; set; }
        public DateTime ActualStartDateTime { get; set; }
        public DateTime ActualEndDateTime { get; set; }
        public IList<LocationTracker> SupervisorTracker { get; set; }
        public IList<LocationTracker> WorkerTracker { get; set; }
    }
    public class LocationTracker {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public TrackerType TrackerType { get; set; }
    }
    public class ConfinedArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConfinedAreaType ConfinedAreaType { get; set; }

    }
    public enum ConfinedAreaType {
        Tank=1,
        Vesssel,
        Manhole,
        Tunnel
    }
    public enum Status {
        Scheduled=1,
        Started,
        Completed,
        Cancelled
    }
    public enum TrackerType {
        SOS=1,
        Regular
    }
}
