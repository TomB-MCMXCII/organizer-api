using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using OrganizerApi.Domain;

namespace OrganizerApi.Controllers
{
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IOrganizerDbContext _organizerDbContext;
        private readonly IToDoService<IToDoDto> _toDoService;
        public ToDoController(IOrganizerDbContext organizerDbContext,IToDoService<IToDoDto> toDoService)
        {
            _organizerDbContext = organizerDbContext;
            _toDoService = toDoService;
        }
        [Route("api/todo/add")]
        [HttpPost]
        public void Add(ToDoDto toDoDto)
        {
            _toDoService.Add(toDoDto);
            
        }
        [Route("api/todo/delete")]
        [HttpDelete]
        public void Delete(int id)
        {
            _toDoService.Delete(id);
        }
        [Route("api/todo/update")]
        public void Update(int id, ToDoDto toDoDto)
        {
            _toDoService.Update(id, toDoDto);
        }
    }
}
