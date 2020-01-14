using System.ComponentModel.DataAnnotations;

namespace Researcher.API.Models.Requests.Document
{
    public class DocumentCreateRequest
    {
        [Required]
        public string filename { get; set; }

        [Required]
        public int study_id { get; set; }

        [Required]
        public int inst_id { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public int ctu_status_id { get; set; }

        [Required]
        public int site_status_id { get; set; }

        [Required]
        public int sponsor_status_id { get; set; }

        [Required]
        public int dist_type_id { get; set; }

        [Required]
        public string uri { get; set; }
    }
}