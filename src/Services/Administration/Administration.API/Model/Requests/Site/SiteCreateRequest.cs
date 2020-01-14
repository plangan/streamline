using System.ComponentModel.DataAnnotations;

namespace Administration.API.Model.Requests.Site
{
    public class SiteCreateRequest
    {
        [Required]
        public string institution { get; set; }

        public string url { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ctry_id { get; set; }

        public string postcode { get; set; }
        public string tel_no { get; set; }
        public string email { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int activity_status_id { get; set; }

        public string notes { get; set; }
        public string inst_ref { get; set; }
        public string spare01 { get; set; }
        public string spare02 { get; set; }
        public string spare03 { get; set; }
        public string spare01Lbl { get; set; }
        public string spare02Lbl { get; set; }
        public string spare03Lbl { get; set; }
        public int gcp_period { get; set; }
    }
}