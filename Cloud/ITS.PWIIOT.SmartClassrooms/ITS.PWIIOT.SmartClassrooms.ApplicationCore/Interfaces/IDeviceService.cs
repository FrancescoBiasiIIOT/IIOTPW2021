﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces
{
    public interface IDeviceService
    {
        Task<string> ReceiveMessageFromHub(string deviceId);
    }
}
