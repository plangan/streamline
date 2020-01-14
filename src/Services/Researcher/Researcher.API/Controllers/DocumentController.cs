using AutoMapper;
using Common.Extensions;
using DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models;
using Researcher.API.Models.Requests.Document;
using Researcher.API.Models.Responses.Document;
using StreamLineModels;
using StreamLineModels.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Researcher.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public DocumentController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        // POST: api/v1/Document
        [HttpPost]
        [ProducesResponseType(typeof(DocumentResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<DocumentResponse>> PostDocument(DocumentCreateRequest request)
        {
            var tblDocuments = _mapper.Map<TblDocuments>(request);
            tblDocuments.Active = 1;
            tblDocuments.UploadedBy = User.Claims.GetPersonId();
            _context.TblDocuments.Add(tblDocuments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = tblDocuments.Id }, tblDocuments);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutDocument(int id, DocumentUpdateRequest request)
        {
            var tblDocuments = await _context.TblDocuments.FindAsync(id);

            if (tblDocuments == null)
            {
                return NotFound();
            }

            tblDocuments.Descr = request.descr;
            tblDocuments.SiteStatusId = request.site_status_id;
            tblDocuments.SiteApprBy = User.Claims.GetPersonId();
            tblDocuments.SiteApprDate = DateTime.Now;
            tblDocuments.CtuStatusId = 5;

            _context.Entry(tblDocuments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TblDocuments.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/v1/Document/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DocumentResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DocumentResponse>> GetDocument(int id)
        {
            var tblDocuments = await _context.TblDocuments.FindAsync(id);

            if (tblDocuments == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<DocumentResponse>(tblDocuments);
            return response;
        }

        [HttpGet("{id}/details")]
        [ProducesResponseType(typeof(DocumentDetailsResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DocumentDetailsResponse>> GetDocumentDetails(int id)
        {
            var query = from a in _context.TblDocuments
                        join b in _context.TblTrialdetails on a.StudyId equals b.Id into ab
                        from b in ab.DefaultIfEmpty()
                        join c in _context.TblInstitutiondetails on a.InstId equals c.Id into ac
                        from c in ac.DefaultIfEmpty()
                        join d in _context.TblPersondetails on a.UploadedBy equals d.Id into ad
                        from d in ad.DefaultIfEmpty()
                        join e in _context.TblCtuStatus on a.CtuStatusId equals e.Id into ae
                        from e in ae.DefaultIfEmpty()
                        join f in _context.TblPersondetails on a.CtuApprBy equals f.Id into af
                        from f in af.DefaultIfEmpty()
                        join g in _context.TblPersondetails on a.SiteApprBy equals g.Id into ag
                        from g in ag.DefaultIfEmpty()
                        join h in _context.TblPersondetails on a.SponsorApprBy equals h.Id into ah
                        from h in ah.DefaultIfEmpty()
                        join i in _context.TblDistType on a.DistTypeId equals i.Id into ai
                        from i in ai.DefaultIfEmpty()
                        join j in _context.TblLocalStatus on a.SiteStatusId equals j.Id into aj
                        from j in aj.DefaultIfEmpty()
                        join k in _context.TblSponsorStatus on a.SponsorStatusId equals k.Id into ak
                        from k in ak.DefaultIfEmpty()
                        where a.Id == id
                        select new DocumentDetailsResponse
                        {
                            id = a.Id,
                            filename = a.Filename,
                            descr = a.Descr,
                            size = a.Size.HasValue ? a.Size.ToString() : null,
                            study_id = a.StudyId.GetValueOrDefault(),
                            studyname = b.Shortname,
                            inst_id = a.InstId.GetValueOrDefault(),
                            institution = c.Institution,
                            uploadedById = a.UploadedBy.GetValueOrDefault(),
                            uploader = $"{d.GivenName} {d.MiddleName} {d.FamilyName}",
                            ctu_status_id = a.CtuStatusId.GetValueOrDefault(),
                            ctu_status = e.Descr,
                            location = a.Location,
                            upload_date = a.UploadDate.HasValue ? a.UploadDate.Value.ToString("yyyy-MM-dd") : null,
                            central_appr_date = a.CtuApprDate.HasValue ? a.CtuApprDate.Value.ToString("yyyy-MM-dd") : null,
                            ctuApprById = a.CtuApprBy.GetValueOrDefault(),
                            central_approver = $"{f.GivenName} {f.MiddleName} {f.FamilyName}",
                            site_status_id = a.SiteStatusId.GetValueOrDefault(),
                            site_status = j.Descr,
                            siteApprById = a.SiteApprBy.GetValueOrDefault(),
                            site_approver = (!string.IsNullOrEmpty(j.Descr) && j.Descr == "Not required") ? "n/a" : $"{g.GivenName} {g.MiddleName} {g.FamilyName}",
                            site_appr_date = (!string.IsNullOrEmpty(j.Descr) && j.Descr == "Not required") ? "n/a" : (a.SiteApprDate.HasValue ? a.SiteApprDate.Value.ToString("yyyy-MM-dd") : null),
                            sponsor_status_id = a.SponsorStatusId.GetValueOrDefault(),
                            sponsor_status = k.Descr,
                            sponsorApprById = a.SponsorApprBy.GetValueOrDefault(),
                            sponser_approver = (!string.IsNullOrEmpty(k.Descr) && k.Descr == "Not required") ? "n/a" : $"{h.GivenName} {h.MiddleName} {h.FamilyName}",
                            sponser_appr_date = (!string.IsNullOrEmpty(k.Descr) && k.Descr == "Not required") ? "n/a" : (a.SponsorApprDate.HasValue ? a.SponsorApprDate.Value.ToString("yyyy-MM-dd") : null),
                            active = a.Active == 1,
                            dist_type_id = a.DistTypeId.GetValueOrDefault(),
                            distribution_type = i.Descr,
                            dist_num_times = a.DistNumTimes.GetValueOrDefault(),
                            parent_id = a.ParentId.GetValueOrDefault(),
                            spare01 = a.Spare01,
                            spare02 = a.Spare02,
                            spare03 = a.Spare03,
                            spare01lbl = a.Spare01lbl,
                            spare02lbl = a.Spare02lbl,
                            spare03lbl = a.Spare03lbl,
                            uri = a.Uri
                        };

            return await query.FirstOrDefaultAsync();
        }

        [HttpGet("study/{studyId}/institute/{instId}/chkSiteDocuments")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> ChkSiteDocuments(int studyId, int instId)
        {
            return await _context.TblDocuments
                .AnyAsync(x => x.StudyId == studyId && x.InstId == instId && x.SiteStatusId == 3);
        }

        [HttpGet]
        [Route("study/{studyId}/institute/{instId}/GetDatatable")]
        [ProducesResponseType(typeof(DtResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetDatatable(int studyId, int instId)
        {
            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                var response = new Editor(db, "tbl_documents")
                    .Model<DocumentModel>()
                    .Where("tbl_documents.site_status_id", 3)
                    .Where("tbl_documents.study_id", studyId)
                    .Where("tbl_documents.inst_id", instId)
                    .Where("tbl_documents.active", true)
                    .Field(new Field("tbl_documents.id")
                        .Validator(Validation.Numeric())
                        .SetFormatter(Format.IfEmpty(null))
                    )
                    .Field(new Field("tbl_documents.filename").Validator(Validation.NotEmpty()))
                    .Field(new Field("tbl_documents.descr"))
                    .Field(new Field("tbl_documents.size"))
                    .Field(new Field("tbl_documents.study_id")
                        .Options(new Options()
                            .Table("tbl_trialdetails")
                            .Value("id")
                            .Label(new[] { "shortname" })
                        )
                    )
                    .Field(new Field("tbl_documents.inst_id")
                        .Options(new Options()
                            .Table("tbl_institutiondetails")
                            .Value("id")
                            .Label(new[] { "institution" })
                        )
                    )
                    .Field(new Field("tbl_documents.uploaded_by")
                        .Options(new Options()
                            .Table("tbl_persondetails")
                            .Value("id")
                            .Label(new[] { "given_name", "family_name" })
                        )
                    )
                    .Field(new Field("tbl_documents.location"))
                    .Field(new Field("tbl_documents.upload_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                    )
                    .Field(new Field("tbl_documents.ctu_status_id")
                        .Options(new Options()
                            .Table("tbl_ctu_status")
                            .Value("id")
                            .Label("descr")
                        )
                    /*                        .Options("tbl_ctu_status", "id", "descr") */
                    )
                   .Field(new Field("tbl_documents.ctu_appr_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                    )
                    .Field(new Field("tbl_documents.ctu_appr_by")
                       .Options(new Options()
                            .Table("tbl_persondetails")
                            .Value("id")
                            .Label(new[] { "given_name", "family_name" })
                        )
                    )
                    .Field(new Field("tbl_documents.site_status_id")
                        .Options(new Options()
                            .Table("tbl_local_status")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_documents.site_appr_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                     )
                     .Field(new Field("tbl_documents.site_appr_by")
                            .Options(new Options()
                            .Table("tbl_persondetails")
                            .Value("id")
                            .Label(new[] { "given_name", "family_name" })
                        )
                     )
                    .Field(new Field("tbl_documents.sponsor_status_id")
                         .Options(new Options()
                            .Table("tbl_sponsor_status")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_documents.sponsor_appr_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                     )
                     .Field(new Field("tbl_documents.sponsor_appr_by")
                            .Options(new Options()
                            .Table("tbl_persondetails")
                            .Value("id")
                            .Label(new[] { "given_name", "family_name" })
                          )
                     //                         .Validator(Validation.DbValues(new ValidationOpts { Empty = false }))
                     )
                    .Field(new Field("tbl_documents.active").Validator(Validation.Boolean()))
                    .Field(new Field("tbl_documents.dist_type_id")
                        .Options(new Options()
                            .Table("tbl_dist_type")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_documents.parent_id"))
                    .Field(new Field("tbl_trialdetails.shortname").Set(false))
                    .Field(new Field("tbl_institutiondetails.institution").Set(false))
                    .Field(new Field("tbl_persondetails.given_name").Set(false))
                    .Field(new Field("tbl_persondetails.family_name").Set(false))
                    .Field(new Field("tbl_documents.uri"))

                    .LeftJoin("tbl_trialdetails", "tbl_trialdetails.id", "=", "tbl_documents.study_id")
                    .LeftJoin("tbl_institutiondetails", "tbl_institutiondetails.id", "=", "tbl_documents.inst_id")
                    .LeftJoin("tbl_persondetails", "tbl_persondetails.id", "=", "tbl_documents.uploaded_by")
                    .LeftJoin("tbl_ctu_status", "tbl_ctu_status.id", "=", "tbl_documents.ctu_status_id")
                    .LeftJoin("tbl_persondetails as ctuperson", "ctuperson.id", "=", "tbl_documents.ctu_appr_by")
                    .LeftJoin("tbl_local_status", "tbl_local_status.id", "=", "tbl_documents.site_status_id")
                    .LeftJoin("tbl_persondetails as siteperson", "siteperson.id", "=", "tbl_documents.site_appr_by")
                    .LeftJoin("tbl_sponsor_status", "tbl_sponsor_status.id", "=", "tbl_documents.sponsor_status_id")
                    .LeftJoin("tbl_persondetails as sponsorperson", "sponsorperson.id", "=", "tbl_documents.sponsor_appr_by")
                    .LeftJoin("tbl_dist_type", "tbl_dist_type.id", "=", "tbl_documents.dist_type_id")
                    .Process(request)
                    .Data();

                return new JsonResult(response);
            }
        }
    }
}