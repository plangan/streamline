using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblEmailText
    {
        public int Id { get; set; }
        public string Txt { get; set; }
        public int? Typ { get; set; }
        public int? NumTimes { get; set; }
    }
}
