using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_Other_query_improvements.Models
{
    // Entity Definition
    public class Event
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateOnly EventDate { get; set; }
        public TimeOnly EventTime { get; set; }
        public ICollection<Attendees> Attendees { get; set; }
    }
}
