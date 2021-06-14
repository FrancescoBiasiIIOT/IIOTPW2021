using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class CalendarExtensions
    {
        public static IEnumerable<CalendarEvent> ToCalendarEvents(this IEnumerable<Lesson> lessons)
        {
            return lessons.Select(l => l.ToCalendarEvent());
        }

        private static CalendarEvent ToCalendarEvent(this Lesson lesson)
        {
            return new CalendarEvent
            {

            };
        }

        public static Lesson ToLesson(this CalendarEvent calendarEvent)
        {
            return new Lesson
            {

            };
        }
    }
}
