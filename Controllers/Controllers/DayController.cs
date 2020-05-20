using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Domain;
using System.Collections.Generic;

namespace Controllers.Controllers
{
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IOrganizerDbContext organizerDbContext;
        private readonly IDayService dayService;
      
        public DayController(IOrganizerDbContext organizerDbContext, IDayService dayService)
        {
            this.organizerDbContext = organizerDbContext;
            this.dayService = dayService;
        }
        [Route("api/day/delete")]
        [HttpDelete]
        public void Delete(string date)
        {
            dayService.Delete(date);
        }
        [Route("api/day/getDay")]
        [HttpGet]
        public IDayDto GetDay(string date)
        {
           return  dayService.GetDay(date);
        }
        [Route("api/day/getDays")]
        [HttpGet]
        public ICollection<IDayDto> GetDays()
        {
            return dayService.GetDays();
        }

    }
}