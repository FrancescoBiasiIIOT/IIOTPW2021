using ITS.PWIIOT.SmartClassrooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.ApplicationCore.Extensions
{
    public static class DeviceMessageExtensions
    {
        public static  IEnumerable<DeviceMessage> ToDeviceMessage(this IEnumerable<Lesson> lesson, int microcontrollerId, MessageOperation messageOperation)
        {
            return lesson.Select(l => l.ToDeviceMessage(microcontrollerId, messageOperation));

        }
        public static DeviceMessage ToDeviceMessage(this Lesson lesson, int microcontrollerId, MessageOperation messageOperation)
        {
            return new DeviceMessage
            {
                Duration = lesson.GetDuration(),
                MicrocontrollerId = microcontrollerId,
                Operation = messageOperation,
                Subject = lesson.Subject.Name,
                Teacher = lesson.Teacher.GetFullName()
            };
        }
    }
}
