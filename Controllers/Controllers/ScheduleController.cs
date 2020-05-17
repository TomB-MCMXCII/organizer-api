using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Domain;

namespace Controllers.Controllers
{
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IOrganizerDbContext organizerDbContext;
        private readonly IScheduleService<IScheduleEntryDto> scheduleService;
        public ScheduleController(IOrganizerDbContext organizerDbContext,IScheduleService<IScheduleEntryDto> scheduleService)
        {
            this.organizerDbContext = organizerDbContext;
            this.scheduleService = scheduleService;
        }
        [Route("api/schedule/add")]
        [HttpPost]
        public void Add(ScheduleEntryDto scheduleDto)
        {
            scheduleService.Add(scheduleDto);
        }
    }
}