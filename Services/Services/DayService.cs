using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrganizerApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class DayService : IDayService
    {
        private IOrganizerDbContext organizerDbContext;
        private INoteDto noteDTO;

        public DayService(IOrganizerDbContext organizerDbContext, INoteDto noteDTO)
        {
            this.organizerDbContext = organizerDbContext;
            this.noteDTO = noteDTO;
        }

        public void Delete(string date)
        {
            var dateTime = DateTime.Parse(date);
            var day = organizerDbContext.Days.Find(dateTime);

            organizerDbContext.Days.Remove(day);
            organizerDbContext.SaveChanges();
        }

        public IDayDto GetDay(string date)
        {
            var dateTime = DateTime.Parse(date);
            var day = organizerDbContext.Days.Include(x => x.ToDoEntries).Include(x => x.Notes).Include(x => x.ScheduleEntries).Where(x => x.date == dateTime).First();
            var noteDtos = new List<INoteDto>();
            var toDoDtos = new List<IToDoDto>();
            foreach (var a in day.Notes)
            {
                noteDtos.Add(new NoteDto()
                {
                    date = a.Day.date.ToString(),
                    text = a.Text
                }) ;
            }
            foreach (var a in day.ToDoEntries)
            {
                toDoDtos.Add(new ToDoDto()
                {
                    Date = a.Day.date.ToString(),
                    Text = a.Text,
                    IsDone = a.IsDone,
                }) ;
            }
            return new DayDto()
            {
                Date = day.date,
                NoteDtos = noteDtos,
                ToDoDtos = toDoDtos,
            };
        }

        public ICollection<IDayDto> GetDays()
        {
            throw new NotImplementedException();
        }
    }
}
