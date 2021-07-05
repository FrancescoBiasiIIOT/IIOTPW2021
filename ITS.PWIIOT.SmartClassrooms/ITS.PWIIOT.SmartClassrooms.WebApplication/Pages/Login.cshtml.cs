using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILoginService _loginService;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public UserInfo User { get; set; }

        public LoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var user = await _loginService.GetUser(User);
                if(user.IsCorrect)
                {
                    HttpContext.Session.SetInt32("role", (int)user.Role);
       
                    switch (user.Role)
                    {
                        case Roles.Administrator:
                        return RedirectToPage("/Classrooms/Overview");

                        case Roles.Teacher:
                            HttpContext.Session.SetString("id",user.TeacherId.ToString());
                            return RedirectToPage("/Teachers/Calendar", new { teacherId = user.TeacherId.ToString() });

                        case Roles.Studente:
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
