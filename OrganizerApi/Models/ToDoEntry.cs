using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Models
{
    public class ToDoEntry
    {
        public string Text { get; set; }
        public ToDoEntry(string text)
        {
            Text = text;
        }
        public ToDoEntry()
        {

        }
    }
}
