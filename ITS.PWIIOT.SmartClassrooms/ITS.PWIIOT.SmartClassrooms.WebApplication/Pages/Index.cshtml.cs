using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using ITS.PWIIOT.SmartClassrooms.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
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
        private readonly ILoginService _loginService;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public UserInfo User { get; set; }

        public IndexModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.GetUser(User);
                if (user.IsCorrect)
                {
                    HttpContext.Session.SetInt32("role", (int)user.Role);

                    switch (user.Role)
                    {
                        case DTO.Roles.Administrator:
                            return RedirectToPage("/Classrooms/Overview");

                        case DTO.Roles.Teacher:
                            HttpContext.Session.SetString("id", user.TeacherId.ToString());
                            return RedirectToPage("/Teachers/Calendar", new { teacherId = user.TeacherId.ToString() });

                        case DTO.Roles.Studente:
                            HttpContext.Session.SetString("id", user.CourseId.ToString());
                            return RedirectToPage("Courses/Calendar", new { courseId = user.CourseId.ToString() });
                    }

                    return RedirectToPage("/Index");
                }
                else
                {
                    Message = "Login Errato";
                }
            }

            ModelState.Clear();
            return RedirectToPage();
        }
    }
}
