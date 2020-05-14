using OrganizerApi.Domain;
using System;

namespace OrganizerApi.Services
{
    public class ToDoService<T> : IToDoService<T> where T : IToDoDto
    {
        private readonly IOrganizerDbContext organizerDbContext;
        private readonly IToDoDto toDoDto;
        public ToDoService(IOrganizerDbContext organizerDbContext, IToDoDto toDoDto)
        {
            this.organizerDbContext = organizerDbContext;
            this.toDoDto = toDoDto;
        }
        public void Add(T toDoDto)
        {
            var day = organizerDbContext.Days.Find(DateTime.Parse(toDoDto.Date));
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
                organizerDbContext.Days.Add(day);
                organizerDbContext.ToDoEntries.Add(toDo);
                organizerDbContext.SaveChanges();
            }
            else
            {
                organizerDbContext.ToDoEntries.Add(new ToDo()
                {
                    Text = toDoDto.Text,
                    Day = day,
                    IsDone = toDoDto.IsDone
                });
            }
            organizerDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var todo = organizerDbContext.ToDoEntries.Find(id);
            organizerDbContext.ToDoEntries.Remove(todo);
            organizerDbContext.SaveChanges();
        }
        public void Update(int id, T toDoDto)
        {
            var toDo = organizerDbContext.ToDoEntries.Find(id);
            toDo.Text = toDoDto.Text;
            toDo.IsDone = toDoDto.IsDone;
            organizerDbContext.ToDoEntries.Update(toDo);
            organizerDbContext.SaveChanges();
        }
    }
}
