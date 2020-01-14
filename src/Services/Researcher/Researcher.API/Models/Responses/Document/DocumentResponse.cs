using System;

namespace Researcher.API.Models.Responses.Document
{
    public class DocumentResponse
    {
        public int id { get; set; }
        public string filename { get; set; }
        public string descr { get; set; }
        public int? size { get; set; }
        public int? study_id { get; set; }
        public int? inst_id { get; set; }
        public int? uploaded_by { get; set; }
        public string location { get; set; }
        public DateTime? upload_date { get; set; }
        public int? ctu_status_id { get; set; }
        public DateTime? ctu_appr_date { get; set; }
        public int? ctu_appr_by { get; set; }
        public int? site_status_id { get; set; }
        public DateTime? site_appr_date { get; set; }
        public int? site_appr_by { get; set; }
        public int? sponsor_status_id { get; set; }
        public int? sponsor_appr_by { get; set; }
        public DateTime? sponsor_appr_date { get; set; }
        public sbyte? active { get; set; }
        public int? dist_type_id { get; set; }
        public int? dist_num_times { get; set; }
        public int? parent_id { get; set; }
        public string spare01 { get; set; }
        public string spare02 { get; set; }
        public string spare03 { get; set; }
        public string spare01lbl { get; set; }
        public string spare02lbl { get; set; }
        public string spare03lbl { get; set; }
        public string uri { get; set; }
    }
}