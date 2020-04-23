using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Models;
using OrganizerApi.Services;

namespace OrganizerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        OrganizerService organizerServices = OrganizerService.GetInstance();

        // GET: api/Organizer
        [HttpGet]
        public Year GetAllDays()
        {
            return organizerServices.GetCurrentYear();
        }
        [Route("addtodo")]
        [HttpPost]
        public void CreateTodoEntry(string date, string text)
        {
            organizerServices.CreateTodoEntry(date,text);
        }
        [Route("addschedule")]
        [HttpPost]
        public void CreateScheduleEntry(string date,string startTime, string endTime, string text)
        {
            organizerServices.CreateScheduleEntry(date, startTime, endTime, text);
        }
    }
}
