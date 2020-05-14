using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganizerApi.Domain
{
    public class Day
    {
        public ICollection<ToDo> ToDoEntries { get; set; }
        public ICollection<ScheduleEntry> ScheduleEntries { get; set; }
        public ICollection<Note> Notes { get; set; }
        [Key]
        public DateTime date { get; set; } 
        public Day()
        {

        }
    }
}
