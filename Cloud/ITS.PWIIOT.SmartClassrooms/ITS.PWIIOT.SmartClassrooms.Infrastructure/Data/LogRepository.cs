using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Infrastructure.Data
{
    public class LogRepository : ILogRepository
    {
        private readonly SmartClassesContext _smartClassesContext;

        public LogRepository(SmartClassesContext smartClassesContext)
        {
            _smartClassesContext = smartClassesContext;
        }

        public void Insert(Log log)
        {
            _smartClassesContext.Add(log);
            _smartClassesContext.SaveChanges();
        }
    }
}
