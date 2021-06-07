using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILessonRepository lessonRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IIotHubService iotHubService;
        private readonly IClassroomRepository  classroomRepository;
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Lesson> Lessons { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public Lesson Lesson { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Classrooms> Classrooms { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ILessonRepository lessonRepository, ITeacherRepository teacherRepository, IClassroomRepository classroomRepository, IIotHubService iotHubService)
        {
            _logger = logger;
            this.lessonRepository = lessonRepository;
            this.teacherRepository = teacherRepository;
            Lessons = new List<Lesson>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
            Classrooms = new List<Classrooms>();
            Lesson = new();
            this.classroomRepository = classroomRepository;
            this.iotHubService = iotHubService;
        }

        public async Task OnGet()
        {
            Lesson = new();
            Lessons = lessonRepository.GetLessons(new DateTime(2021,05,05), new DateTime(2021,12,30));
            Teachers = await teacherRepository.GetTeachers();
            Subjects = await teacherRepository.GetSubjects();
            Classrooms = await classroomRepository.GetClassrooms();
        }
        public async Task<IActionResult> OnPost()
        {
            var classroom = await classroomRepository.GetClassroomById(Lesson.ClassroomId); 
            var teacher = await teacherRepository.GetTeacherById(Lesson.TeacherId);
            var subject = await teacherRepository.GetSubjectById(Lesson.SubjectId);
            Lesson.Subject = subject;
            Lesson.Teacher = teacher;
            Lesson.Classroom = classroom;
            lessonRepository.InsertLesson(Lesson);
            iotHubService.SendMessageToDevice(JsonSerializer.Serialize(Lesson),"RB100");
            return Page();
        }
    }
}
