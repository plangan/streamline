using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblParent
    {
        public string Id { get; set; }
        public string Descr { get; set; }
        public string Colour { get; set; }
        public sbyte? Active { get; set; }
    }
}
