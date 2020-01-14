using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblStudyinst
    {
        public int StudyId { get; set; }
        public int InstId { get; set; }
        public int ResponseStatusId { get; set; }
        public int? StudyStatusId { get; set; }
        public DateTime? DateApproached { get; set; }
        public DateTime? DateRegReturned { get; set; }
        public DateTime? DateSiv { get; set; }
        public DateTime? FirstAccrualDate { get; set; }
        public DateTime? FirstMonVisitDate { get; set; }
        public DateTime? CloseoutVisitDate { get; set; }
        public DateTime? SiteClosedDate { get; set; }
        public string Note { get; set; }
        public sbyte? Active { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
    }
}
