using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Administration.API.Model
{
    public class AddToStudy
    {
        public int id { get; set; }
        public int title_id { get; set; }
        public string title { get; set; }

        [Required]
        public string given_name { get; set; }

        public string middle_name { get; set; }

        [Required]
        public string family_name { get; set; }

        public string preferred_name { get; set; }
        public string previous_name { get; set; }
        public string tel_no { get; set; }
        public int main_job_title_id { get; set; }
        public string main_job_title { get; set; }
        public int secondary_job_title_id { get; set; }
        public string secondary_job_title { get; set; }

        [Required(ErrorMessage = "CV Status required")]
        [Range(1, int.MaxValue, ErrorMessage = "CV Status required")]
        public int cv_received_id { get; set; }

        public string cv_received { get; set; }
        public DateTime? cv_date { get; set; }
        public string email { get; set; }
        public string secretary_name { get; set; }
        public string secretary_tel { get; set; }
        public string secretary_email { get; set; }
        public string notes { get; set; }

        [Required]
        [Remote("IsUserExists", "Validator", "Username already taken")]
        public string username { get; set; }

        [Required]
        public string pwd { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int priv_id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int gcp_received_id { get; set; }

        public string gcp_received { get; set; }
        public DateTime? gcp_start_date { get; set; }
        public DateTime? gcp_date { get; set; }
        public bool active { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int study_id { get; set; }

        public string study { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int inst_id { get; set; }

        public string site { get; set; }
        public int inst_role_id { get; set; }
        public string inst_role { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int study_role_id { get; set; }

        public string study_role { get; set; }
    }
}