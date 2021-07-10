using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Log_services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Insert(string logMessage)
        {
            _logRepository.Insert(new Domain.Log { Message = logMessage });
        }
    }
}
