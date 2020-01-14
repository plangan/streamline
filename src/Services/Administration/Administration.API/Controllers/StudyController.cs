using Administration.API.Model;
using AutoMapper;
using DataTables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StreamLineModels;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Administration.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public StudyController(IConfiguration configuration, IcecapContext context, IMapper mapper, IHostingEnvironment env)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        [HttpPost]
        [Route("StudyDatatable")]
        public IActionResult Study()
        {
            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                DtResponse response = new Editor(db, "tbl_trialdetails")
                       .Model<StudyModel>()
                       .TryCatch(false)
                       .Field(new Field("tbl_trialdetails.id")
                           .Validator(Validation.Numeric())
                           .SetFormatter(Format.IfEmpty(null))
                       )
                       .Field(new Field("tbl_trialdetails.shortname")
                           .Validator(Validation.NotEmpty())
                           .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.isrctn")
                           .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.rec_ref")
                           .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.mhra_ref")
                           .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.sponsor")
                           .Validator(Validation.MaxLen(100, new ValidationOpts { Message = "Maximum length is 100 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.funder")
                           .Validator(Validation.MaxLen(100, new ValidationOpts { Message = "Maximum length is 100 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.trialactivitystatus_id")
                          .Options(new Options()
                               .Table("tbl_activitystatus")
                               .Value("id")
                               .Label("descr")
                           )
                        )
                       .Field(new Field("tbl_trialdetails.notes"))
                       .Field(new Field("tbl_trialdetails.trial_ref")
                           .Validator(Validation.MaxLen(2, new ValidationOpts { Message = "Maximum length is 2 characters..." }))
                       )
                       .Field(new Field("tbl_trialdetails.gcp_alert_period")
                           .Validator(Validation.Numeric())
                           .SetFormatter(Format.IfEmpty(null))
                        )
                       .Field(new Field("tbl_trialdetails.logo_id")
                           .SetFormatter(Format.IfEmpty(null))
                           .Upload(new Upload(_env.ContentRootPath + @"images\__ID____EXTN__") //request.PhysicalApplicationPath
                               .Db("tbl_images", "id", new Dictionary<string, object>
                               {
                                {"web_path", Upload.DbType.WebPath},
                                {"system_path", Upload.DbType.SystemPath},
                                {"image_name", Upload.DbType.FileName},
                                {"image_size", Upload.DbType.FileSize}
                               })
                               .DbClean(data =>
                               {
                                   foreach (var row in data)
                                   {
                                       // Do something;
                                   }
                                   return true;
                               })
                               .Validator(Validation.FileSize(500000, "Max file size is 500K."))
                               .Validator(Validation.FileExtensions(new[] { "jpg", "png", "gif" }, "Please upload an image."))
                           )
                       )
                       .Field(new Field("tbl_trialdetails.descr"))
                       .LeftJoin("tbl_activitystatus", "tbl_activitystatus.id", "=", "tbl_trialdetails.trialactivitystatus_id")
                       .Validator((editor, type, args) =>
                       {
                           if (type == DtRequest.RequestTypes.EditorCreate)
                           {
                               foreach (var v_oneSet in args.Data)
                               {
                                   StudyModel.tbl_trialdetails v_studyAuditModel = new StudyModel.tbl_trialdetails();
                                   string v_header = v_oneSet.Key;
                                   object v_oneObject = v_oneSet.Value;
                                   Dictionary<string, object> v_afterObject = new Dictionary<string, object>();
                                   try
                                   {
                                       v_afterObject = (Dictionary<string, object>)v_oneObject;
                                       foreach (KeyValuePair<string, object> v_afterValues in v_afterObject)
                                       {
                                           string v_tableName = v_afterValues.Key;
                                           object v_tableValues = v_afterValues.Value;
                                           Dictionary<string, object> v_tableData = new Dictionary<string, object>();
                                           v_tableData = (Dictionary<string, object>)v_tableValues;

                                           if (v_tableData.ContainsKey("shortname")) v_studyAuditModel.shortname = (string)v_tableData["shortname"];
                                           if (v_tableData.ContainsKey("isrctn")) v_studyAuditModel.isrctn = (string)v_tableData["isrctn"];
                                           if (v_tableData.ContainsKey("rec_ref")) v_studyAuditModel.rec_ref = (string)v_tableData["rec_ref"];
                                           if (v_tableData.ContainsKey("mhra_ref")) v_studyAuditModel.mhra_ref = (string)v_tableData["mhra_ref"];
                                           if (v_tableData.ContainsKey("sponsor")) v_studyAuditModel.sponsor = (string)v_tableData["sponsor"];
                                           if (v_tableData.ContainsKey("funder")) v_studyAuditModel.funder = (string)v_tableData["funder"];
                                           if (v_tableData.ContainsKey("trialactivitystatus_id")) v_studyAuditModel.trialactivitystatus_id = Convert.ToInt32(v_tableData["trialactivitystatus_id"]);
                                           if (v_tableData.ContainsKey("notes")) v_studyAuditModel.notes = (string)v_tableData["notes"];
                                           if (v_tableData.ContainsKey("trial_ref")) v_studyAuditModel.trial_ref = (string)v_tableData["trial_ref"];
                                           if (v_tableData.ContainsKey("gcp_alert_period"))
                                           {
                                               v_studyAuditModel.gcp_alert_period = 0;
                                               object v_obj = v_tableData["gcp_alert_period"];
                                               string v_period = v_obj.ToString();
                                               if (!string.IsNullOrEmpty(v_period))
                                               {
                                                   string v_return = ValidateGCPAlertPeriod(v_period);
                                                   if (v_return != null) return v_return;
                                                   v_studyAuditModel.gcp_alert_period = Convert.ToInt32(v_period);
                                               }
                                           }
                                           if (v_tableData.ContainsKey("logo_id")) v_studyAuditModel.logo_id = Convert.ToInt32(v_tableData["logo_id"]);
                                           if (v_tableData.ContainsKey("descr")) v_studyAuditModel.descr = (string)v_tableData["descr"];
                                       }
                                   }
                                   catch (Exception v_ex)
                                   {
                                       string v_msg = v_ex.InnerException.ToString();
                                   }
                               }
                               return null;
                           }

                           if (type == DtRequest.RequestTypes.EditorEdit)
                           {
                               int v_studyID = 0;

                               foreach (var v_oneSet in args.Data)
                               {
                                   StudyModel.tbl_trialdetails v_studyAuditModel = new StudyModel.tbl_trialdetails();
                                   string v_header = v_oneSet.Key;
                                   object v_oneObject = v_oneSet.Value;
                                   Dictionary<string, object> v_afterObject = new Dictionary<string, object>();
                                   try
                                   {
                                       v_afterObject = (Dictionary<string, object>)v_oneObject;
                                       foreach (KeyValuePair<string, object> v_afterValues in v_afterObject)
                                       {
                                           string v_tableName = v_afterValues.Key;
                                           object v_tableValues = v_afterValues.Value;
                                           Dictionary<string, object> v_tableData = new Dictionary<string, object>();
                                           v_tableData = (Dictionary<string, object>)v_tableValues;

                                           v_studyAuditModel.id = Convert.ToInt32(v_header.Substring(4));
                                           v_studyID = v_studyAuditModel.id;

                                           if (v_tableData.ContainsKey("shortname")) v_studyAuditModel.shortname = (string)v_tableData["shortname"];
                                           if (v_tableData.ContainsKey("isrctn")) v_studyAuditModel.isrctn = (string)v_tableData["isrctn"];
                                           if (v_tableData.ContainsKey("rec_ref")) v_studyAuditModel.rec_ref = (string)v_tableData["rec_ref"];
                                           if (v_tableData.ContainsKey("mhra_ref")) v_studyAuditModel.mhra_ref = (string)v_tableData["mhra_ref"];
                                           if (v_tableData.ContainsKey("sponsor")) v_studyAuditModel.sponsor = (string)v_tableData["sponsor"];
                                           if (v_tableData.ContainsKey("funder")) v_studyAuditModel.funder = (string)v_tableData["funder"];
                                           if (v_tableData.ContainsKey("trialactivitystatus_id")) v_studyAuditModel.trialactivitystatus_id = Convert.ToInt32(v_tableData["trialactivitystatus_id"]);
                                           if (v_tableData.ContainsKey("notes")) v_studyAuditModel.notes = (string)v_tableData["notes"];
                                           if (v_tableData.ContainsKey("trial_ref")) v_studyAuditModel.trial_ref = (string)v_tableData["trial_ref"];
                                           if (v_tableData.ContainsKey("gcp_alert_period"))
                                           {
                                               v_studyAuditModel.gcp_alert_period = 0;
                                               object v_obj = v_tableData["gcp_alert_period"];
                                               string v_period = v_obj.ToString();
                                               if (!string.IsNullOrEmpty(v_period))
                                               {
                                                   string v_return = ValidateGCPAlertPeriod(v_period);
                                                   if (v_return != null) return v_return;
                                                   v_studyAuditModel.gcp_alert_period = Convert.ToInt32(v_period);
                                               }
                                           }
                                           if (v_tableData.ContainsKey("logo_id")) v_studyAuditModel.logo_id = Convert.ToInt32(v_tableData["logo_id"]);
                                           if (v_tableData.ContainsKey("descr")) v_studyAuditModel.descr = (string)v_tableData["descr"];
                                       }
                                   }
                                   catch (Exception v_ex)
                                   {
                                       string v_msg = v_ex.InnerException.ToString();
                                   }
                               }
                               return null;
                           }
                           return null;
                       })

                       .Process(request)
                       .Data();

                return new JsonResult(response);
            }
        }

        private string ValidateGCPAlertPeriod(string p_datum)
        {
            if (!Regex.IsMatch(p_datum, @"^\d+$")) return "GCP Alert period must be a numeric between (1 and 13)";
            if (p_datum.Length > 2) return "GCP Alert period must be a numeric between (1 and 13)";
            int v_number = Convert.ToInt32(p_datum);
            if (v_number > 13) return "GCP Alert period must be a numeric between (1 and 13)";
            return null;
        }
    }
}