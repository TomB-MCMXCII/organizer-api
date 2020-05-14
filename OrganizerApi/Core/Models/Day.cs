using OrganizerApi.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class Day
    {
        public List<ToDo> toDoEntries = new List<ToDo>();
        public List<ScheduleEntry> scheduleEntries = new List<ScheduleEntry>();
        public List<Note> notes = new List<Note>();
        public int Id { get; set; }
        [Key]
        public DateTime date { get; set; } 
        public Day()
        {

        }
    }
}
