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
        private readonly ICalendarService _calendarService;
        private readonly ILessonService lessonService;
        private readonly IClassroomService _classroomService;

        public CalendarController(IClassroomService classroomService, ICalendarService calendarService, ILessonService lessonService)
        {
            _classroomService = classroomService;
            _calendarService = calendarService;
            this.lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByClassroom(DateTime start, DateTime? end, string classroomId)
        {
            var events = await _calendarService.GetEventByClassroom(start, end, classroomId);
            return Ok(events);
        }
        [Route("course")]
        [HttpGet]
        public async Task<IActionResult> GetByCourse(DateTime start, DateTime? end, string courseId)
        {
            var events = await _calendarService.GetEventByCourse(start, end, new Guid(courseId));
            return Ok(events);
        }
        [Route("classrooms")]
        [HttpGet]
        public async Task<IActionResult> Get(DateTime start, DateTime? end)
        {
            var events = await _calendarService.GetEvent(start, end);
            return Ok(events);
        }

        [Route("teachers")]
        [HttpGet]
        public async Task<IActionResult> GetByTeacher(DateTime start, DateTime? end, string teacherId)
        {
            var events = await _calendarService.GetEvent(start, end);
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
            await lessonService.DeleteLesson(new Guid(lessonId));
            return Ok();
        }

    }
}