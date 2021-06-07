using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Getaways")]
    public class Getaways : EntityBase<Guid>
    {
        [Required]
        [MinLength(1), MaxLength(10)]
        public string GatewayId { get; set; }
    }
}
