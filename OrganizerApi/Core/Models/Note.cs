using OrganizerApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Core.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual Day Day { get; set; }
    }
}
