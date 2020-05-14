using Microsoft.CodeAnalysis.CSharp.Syntax;
using OrganizerApi.Core.Interfaces;
using OrganizerApi.Data;
using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.Services
{
    public class ToDoService<T> : IToDoService<T> where T : IToDoDto
    {
        private readonly IOrganizerDbContext _organizerDbContext;
        private readonly IToDoDto _toDoDto;
        public ToDoService(IOrganizerDbContext organizerDbContext, IToDoDto toDoDto)
        {
            _organizerDbContext = organizerDbContext;
            _toDoDto = toDoDto;
        }
        public void Add(T toDoDto)
        {
            var day = _organizerDbContext.Days.Find(DateTime.Parse(toDoDto.Date));
            if (day == null)
            {
                day = new Day()
                {
                    date = DateTime.Parse(toDoDto.Date)
                };

                var toDo = new ToDo()
                {
                    Text = toDoDto.Text,
                    Day = day,
                    IsDone = toDoDto.IsDone
                };
                _organizerDbContext.Days.Add(day);
                _organizerDbContext.ToDoEntries.Add(toDo);
                _organizerDbContext.SaveChanges();
            }
            else
            {
                _organizerDbContext.ToDoEntries.Add(new ToDo()
                {
                    Text = toDoDto.Text,
                    Day = day,
                    IsDone = toDoDto.IsDone
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
            var toDo = _organizerDbContext.ToDoEntries.Find(id);
            toDo.Text = noteDto.Text;
            toDo.IsDone = noteDto.IsDone;
            _organizerDbContext.ToDoEntries.Update(toDo);
            _organizerDbContext.SaveChanges();
        }
    }
}
