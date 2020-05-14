using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Services
{
    public class NoteService<T> : INoteService<T> where T : INoteDto
    {
        private readonly IOrganizerDbContext organizerDbContext;
        private readonly INoteDto noteDTO;
        public NoteService(IOrganizerDbContext organizerDbContext, INoteDto noteDTO)
        {
            this.organizerDbContext = organizerDbContext;
            this.noteDTO = noteDTO;
        }
        public void Add(T noteDto)
        {
            var day = organizerDbContext.Days.Find(DateTime.Parse(noteDto.date));
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
                organizerDbContext.Days.Add(day);
                organizerDbContext.Notes.Add(note);
                organizerDbContext.SaveChanges();
            }
            else
            {
                organizerDbContext.Notes.Add(new Note()
                {
                    Text = noteDto.text,
                    Day = day
                });
            }
            organizerDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var note = organizerDbContext.Notes.Find(id);
            organizerDbContext.Notes.Remove(note);
            organizerDbContext.SaveChanges();
        }
        public void Update(int id, T noteDto)
        {
            var note = organizerDbContext.Notes.Find(id);
            note.Text = noteDto.text;
            organizerDbContext.Notes.Update(note);
            organizerDbContext.SaveChanges();
        }
    }
}
