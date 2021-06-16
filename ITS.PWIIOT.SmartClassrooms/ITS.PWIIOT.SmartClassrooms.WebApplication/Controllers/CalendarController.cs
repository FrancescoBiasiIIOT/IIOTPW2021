using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
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
        private readonly IClassroomService _classroomService;

        public CalendarController(ILessonRepository lessonRepository, IClassroomService classroomService)
        {
            _lessonRepository = lessonRepository;
            _classroomService = classroomService;
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
            var events = lessons.ToCalendarEvents();
            return Ok(events);
        }
        [Route("classrooms")]
        [HttpGet]
        public async Task<IActionResult> Get(DateTime start, DateTime end)
        {
            var lessons = await _lessonRepository.GetLessons(start, end);
            var events = lessons.ToCalendarEvents();
            return Ok(events);
        }
        [Route("buildings")]
        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await _classroomService.GetBuildings();
            var events = buildings.ToCalendarResources();
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