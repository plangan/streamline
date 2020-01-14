using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblFiles
    {
        public int FileId { get; set; }
        public string Filename { get; set; }
        public string Displayname { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }
        public long? Filesize { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
