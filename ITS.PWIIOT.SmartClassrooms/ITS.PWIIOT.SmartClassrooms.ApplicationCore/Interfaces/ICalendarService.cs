using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces
{
    public interface ICalendarService
    {
        Task<IEnumerable<CalendarEvent>> GetEventBy(DateTime start, DateTime? end, string classRoomId);
        Task<IEnumerable<CalendarEvent>> GetEventByCourse(DateTime start, DateTime? end, Guid courseId);
        Task AddEvent(CalendarEvent newCalendarEvent);
    }
}
