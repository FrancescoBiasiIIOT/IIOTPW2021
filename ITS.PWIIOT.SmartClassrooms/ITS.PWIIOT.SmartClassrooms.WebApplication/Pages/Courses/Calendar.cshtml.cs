using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages.Course
{
    public class CalendarModel : PageModel
    {
        private readonly ICourseService courseService;

        public CalendarModel(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public CourseInfo Course { get; set; }
        public async Task  OnGet(string courseId)
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("id"))){
                RedirectToPage("Login");
            }

            Course = await courseService.GetCourseById(new Guid(courseId));

        }
    }
}
