namespace OrganizerApi.Domain
{
    public interface IScheduleService<T> where T : IScheduleEntryDto
    {
        void Add(T scheduleDto);
        void Delete(int id);
        void Update(int id, T scheduleEntryDto);
    }
}