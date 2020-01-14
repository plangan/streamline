using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblCtry
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public sbyte? Active { get; set; }
    }
}
