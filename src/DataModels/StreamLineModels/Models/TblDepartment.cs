using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblDepartment
    {
        public int InstId { get; set; }
        public int DeptId { get; set; }
        public string TelNo { get; set; }
        public string Nam { get; set; }
        public sbyte? Active { get; set; }
    }
}
