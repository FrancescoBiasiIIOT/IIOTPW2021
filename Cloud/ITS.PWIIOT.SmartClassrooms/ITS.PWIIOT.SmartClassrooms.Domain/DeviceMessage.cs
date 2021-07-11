using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    public class DeviceMessage
    {
        public int MicrocontrollerId { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public int Duration { get; set; }
        public MessageOperation Operation { get; set; }

        public DeviceMessage()
        {

        }
    }

    public enum MessageOperation
    {
        Add = 0,
        Update = 1,
        Delete = 2,
        Calendar = 3
    }
}
