namespace OrganizerApi.Domain
{
    public class ToDoDto : IToDoDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public bool IsDone { get; set; }

    }
}
