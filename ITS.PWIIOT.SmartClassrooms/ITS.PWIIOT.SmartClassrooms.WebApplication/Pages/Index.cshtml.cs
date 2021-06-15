using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.Infrastructure.Data;
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
        public IEnumerable<Domain.Classroom> Classrooms { get; set; }
        private readonly IClassroomRepository classroomRepository;
        public IEnumerable<Domain.Course> Courses { get; set; }
        private readonly ICourseRepository _courseRepository;
        public IndexModel(ILogger<IndexModel> logger, IClassroomRepository classroomRepository, ICourseRepository courseRepository)
        {
            this.classroomRepository = classroomRepository;
            _courseRepository = courseRepository;
        }

        public async Task OnGet()
        {
            Courses = await _courseRepository.GetCourses();
            Classrooms = await classroomRepository.GetClassrooms();
        }
    }
}
