namespace OrganizerApi.Domain
{
    public interface INoteService<T> where T : INoteDto
    {
        public void Add(T noteDto);
        public void Delete(int id);
        public void Update(int id, T noteDto);
    }
}
