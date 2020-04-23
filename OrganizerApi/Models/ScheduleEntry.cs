using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class ScheduleEntry
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string text { get; set; }
    }
}
