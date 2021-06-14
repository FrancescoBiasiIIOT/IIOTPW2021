using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Shared.Admin
{
    public class EventsModel : PageModel
    {

        private readonly ILessonRepository lessonRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IClassroomRepository classroomRepository;
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public Lesson Lesson { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }

        public EventsModel(ILogger<IndexModel> logger, ILessonRepository lessonRepository, ITeacherRepository teacherRepository, IClassroomRepository classroomRepository)
        {
            _logger = logger;
            this.lessonRepository = lessonRepository;
            this.teacherRepository = teacherRepository;
            Lessons = new List<Lesson>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
            Classrooms = new List<Classroom>();
            Lesson = new();
            this.classroomRepository = classroomRepository;
        }

        public async Task OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            return Page();
        }
    }
}
