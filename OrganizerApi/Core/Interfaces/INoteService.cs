using OrganizerApi.Core.DTOs;
using OrganizerApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.Interfaces
{
    public interface INoteService<T> where T : INoteDto
    {
        public void Add(T noteDto);
        public void Delete(int id);
        public void Update(int id, T noteDto);
    }
}
