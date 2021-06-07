using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Buildings")]
    public class Building : EntityBase<Guid>
    {
        [MinLength(1), MaxLength(10)]
        public string BuildingName { get; set; }
        [MinLength(5), MaxLength(150)]
        public string Description { get; set; }
    }
}
