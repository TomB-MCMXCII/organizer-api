using OrganizerApi.Core.DTOs;
using OrganizerApi.Core.Interfaces;
using OrganizerApi.Core.Models;
using OrganizerApi.Data;
using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.Services
{
    public class NoteService<T> : INoteService<T> where T : INoteDto
    {
        private readonly IOrganizerDbContext _organizerDbContext;
        private readonly INoteDto _noteDTO;
        public NoteService(IOrganizerDbContext organizerDbContext, INoteDto noteDTO)
        {
            _organizerDbContext = organizerDbContext;
            _noteDTO = noteDTO;
        }
        public void Add(T noteDto)
        {
            var day = _organizerDbContext.Days.Find(DateTime.Parse(noteDto.date));
            if (day == null)
            {
                day = new Day() 
                {
                    date = DateTime.Parse(noteDto.date)
                };
               
                var note = new Note()
                {
                    Text = noteDto.text,
                    Day = day
                };
                _organizerDbContext.Days.Add(day);
                _organizerDbContext.Notes.Add(note);
                _organizerDbContext.SaveChanges();
            }
            else
            {
                _organizerDbContext.Notes.Add(new Note()
                {
                    Text = noteDto.text,
                    Day = day
                });
            }
            _organizerDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var note = _organizerDbContext.Notes.Find(id);
            _organizerDbContext.Notes.Remove(note);
            _organizerDbContext.SaveChanges();
        }
        public void Update(int id, T noteDto)
        {
            var note = _organizerDbContext.Notes.Find(id);
            note.Text = noteDto.text;
            _organizerDbContext.Notes.Update(note);
            _organizerDbContext.SaveChanges();
        }
    }
}
