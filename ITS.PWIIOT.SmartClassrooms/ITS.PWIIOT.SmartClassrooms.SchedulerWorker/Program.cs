using Hangfire;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.IOT_Hub_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Lesson_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Microcontroller_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Subject_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Teacher_services;
using ITS.PWIIOT.SmartClassrooms.Infrastructure;
using ITS.PWIIOT.SmartClassrooms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.SchedulerWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext<SmartClassesContext>(options => options.UseSqlServer("Data Source=DESKTOP-LP5FFTL;Initial Catalog=SMARTCLASSROOMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
                    services.AddScoped<ISubjectService, SubjectService>();
                    services.AddScoped<IClassroomRepository, ClassroomRepository>();
                    services.AddScoped<ICourseRepository, CourseRepository>();
                    services.AddScoped<ITeacherRepository, TeacherRepository>();
                    services.AddScoped<ITeacherService, TeacherService>();
                    services.AddScoped<ISubjectRepository, SubjectRepository>();
                    services.AddScoped<ILessonService, LessonService>();
                    services.AddScoped<ILessonRepository, LessonRepository>();
                    services.AddScoped<IMicrocontrollerService, MicrocontrollerService>();
                    services.AddScoped<IMicrocontrollerRepository, MicrocontrollerRepository>();
                    services.AddScoped<IIotHubService, IotHubService>();
          
                   
                });
    }
}
