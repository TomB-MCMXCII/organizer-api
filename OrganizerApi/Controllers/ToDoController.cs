using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Core.DTOs;
using OrganizerApi.Core.Interfaces;
using OrganizerApi.Core.Services;
using OrganizerApi.Data;
using OrganizerApi.Models;


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
    }
}
