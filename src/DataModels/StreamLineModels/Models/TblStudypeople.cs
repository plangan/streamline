using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblStudypeople
    {
        public int StudyId { get; set; }
        public int InstId { get; set; }
        public int PersonId { get; set; }
        public sbyte? Main { get; set; }
        public DateTime? InviteDate { get; set; }
        public int? ResponseStatusId { get; set; }
        public DateTime? ResponseDate { get; set; }
        public int? StudyRoleId { get; set; }
        public sbyte? Active { get; set; }
        public string Note { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
    }
}
