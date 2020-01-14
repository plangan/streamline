using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblSpareDefn
    {
        public string TableName { get; set; }
        public int Seq { get; set; }
        public string Fieldlabel { get; set; }
        public string Fieldtype { get; set; }
        public sbyte? Active { get; set; }
        public string Purpose { get; set; }
    }
}
