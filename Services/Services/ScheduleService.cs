using OrganizerApi.Domain;
using System;

namespace Services.Services
{
    public class ScheduleService<T> : IScheduleService<T> where T : IScheduleEntryDto
    {
        private readonly IOrganizerDbContext organizerDbContext;
        private readonly IScheduleEntryDto scheduleEntryDto;
        public ScheduleService(IOrganizerDbContext organizerDbContext, IScheduleEntryDto scheduleEntryDto)
        {
            this.organizerDbContext = organizerDbContext;
            this.scheduleEntryDto = scheduleEntryDto;
        }
        public void Add(T scheduleDto)
        {
            var day = organizerDbContext.Days.Find(DateTime.Parse(scheduleDto.Date));
            if (day == null)
            {
                day = new Day()
                {
                    date = DateTime.Parse(scheduleDto.Date)
                };

                var scheduleEntry = new ScheduleEntry()
                {
                    Text = scheduleDto.Text,
                    Day = day,
                    StartTime = DateTime.Parse(scheduleDto.StartTime),
                    EndTime = DateTime.Parse(scheduleDto.EndTime)
                };
                organizerDbContext.Days.Add(day);
                organizerDbContext.ScheduleEntries.Add(scheduleEntry);
                organizerDbContext.SaveChanges();
            }
            else
            {
                organizerDbContext.ScheduleEntries.Add(new ScheduleEntry()
                {
                    Text = scheduleDto.Text,
                    Day = day,
                    StartTime = DateTime.Parse(scheduleDto.StartTime),
                    EndTime = DateTime.Parse(scheduleDto.EndTime)
                });
            }
            organizerDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var scheduleEntry = organizerDbContext.ScheduleEntries.Find(id);
            organizerDbContext.ScheduleEntries.Remove(scheduleEntry);
            organizerDbContext.SaveChanges();
        }
        public void Update(int id, T scheduleEntryDto)
        {
            var scheduleEntry = organizerDbContext.ScheduleEntries.Find(id);
            scheduleEntry.Text = scheduleEntryDto.Text;
            scheduleEntry.StartTime = DateTime.Parse(scheduleEntryDto.StartTime);
            scheduleEntry.EndTime = DateTime.Parse(scheduleEntryDto.EndTime);
            organizerDbContext.ScheduleEntries.Update(scheduleEntry);
            organizerDbContext.SaveChanges();
        }
    }
}
