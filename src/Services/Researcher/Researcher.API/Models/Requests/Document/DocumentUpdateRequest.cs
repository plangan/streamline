using System.ComponentModel.DataAnnotations;

namespace Researcher.API.Models.Requests.Document
{
    public class DocumentUpdateRequest
    {
        public string descr { get; set; }

        [Required]
        public int site_status_id { get; set; }
    }
}