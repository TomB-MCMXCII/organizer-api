using OrganizerApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.DTOs
{
    public class NoteDto : INoteDto
    {
        public string date { get; set; }
        public string text { get; set; }
    }
}
