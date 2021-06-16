using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;

        public CalendarController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetByClassroom(DateTime start, DateTime? end, string classroomId)
        {
            var lessons = await _lessonRepository.GetLessonsByClassroom(start, end, classroomId);
            var events = CalendarExtensions.ToCalendarEvents(lessons);
            return Ok(events);
        }
        [Route("course")]
        [HttpGet]
        public async Task<IActionResult> GetByCourse(DateTime start, DateTime? end, string courseId)
        {
            var lessons = await _lessonRepository.GetLessonsByCourse(start, end, new Guid(courseId));
            var events = CalendarExtensions.ToCalendarEvents(lessons);
            return Ok(events);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string lessonId)
        {
            await _lessonRepository.DeleteLesson(new Guid(lessonId));
            return Ok();
        }

    }
}