using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.DTO
{
    public class CalendarEvent
    {
        public string TeacherName { get; set; }
        public string ClassRoomId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CalendarEvent()
        {

        }
    }
}
