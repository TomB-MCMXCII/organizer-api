using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDayDto
    {
        DateTime Date { get; set; }
        ICollection<INoteDto> NoteDtos { get; set; }
        ICollection<IToDoDto> ToDoDtos { get; set; }
        ICollection<IScheduleEntryDto> ScheduleDtos { get; set; }
    }
}
