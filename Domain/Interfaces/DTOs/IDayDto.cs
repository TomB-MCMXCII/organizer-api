using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDayDto
    {
        int id { get; set; }
        string date { get; set; }
        ICollection<INoteDto> NoteDtos { get; set; }
        ICollection<IToDoDto> ToDoDtos { get; set; }
        ICollection<IScheduleEntryDto> ScheduleDtos { get; set; }
    }
}
