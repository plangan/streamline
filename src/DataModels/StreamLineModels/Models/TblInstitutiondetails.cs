using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblInstitutiondetails
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string Url { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int? CtryId { get; set; }
        public string Postcode { get; set; }
        public string AdrNotes { get; set; }
        public string TelNo { get; set; }
        public int? ActivityStatusId { get; set; }
        public string Notes { get; set; }
        public sbyte? Active { get; set; }
        public string InstRef { get; set; }
        public string Email { get; set; }
        public sbyte? RecieveEmail { get; set; }
        public sbyte? SendEmail { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
        public int? GcpPeriod { get; set; }
    }
}
