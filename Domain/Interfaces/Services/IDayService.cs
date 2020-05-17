using Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace OrganizerApi.Domain
{
    public interface IDayService
    {
        void Delete(string date);
        ICollection<IDayDto> GetDays();
        IDayDto GetDay(string date);
    }
}