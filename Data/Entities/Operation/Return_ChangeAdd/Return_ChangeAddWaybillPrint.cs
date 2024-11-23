using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.IdentityEntities;

namespace Data.Entities.Operation.Return_ChangeAdd
{
    public class Return_ChangeAddWaybillPrint
    {
        [Key]
        public string Id { get; set; }
        public DateTime PrintingScanTime { get; set; }
        public Return_ChangeAdd_App Return_ChangeAdd_App { get; set; }
        [ForeignKey("Return_ChangeAdd_App")]
        public string Return_ChangeAdd_AppId { get; set; }
        public string PrinterId { get; set; }
        public int NumberOfPrinted { get; set; }
    }
}
