using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.DTO
{
    public class CalendarResource
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<CalendarChildResource> Children { get; set; }
    }

    public class CalendarChildResource
    {
        public string Id { get; set; }
        public string Title { get; set; }

    }
}
