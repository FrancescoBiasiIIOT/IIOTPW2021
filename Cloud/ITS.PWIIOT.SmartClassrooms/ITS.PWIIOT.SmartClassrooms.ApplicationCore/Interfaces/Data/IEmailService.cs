
using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data
{

    public interface IEmailService
    {
        bool SendEmail(EmailMessage message);
    }
}
