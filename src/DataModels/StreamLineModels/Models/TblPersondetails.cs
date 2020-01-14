using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblPersondetails
    {
        public int Id { get; set; }
        public int? TitleId { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string PreferredName { get; set; }
        public string PreviousName { get; set; }
        public string TelNo { get; set; }
        public int? MainJobTitleId { get; set; }
        public int? SecondaryJobTitleId { get; set; }
        public int? CvReceivedId { get; set; }
        public DateTime? ShortCvDate { get; set; }
        public int? GcpReceivedId { get; set; }
        public DateTime? GcpDate { get; set; }
        public string Email { get; set; }
        public string SecretaryName { get; set; }
        public string SecretaryTel { get; set; }
        public string SecretaryEmail { get; set; }
        public string Notes { get; set; }
        public string Username { get; set; }
        public string Pwd { get; set; }
        public sbyte? Active { get; set; }
        public int? NumTimes { get; set; }
        public int? PrivId { get; set; }
        public sbyte? RecieveEmail { get; set; }
        public sbyte? SendEmail { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
        public DateTime? GcpStartDate { get; set; }
    }
}
