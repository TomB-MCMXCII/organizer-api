using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Domain;
using System.Collections.Generic;

namespace Controllers.Controllers
{
    [EnableCors("myPolicy")]
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
        public IActionResult GetDay(string date)
        {
            var serviceResult = dayService.GetDay(date);
            if (serviceResult.result)
            {
                return Ok(serviceResult.baseDto);
            }
            else
            {
                return NoContent();
            }
           
        }
        [Route("api/day/getDays")]
        [HttpGet]
        public IActionResult GetDays()
        {
            var serviceResult = dayService.GetDays();
            if(serviceResult.result)
            {
                return Ok(serviceResult.dayDtoList);
            }
            else
            {
                return NoContent();
            }
        }

    }
}