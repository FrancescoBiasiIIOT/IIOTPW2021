using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Classroom
{
    public class CalendarModel : PageModel
    {
        private readonly IClassroomService _classroomService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;
        public IEnumerable<TeacherInfo> Teachers { get; set; }
        public IEnumerable<SubjectInfo> Subjects { get; set; }
        [BindProperty]
        public LessonInfo Lesson { get; set; }
        public CalendarModel(IClassroomService classroomService, ITeacherService teacherService, ISubjectService subjectService, ILessonService lessonService)
        {
            Lesson = new();
            Classroom = new();
            _classroomService = classroomService;
            _teacherService = teacherService;
            _subjectService = subjectService;
            _lessonService = lessonService;
        }

        public ClassroomInfo Classroom { get; set; }
        public async Task OnGet(string classroomId)
        {
            Lesson = new();
            Classroom = new();
            Teachers = await _teacherService.GetTeachers();
            Subjects = await _subjectService.GetSubjects();
            Classroom = await _classroomService.GetClassroomById(classroomId);
        }
        public async Task<IActionResult> OnPost(string classroomId)
        {
            await _lessonService.AddNewLesson(Lesson);
            return RedirectToPage();  
  
        }
    }
}
