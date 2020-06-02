using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerApi.Domain
{
    public class ScheduleEntryDto : IScheduleEntryDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }
    }
}
