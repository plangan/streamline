using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblDocuments
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Descr { get; set; }
        public int? Size { get; set; }
        public int? StudyId { get; set; }
        public int? InstId { get; set; }
        public int? UploadedBy { get; set; }
        public string Location { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? CtuStatusId { get; set; }
        public DateTime? CtuApprDate { get; set; }
        public int? CtuApprBy { get; set; }
        public int? SiteStatusId { get; set; }
        public DateTime? SiteApprDate { get; set; }
        public int? SiteApprBy { get; set; }
        public int? SponsorStatusId { get; set; }
        public int? SponsorApprBy { get; set; }
        public DateTime? SponsorApprDate { get; set; }
        public sbyte? Active { get; set; }
        public int? DistTypeId { get; set; }
        public int? DistNumTimes { get; set; }
        public int? ParentId { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
        public string Uri { get; set; }
    }
}
