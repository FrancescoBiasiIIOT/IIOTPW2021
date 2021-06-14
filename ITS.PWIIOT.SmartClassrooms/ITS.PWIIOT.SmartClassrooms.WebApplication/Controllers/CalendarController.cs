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
        public async Task<IActionResult> Get(DateTime start, DateTime end)
        {
            var events = new List<CalendarEvent>();
            var lessons = await _lessonRepository.GetLessonsByClassroom(start, end, "S2");
            foreach (var item in lessons)
            {
                events.Add(new CalendarEvent
                {
                    Id = item.Id.ToString(),
                    Title = item.Subject.Name,
                    AllDay = false,
                    Start = item.StartDate,
                    End = item.GetEndDate()
                });
            }

            return Ok(events);
        }

    }
}