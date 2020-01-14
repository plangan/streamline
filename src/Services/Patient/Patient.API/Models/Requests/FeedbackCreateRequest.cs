using System.ComponentModel.DataAnnotations;

namespace Patient.API.Models.Requests
{
    public class FeedbackCreateRequest
    {
        [Required]
        public string ecrf_no { get; set; }

        [Required]
        public int seq { get; set; }

        [Required]
        public bool negative_comments { get; set; }

        [Required]
        public bool send_to_nurse { get; set; }

        [Required]
        public string feedback { get; set; }

        [Required]
        public int study_id { get; set; }

        [Required]
        public int inst_id { get; set; }
    }
}