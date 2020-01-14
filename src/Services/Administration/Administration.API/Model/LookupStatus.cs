namespace Administration.API.Model
{
    public class MainJobTitleDD
    {
        public int main_job_title_id { get; set; }
        public string job_title { get; set; }
    }

    public class SecondaryJobTitleDD
    {
        public int secondary_job_title_id { get; set; }
        public string job_title { get; set; }
    }

    public class PrivilegeDD
    {
        public int priv_id { get; set; }
        public string descr { get; set; }
    }

    public class CVReceivedDD
    {
        public int cv_received_id { get; set; }
        public string receivedname { get; set; }
    }

    public class GCPReceivedDD
    {
        public int gcp_received_id { get; set; }
        public string receivedname { get; set; }
    }

    public class PersonTitleDD
    {
        public int title_id { get; set; }
        public string title { get; set; }
    }

    public class StudyInstDD
    {
        public int inst_id { get; set; }
        public string institution { get; set; }
    }

    public class InstRoleDD
    {
        public int inst_role_id { get; set; }
        public string rolename { get; set; }
    }

    public class StudyRoleDD
    {
        public int study_role_id { get; set; }
        public string role { get; set; }
    }

    public class StudyDD
    {
        public int study_id { get; set; }
        public string studyname { get; set; }
    }

    public class InstDD
    {
        public int inst_id { get; set; }
        public string site { get; set; }
    }

    public class CtryDD
    {
        public int ctry_id { get; set; }
        public string ctry { get; set; }
    }

    public class InstActivityDD
    {
        public int activity_status_id { get; set; }
        public string activity { get; set; }
    }

    public class CTUReviewDD
    {
        public int ctu_status_id { get; set; }
        public string descr { get; set; }
    }

    public class SiteReviewDD
    {
        public int site_status_id { get; set; }
        public string descr { get; set; }
    }

    public class ActiveDD
    {
        public int active_id { get; set; }
        public string active { get; set; }
    }

    public class ResearcherDD
    {
        public int person_id { get; set; }
        public string fullname { get; set; }
    }

    public class StudyStatus
    {
        public int study_status_id { get; set; }
        public string status { get; set; }
    }

    public class ResponseStatus
    {
        public int response_status_id { get; set; }
        public string status { get; set; }
    }
}