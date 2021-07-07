using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    public class MessageFromDevice
    {
        public OperationMessage Operation { get; set; }
        public int Data { get; set; }

    }

    public enum OperationMessage
    {
        AdministratorRequest = 0,
    }
}
