using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblQuestionPool
    {
        public int Id { get; set; }
        public int TypId { get; set; }
        public int? GrpId { get; set; }
        public string Question { get; set; }
        public sbyte? Active { get; set; }
        public DateTime? Datim { get; set; }
    }
}
