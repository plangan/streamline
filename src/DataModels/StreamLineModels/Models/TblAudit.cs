using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblAudit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? Typ { get; set; }
        public DateTime? Datim { get; set; }
        public string Action { get; set; }
        public string BeforeData { get; set; }
        public string AfterData { get; set; }
    }
}
