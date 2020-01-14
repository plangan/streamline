using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblGrandchild
    {
        public string ParentId { get; set; }
        public string ChildId { get; set; }
        public string Id { get; set; }
        public string Descr { get; set; }
        public sbyte? Active { get; set; }
    }
}
