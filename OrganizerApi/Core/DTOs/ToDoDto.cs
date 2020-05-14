using OrganizerApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OrganizerApi.Core.DTOs
{
    public class ToDoDto : IToDoDto
    {
        public string Text { get; set; }
        public string Date { get; set; }
        public bool IsDone { get; set; }

    }
}
