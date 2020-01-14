using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblTrash
    {
        public int Id { get; set; }
        public int DocId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeletedBy { get; set; }
        public int? StudyId { get; set; }
        public int? InstId { get; set; }
    }
}
