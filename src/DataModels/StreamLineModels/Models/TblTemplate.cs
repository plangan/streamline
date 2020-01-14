using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblTemplate
    {
        public int Id { get; set; }
        public string Nam { get; set; }
        public int StudyId { get; set; }
        public DateTime? Datim { get; set; }
        public sbyte? Active { get; set; }
    }
}
