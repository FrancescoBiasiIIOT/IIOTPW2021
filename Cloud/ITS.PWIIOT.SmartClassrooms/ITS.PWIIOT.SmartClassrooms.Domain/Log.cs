using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.Domain
{
    [Table("Logs")]
    public class Log : EntityBase<int>
    {
        public string Message { get; set; }
    }
}
