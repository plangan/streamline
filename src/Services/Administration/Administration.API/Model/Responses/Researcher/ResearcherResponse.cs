namespace Administration.API.Model.Responses.Researcher
{
    public class ResearcherResponse
    {
        public int id { get; set; }
        public int title_id { get; set; }

        //public string title { get; set; }
        public string given_name { get; set; }

        public string middle_name { get; set; }
        public string family_name { get; set; }
        public string preferred_name { get; set; }
        public string previous_name { get; set; }
        public string tel_no { get; set; }
        public int main_job_title_id { get; set; }

        //public string main_job_title { get; set; }
        public int secondary_job_title_id { get; set; }

        //public string secondary_job_title { get; set; }
        public int cv_received_id { get; set; }

        //public string cv_received { get; set; }
        public string cv_date { get; set; }

        //public DateTime? cv_date_DT { get; set; }
        public string email { get; set; }

        public string secretary_name { get; set; }
        public string secretary_tel { get; set; }
        public string secretary_email { get; set; }
        public string notes { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public int priv_id { get; set; }
        public int gcp_received_id { get; set; }

        //public string gcp_received { get; set; }
        public string gcp_start_date { get; set; }

        //public DateTime? gcp_start_date_DT { get; set; }
        public string gcp_date { get; set; }

        //public DateTime? gcp_date_DT { get; set; }
        public bool active { get; set; }

        public string spare01 { get; set; }
        public string spare02 { get; set; }
        public string spare03 { get; set; }
        public string spare01lbl { get; set; }
        public string spare02lbl { get; set; }
        public string spare03lbl { get; set; }
    }
}