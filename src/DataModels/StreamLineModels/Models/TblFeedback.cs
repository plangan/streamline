using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblFeedback
    {
        public string EcrfNo { get; set; }
        public int Seq { get; set; }
        public DateTime? Datim { get; set; }
        public sbyte? NegativeComments { get; set; }
        public sbyte? SendToNurse { get; set; }
        public string Feedback { get; set; }
    }
}
