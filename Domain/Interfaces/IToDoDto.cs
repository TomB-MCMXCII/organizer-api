using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Domain
{
    public interface IToDoDto
    {
        string Text { get; set; }
        string Date { get; set; }
        bool IsDone { get; set; }
    }
}
