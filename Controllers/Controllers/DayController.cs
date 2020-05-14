using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Domain;

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

    }
}