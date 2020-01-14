using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblEmailGrpMembers
    {
        public int GrpId { get; set; }
        public int MemberId { get; set; }
        public int MemberType { get; set; }
    }
}
