using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSLocator.Models
{
    public class ServiceScheduler
    {
        public int Id { get; set; }
        public string ServiceId { get; set; }
        public ConfinedArea ConfinedArea { get; set; }
        public DateTime ScheduledStartDateTime { get; set; }
        public DateTime ScheduledEndDateTime { get; set; }
        public DateTime? ActualStartDateTime { get; set; }
        public DateTime? ActualEndDateTime { get; set; }
        public Status Status { get; set; }
        public IList<LocationTracker> SupervisorTracker { get; set; }
        public IList<LocationTracker> WorkerTracker { get; set; }

        public static IList<ServiceScheduler> ScheduledTasks = new List<ServiceScheduler>();
        public static ConfinedArea confinedArea1;
        public static ConfinedArea confinedArea2;
        public static ConfinedArea confinedArea3;
        public static ConfinedArea confinedArea4;
        public static void PopulateData()
        {
            confinedArea1 = new ConfinedArea { Id = 1, Name = "CA_001", ConfinedAreaType = ConfinedAreaType.Tank };
            confinedArea2 = new ConfinedArea { Id = 2, Name = "CA_002", ConfinedAreaType = ConfinedAreaType.Vessel };
            confinedArea3 = new ConfinedArea { Id = 3, Name = "CA_003", ConfinedAreaType = ConfinedAreaType.Manhole };
            confinedArea4 = new ConfinedArea { Id = 4, Name = "CA_004", ConfinedAreaType = ConfinedAreaType.Tunnel };
            ScheduledTasks = new List<ServiceScheduler>();
            ScheduledTasks.Add(new ServiceScheduler { Id = 1, ServiceId = "SR_001", ConfinedArea = confinedArea1, ScheduledStartDateTime = DateTime.Now.AddHours(-8), ScheduledEndDateTime = DateTime.Now.AddHours(-7), Status=Status.Scheduled });
            ScheduledTasks.Add(new ServiceScheduler { Id = 2, ServiceId = "SR_002", ConfinedArea = confinedArea2, ScheduledStartDateTime = DateTime.Now.AddHours(-7), ScheduledEndDateTime = DateTime.Now.AddHours(-6), Status = Status.Scheduled });
            ScheduledTasks.Add(new ServiceScheduler { Id = 3, ServiceId = "SR_003", ConfinedArea = confinedArea3, ScheduledStartDateTime = DateTime.Now.AddHours(-6), ScheduledEndDateTime = DateTime.Now.AddHours(-5), Status = Status.Scheduled });
            ScheduledTasks.Add(new ServiceScheduler { Id = 4, ServiceId = "SR_004", ConfinedArea = confinedArea4, ScheduledStartDateTime = DateTime.Now.AddHours(-5), ScheduledEndDateTime = DateTime.Now.AddHours(-4), Status = Status.Scheduled });
        }
    }
    public class LocationTracker
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? Time { get; set; }
        public TrackerType TrackerType { get; set; }
    }
    public class ConfinedArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConfinedAreaType ConfinedAreaType { get; set; }

    }
    public enum ConfinedAreaType
    {
        Tank = 1,
        Vessel,
        Manhole,
        Tunnel
    }
    public enum Status
    {
        Scheduled = 1,
        Started,
        Completed,
        Cancelled
    }
    public enum TrackerType
    {
        SOS = 1,
        Regular
    }
}
