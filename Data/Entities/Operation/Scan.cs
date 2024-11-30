using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation
{
    public class Scan:BaseEntity
    {
        [Key]
        public int ScanCode { get; set; }
        public string ScanTypeName { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }=StatusEnum.Active;
        public  ICollection<Order_Scan> Order_Scans { get; set; } = new List<Order_Scan>();

    }
}
