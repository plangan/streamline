using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblFilters
    {
        public int UserId { get; set; }
        public string PageId { get; set; }
        public string Fieldname { get; set; }
        public string Fieldvalue { get; set; }
        public string Fieldtype { get; set; }
    }
}
