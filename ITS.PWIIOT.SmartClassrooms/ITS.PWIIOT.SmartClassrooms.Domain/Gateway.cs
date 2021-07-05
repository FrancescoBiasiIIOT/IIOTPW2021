using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Gateways")] 
    public class Gateway : EntityBase<Guid>
    {
        public string GatewayId { get; set; }
        public Building Building { get; set; }
        public Guid BuildingId { get; set; }
        public FloorState Floor { get; set; }
    }
}
