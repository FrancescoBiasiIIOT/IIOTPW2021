using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Classrooms
{
    public class OverviewModel : PageModel
    {
        [BindProperty]
        public LessonInfo Lesson { get; set; }
        private readonly IClassroomService _classroomService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;

        public OverviewModel(IClassroomService classroomService, ISubjectService subjectService, ITeacherService teacherService, ILessonService lessonService, ICourseService courseService)
        {
            _classroomService = classroomService;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _lessonService = lessonService;
            _courseService = courseService;
        }

        public IEnumerable<ClassroomInfo> Classrooms{ get; set; }
        public IEnumerable<TeacherInfo> Teachers{ get; set; }
        public IEnumerable<SubjectInfo> Subjects{ get; set; }
        public IEnumerable<CourseInfo> Courses{ get; set; }
        public async Task OnGet()
        {
            Classrooms = await _classroomService.GetClassrooms();
            Teachers = await _teacherService.GetTeachers();
            Subjects = await _subjectService.GetSubjects();
            Courses = await _courseService.GetCourses();
        }

        public async Task<IActionResult> OnPost()
        {
            Lesson.StartDate = DateTime.Now;
            Lesson.EndDate = Lesson.StartDate.AddMinutes((double)Lesson.Duration);
            await _lessonService.AddNewLesson(Lesson);
            return RedirectToPage();

        }
    }
}
