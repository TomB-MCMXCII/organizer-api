using Domain;
using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using OrganizerApi.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerApi.Services
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

        public ServiceResult<T> GetDay<T>(string date) where T : BaseDto
        {
            var dateTime = DateTime.Parse(date);
            var day = organizerDbContext.Days.Include(x => x.ToDoEntries).Include(x => x.Notes).Include(x => x.ScheduleEntries).Where(x => x.date == dateTime).FirstOrDefault();
            var noteDtos = new List<INoteDto>();
            var toDoDtos = new List<IToDoDto>();
            var shceduleDtos = new List<IScheduleEntryDto>();
            //could make a factory to create dto objects
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
                    Id = a.Id,
                    Date = a.Day.date.ToString(),
                    Text = a.Text,
                    IsDone = a.IsDone,
                }) ;
            }
            foreach (var a in day.ScheduleEntries)
            {
                shceduleDtos.Add(new ScheduleEntryDto()
                {
                    Id = a.Id,
                    Date = a.Day.date.ToString(),
                    Text = a.Text,
                    StartTime = a.StartTime.ToShortTimeString(),
                    EndTime = a.EndTime.ToShortTimeString()
                });
            }
            var dayDto =  new DayDto()
            {
                id = day.Id,
                date = day.date.ToString(),
                NoteDtos = noteDtos,
                ToDoDtos = toDoDtos,
                ScheduleDtos = shceduleDtos
            };
            return new ServiceResult<T>(dayDto, true);
           
        }

        public ICollection<IDayDto> GetDays()
        {
            var days = organizerDbContext.Days.Include(x => x.ToDoEntries).Include(x => x.Notes).Include(x => x.ScheduleEntries);
            var daysList = new List<IDayDto>();
            foreach(var d in days)
            {
                var noteDtos = new List<INoteDto>();
                var toDoDtos = new List<IToDoDto>();
                var scheduleDtos = new List<IScheduleEntryDto>();
                foreach (var a in d.Notes)
                {
                    noteDtos.Add(new NoteDto()
                    {
                        id = a.Id,
                        date = a.Day.date.ToString(),
                        text = a.Text
                    });
                }
                foreach (var a in d.ToDoEntries)
                {
                    toDoDtos.Add(new ToDoDto()
                    {
                        Id = a.Id,
                        Date = a.Day.date.ToString(),
                        Text = a.Text,
                        IsDone = a.IsDone,
                    });
                }
                foreach (var a in d.ScheduleEntries)
                {
                    scheduleDtos.Add(new ScheduleEntryDto()
                    {
                        Date = a.Day.date.ToString(),
                        Text = a.Text,
                        StartTime = a.StartTime.ToShortTimeString(),
                        EndTime = a.EndTime.ToShortTimeString()
                    });
                }
                var day = new DayDto()
                {
                    id = d.Id,
                    date = d.date.ToString(),
                    ToDoDtos = toDoDtos,
                    NoteDtos = noteDtos,
                    ScheduleDtos = scheduleDtos
                };
                daysList.Add(day);
            }
            return daysList;
        }
    }
}
