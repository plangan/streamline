using System;

namespace Researcher.API.Models.Responses.Document
{
    public class DocumentDetailsResponse
    {
        public int id { get; set; }
        public string filename { get; set; }
        public string descr { get; set; }
        public string size { get; set; }
        public int study_id { get; set; }
        public string studyname { get; set; }
        public int inst_id { get; set; }
        public string institution { get; set; }
        public int uploadedById { get; set; }
        public string uploader { get; set; }
        public int ctu_status_id { get; set; }
        public string ctu_status { get; set; }
        public string location { get; set; }
        public string upload_date { get; set; }
        public string central_appr_date { get; set; }
        public int ctuApprById { get; set; }
        public string central_approver { get; set; }
        public int site_status_id { get; set; }
        public string site_status { get; set; }
        public int siteApprById { get; set; }
        public string site_approver { get; set; }
        public string site_appr_date { get; set; }
        public int sponsor_status_id { get; set; }
        public string sponsor_status { get; set; }
        public int sponsorApprById { get; set; }
        public string sponser_approver { get; set; }
        public string sponser_appr_date { get; set; }
        public bool active { get; set; }
        public int dist_type_id { get; set; }
        public string distribution_type { get; set; }
        public int dist_num_times { get; set; }
        public int parent_id { get; set; }
        public string spare01 { get; set; }
        public string spare02 { get; set; }
        public string spare03 { get; set; }
        public string spare01lbl { get; set; }
        public string spare02lbl { get; set; }
        public string spare03lbl { get; set; }
        public string uri { get; set; }
    }
}