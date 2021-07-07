using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Email_services
{
    public class EmailService : IEmailService
    {
        public EmailService(IConfiguration configuration)
        {
            this._configuration = _configuration;
        }

        public IConfiguration _configuration { get; set; }
        public bool SendEmail(EmailMessage activity)
        {
            try
            {
                var message = new MimeMessage();
                var emailSender = "francesco.biasi@stud.tecnicosuperiorekennedy.it";

                var host = "smtp.gmail.com";
                var port = 25;
                var emailReceiver = "biasifrancesco3gmail.com";
                message.From.Add(new MailboxAddress("Francesco", emailSender));
                message.To.Add(new MailboxAddress("Francesco Biasi", emailReceiver));
                message.Subject = "Richiesta";

                message.Body = new TextPart("plain")
                {
                    Text = $"Ciao Antonio, sei richiesto nell'aula: {activity.Classroom} \n Docente: {activity.Teacher}"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect(host, port, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(emailSender, passwordSender);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }

        }
    }
}}
