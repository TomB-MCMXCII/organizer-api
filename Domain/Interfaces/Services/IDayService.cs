using Domain;
using Domain.Interfaces;
using Services;
using System.Collections;
using System.Collections.Generic;

namespace OrganizerApi.Domain
{
    public interface IDayService
    {
        void Delete(string date);
        ServiceResult GetDays();
        ServiceResult GetDay(string date);
    }
}