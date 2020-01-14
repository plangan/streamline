using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblInstpeople
    {
        public int PersonId { get; set; }
        public int InstId { get; set; }
        public sbyte? Prime { get; set; }
        public string Note { get; set; }
        public int? InstRoleId { get; set; }
        public string Spare01 { get; set; }
        public string Spare02 { get; set; }
        public string Spare03 { get; set; }
        public string Spare01lbl { get; set; }
        public string Spare02lbl { get; set; }
        public string Spare03lbl { get; set; }
    }
}
