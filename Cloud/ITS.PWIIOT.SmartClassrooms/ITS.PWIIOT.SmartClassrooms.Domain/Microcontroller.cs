﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Microcontrollers")]
    public class Microcontroller : EntityBase<Guid>
    {
        [Required]
        [MinLength(1), MaxLength(10)]
        public int DeviceId { get; set; }
        public Classroom Classroom { get; set; }
        public Guid ClassroomId { get; set; }
        public Gateway Gateway { get; set; }
        public Guid GatewayId { get; set; }
    }
}
