namespace OrganizerApi.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Day Day { get; set; }
    }
}
