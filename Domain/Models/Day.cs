using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizerApi.Domain
{
    public class Day
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
