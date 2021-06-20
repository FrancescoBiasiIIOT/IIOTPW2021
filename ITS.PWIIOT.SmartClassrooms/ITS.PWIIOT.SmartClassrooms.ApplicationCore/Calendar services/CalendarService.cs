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

        public async Task<IEnumerable<CalendarEvent>> GetEvent(DateTime start, DateTime? end)
        {
            var lessons = await _lessonRepository.GetLessons(start, (DateTime)end);
            var events = lessons.ToCalendarEvents();
            return events;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventByClassroom(DateTime start, DateTime? end, string classRoomId)
        {
            //AGGIUNGERE LOGICA DI MODIFICA
            var lessons = await _lessonRepository.GetLessonsByClassroom(start, end, classRoomId);
            var events = lessons.ToCalendarEvents();
            return events;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventByCourse(DateTime start, DateTime? end, Guid courseId)
        {
            var lessons = await _lessonRepository.GetLessonsByCourse(start, end, courseId);
            var events = CalendarExtensions.ToCalendarEvents(lessons);
            return events;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventByTeacher(DateTime start, DateTime? end, Guid teacherId)
        {
            var lessons = await _lessonRepository.GetLessonsByTeacher(start, end, teacherId);
            var events = CalendarExtensions.ToCalendarEvents(lessons);
            return events;
        }
    }
}
