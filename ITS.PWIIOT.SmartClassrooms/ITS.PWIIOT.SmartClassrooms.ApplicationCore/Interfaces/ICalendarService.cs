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
        Task<IEnumerable<CalendarEvent>> GetEventByClassroom(DateTime start, DateTime? end, string classRoomId);
        Task<IEnumerable<CalendarEvent>> GetEventByTeacher(DateTime start, DateTime? end, Guid teacherId);
        Task<IEnumerable<CalendarEvent>> GetEventByCourse(DateTime start, DateTime? end, Guid courseId);
        Task<IEnumerable<CalendarEvent>> GetEvent(DateTime start, DateTime? end);
        Task AddEvent(CalendarEvent newCalendarEvent);
    }
}
