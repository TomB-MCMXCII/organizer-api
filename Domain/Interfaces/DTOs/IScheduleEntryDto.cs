namespace OrganizerApi.Domain
{
    public interface IScheduleEntryDto
    {
        int Id { get; set; }
        string EndTime { get; set; }
        string StartTime { get; set; }
        string Text { get; set; }
        string Date { get; set; }
    }
}