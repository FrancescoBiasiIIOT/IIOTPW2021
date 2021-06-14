using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Calendar_services
{
    public class CalendarService : ICalendarService
    {
        private readonly ILessonRepository _lessonRepository;

        public CalendarService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task AddEvent(CalendarEvent newCalendarEvent)
        {
            var lesson = CalendarExtensions.ToLesson(newCalendarEvent);
            await _lessonRepository.InsertLesson(lesson);
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventBy(DateTime start, DateTime? end, string classRoomId)
        {
            //AGGIUNGERE LOGICA DI MODIFICA
            var lessons = await _lessonRepository.GetLessonsByClassroom(start, end, classRoomId);
            var events = CalendarExtensions.ToCalendarEvents(lessons);
            return events;
        }
    }
}
