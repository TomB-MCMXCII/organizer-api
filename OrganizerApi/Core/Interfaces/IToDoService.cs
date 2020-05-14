using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.Interfaces
{
    public interface IToDoService<T> where T : IToDoDto
    {
        public void Add(T toDoDto);
        public void Delete(int id);
        public void Update(int id, T toDoDto);
    }
}
