using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Microcontroller_services
{
    public class MicrocontrollerService : IMicrocontrollerService
    {
        private readonly IMicrocontrollerRepository _microcontrollerRepository;

        public MicrocontrollerService(IMicrocontrollerRepository microcontrollerRepository)
        {
            _microcontrollerRepository = microcontrollerRepository;
        }

        public MicrocontrollerInfo GetMicrocontrollerById(int picId)
        {
            var microcontrller = _microcontrollerRepository.GetDeviceById(picId);
            return microcontrller.ToMicrocontrollerInfo();
        }

        public async Task<MicrocontrollerInfo> GetMicrocontrollerInfo(string classroomId)
        {
            var microcontroller = await _microcontrollerRepository.GetDeviceByClassroomId(classroomId);
            return MicrocontrollerExtensions.ToMicrocontrollerInfo(microcontroller);
        }
    }
}
