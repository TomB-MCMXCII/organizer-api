namespace OrganizerApi.Domain
{
    public class NoteDto : INoteDto
    {
        public string date { get; set; }
        public string text { get; set; }
        public int id { get; set; }
    }
}
