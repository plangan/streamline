using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblTrialdetails
    {
        public int Id { get; set; }
        public string Shortname { get; set; }
        public string Isrctn { get; set; }
        public string RecRef { get; set; }
        public string MhraRef { get; set; }
        public string Sponsor { get; set; }
        public string Funder { get; set; }
        public int? TrialactivitystatusId { get; set; }
        public string Notes { get; set; }
        public string TrialRef { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
        public int? GcpAlertPeriod { get; set; }
        public int? LogoId { get; set; }
        public string Descr { get; set; }
    }
}
