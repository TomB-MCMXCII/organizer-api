﻿using Microsoft.AspNetCore.Mvc;
using OrganizerApi.Domain;

namespace OrganizerApi.Controllers
{
    [ApiController]
    public class NoteController : ControllerBase 
    {
        private readonly IOrganizerDbContext _organizerDbContext;
        private readonly INoteService<INoteDto> _noteService;
        public NoteController(IOrganizerDbContext organizerDbContext, INoteService<INoteDto> noteService)
        {
            _organizerDbContext = organizerDbContext;
            _noteService = noteService;
        }
        [Route("api/note/add")]
        [HttpPost]
        public void Add(NoteDto noteDto)
        {
            _noteService.Add(noteDto);

        }
        [Route("api/note/delete")]
        [HttpDelete]
        public void Delete(int id)
        {
            _noteService.Delete(id);
        }
        [Route("api/note/update")]
        [HttpPatch]
        public void Update(int id, NoteDto noteDto)
        {
            _noteService.Update(id, noteDto);
        }

    }
}
