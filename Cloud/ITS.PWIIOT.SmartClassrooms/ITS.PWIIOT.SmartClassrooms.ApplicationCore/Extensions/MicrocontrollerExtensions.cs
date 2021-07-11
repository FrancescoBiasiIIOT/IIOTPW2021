using ITS.PWIIOT.SmartClassrooms.Domain;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class MicrocontrollerExtensions
    {
        public static MicrocontrollerInfo ToMicrocontrollerInfo(this Microcontroller microcontroller)
        {
            return new MicrocontrollerInfo
            {

            };
        }

    }
}
