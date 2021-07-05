using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Login_services
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository ;

        public LoginService(ILoginRepository loginRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _loginRepository = loginRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        public async Task<UserInfo> GetUser(UserInfo userInfo)
        {
            var user = await _loginRepository.GetUserByCredential(userInfo.Username, userInfo.Password);
            if(user != null)
            {
                switch (user.Role)
                {
                    case Domain.Roles.Teacher:
                        var teacher = await _teacherRepository.GetTeacherByEmaail(user.Email);
                        userInfo.TeacherId = teacher.Id;
                        break;
                    case Domain.Roles.Studente:
                        var student = await _studentRepository.GetStudentByEmail(user.Email);
                        userInfo.CourseId = student.Course.Id;
                        break;
                    default:
                        break;
                }
                userInfo.IsCorrect = true;
                userInfo.Role = (Roles)user.Role;
            }

            return userInfo;
            
            

        }
    }
}
