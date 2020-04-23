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
        OrganizerServices organizerServices = OrganizerServices.GetInstance();

        // GET: api/Organizer
        [HttpGet]
        public Year GetAllDays()
        {
            return organizerServices.GetCurrentYear();
        }
        [Route("addtodo")]
        [HttpPost]
        public void CreateTodo(string date, string text)
        {
            organizerServices.CreateTodo(date,text);
        }
    }
}
