using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.API.Model.Requests.Researcher
{
    public class ResearcherCreateRequest
    {
        public int title_id { get; set; }

        [Required]
        public string given_name { get; set; }

        public string middle_name { get; set; }

        [Required]
        public string family_name { get; set; }

        public string preferred_name { get; set; }
        public string previous_name { get; set; }
        public string tel_no { get; set; }
        public int main_job_title_id { get; set; }
        public int secondary_job_title_id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int cv_received_id { get; set; }

        public DateTime? cv_date { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int gcp_received_id { get; set; }

        public DateTime? gcp_date { get; set; }

        public string email { get; set; }
        public string secretary_name { get; set; }
        public string secretary_tel { get; set; }
        public string secretary_email { get; set; }
        public string notes { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string pwd { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int priv_id { get; set; }

        public DateTime? gcp_start_date { get; set; }
    }
}