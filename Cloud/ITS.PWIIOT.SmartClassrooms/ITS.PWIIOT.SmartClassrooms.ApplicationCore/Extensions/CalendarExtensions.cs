﻿using ITS.PWIIOT.SmartClassrooms.Domain;
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
        public static IEnumerable<CalendarResource> ToCalendarResources(this IEnumerable<Building> buildings)
        {
            return buildings.Select(b => b.ToCalendarResource()).OrderBy(b => b.Title);
        }
        public static IEnumerable<CalendarChildResource> ToCalendarResources(this IEnumerable<Classroom> buildings)
        {
            return buildings.OrderBy(c => c.Name).Select(b => b.ToCalendarResource());
        }

        public static CalendarEvent ToCalendarEvent(this Lesson lesson)
        {
            return new CalendarEvent
            {
                Id = lesson.Id.ToString(),
                Start = lesson.StartDate,
                ResourceId = lesson.Classroom.Id.ToString(),
                End = lesson.EndDate,
                AllDay = false,
                Title =
                $"{lesson.Teacher.GetFullName()}, " +
                $"{lesson.Classroom.GetClassroomId()}, " +
                $"{lesson.Subject.Name}, " +
                $"{lesson.Course.Name} ",

            };
        }
        private static CalendarResource ToCalendarResource(this Building building)
        {
            return new CalendarResource
            {
                Id = building.Id.ToString(),
                Title = ("EDIFICIO " + building.Name).Trim(),
                Children = building.Classrooms.ToCalendarResources()

            };
        }
        private static CalendarChildResource ToCalendarResource(this Classroom classroom)
        {
            return new CalendarChildResource
            {
                Id = classroom.Id.ToString(),
                Title = (classroom.GetClassroomId()).Trim(),
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
