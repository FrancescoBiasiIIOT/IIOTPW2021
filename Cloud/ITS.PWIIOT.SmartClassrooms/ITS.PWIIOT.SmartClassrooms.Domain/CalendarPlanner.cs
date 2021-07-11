using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    public class CalendarPlanner
    {
        public MessageOperation Operation { get; set; }

        public IEnumerable<ClassroomCalendar> ClassroomsCalendar { get; set; }

        public CalendarPlanner(MessageOperation operation)
        {
            Operation = operation;
        }
    }

    public class ClassroomCalendar
    {
        public string ClassroomId { get; set; }
        public IEnumerable<DeviceMessage> Lessons { get; set; }
    }

}
