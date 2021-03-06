﻿using Domain;
using Domain.DTOs;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public ServiceResult GetDay(string date)
        {
            var dateTime = DateTime.Parse(date);
            var day = organizerDbContext.Days.Include(x => x.ToDoEntries).Include(x => x.Notes).Include(x => x.ScheduleEntries).Where(x => x.date == dateTime).FirstOrDefault();
            if (day == null)
            {
                return new ServiceResult(false);
            }
            else
            {
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
                    });
                }
                foreach (var a in day.ToDoEntries)
                {
                    toDoDtos.Add(new ToDoDto()
                    {
                        Id = a.Id,
                        Date = a.Day.date.ToString(),
                        Text = a.Text,
                        IsDone = a.IsDone,
                    });
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
                var dayDto = new DayDto()
                {
                    id = day.Id,
                    date = day.date.ToString(),
                    NoteDtos = noteDtos,
                    ToDoDtos = toDoDtos,
                    ScheduleDtos = shceduleDtos
                };

                return new ServiceResult(dayDto, true);
            }

        }

        public ServiceResult GetDays()
        {
            var days = organizerDbContext.Days.Include(x => x.ToDoEntries).Include(x => x.Notes).Include(x => x.ScheduleEntries);
            if (days == null)
            {
                return new ServiceResult(false);
            }
            else
            {
                var daysList = new List<IDayDto>();

                foreach (var d in days)
                {
                    if (isDayEmpty(d))
                    {
                        continue;
                    }

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
                        date = d.date.ToString("yyyy-MM-dd"),
                        ToDoDtos = toDoDtos,
                        NoteDtos = noteDtos,
                        ScheduleDtos = scheduleDtos
                    };
                    daysList.Add(day);
                }
                if(daysList.Count == 0)
                {
                    organizerDbContext.SaveChanges();
                    return new ServiceResult(false);
                }
                organizerDbContext.SaveChanges();
                return new ServiceResult(daysList, true);
            }
        }

        public bool isDayEmpty(Day day)
        {
            if(day.Notes.Count == 0 && day.ScheduleEntries.Count == 0 && day.ToDoEntries.Count == 0)
            {
                organizerDbContext.Days.Remove(day);
               
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
