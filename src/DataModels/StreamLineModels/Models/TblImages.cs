using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblImages
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int? ImageSize { get; set; }
        public string WebPath { get; set; }
        public string SystemPath { get; set; }
    }
}
