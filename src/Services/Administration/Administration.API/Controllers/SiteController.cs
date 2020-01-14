using Administration.API.Model;
using Administration.API.Model.Requests.Site;
using Administration.API.Model.Responses.Site;
using AutoMapper;
using DataTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StreamLineModels;
using StreamLineModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Administration.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public SiteController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        // POST: api/v1/Site
        [HttpPost]
        [ProducesResponseType(typeof(SiteResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<SiteResponse>> PostSite(SiteCreateRequest request)
        {
            var tblInstitutiondetails = _mapper.Map<TblInstitutiondetails>(request);
            tblInstitutiondetails.Active = 1;
            _context.TblInstitutiondetails.Add(tblInstitutiondetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSite", new { id = tblInstitutiondetails.Id }, tblInstitutiondetails);
        }

        // PUT: api/v1/Site/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutSite(int id, SiteUpdateRequest request)
        {
            var tblInstitutiondetails = _mapper.Map<TblInstitutiondetails>(request);
            tblInstitutiondetails.Id = id;

            _context.Entry(tblInstitutiondetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TblInstitutiondetails.Any(e => e.Id == id))
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

        // GET: api/v1/Site/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(SiteResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SiteResponse>> GetSite(int id)
        {
            var tblInstitutiondetails = await _context.TblInstitutiondetails.FindAsync(id);

            if (tblInstitutiondetails == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SiteResponse>(tblInstitutiondetails);
            return response;
        }

        [HttpGet]
        [Route("GetInstitution")]
        [ProducesResponseType(typeof(DtResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetInstitution()
        {
            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                var response = new Editor(db, "tbl_institutiondetails")
                    .Model<InstitutionModel>()
                    .Field(new Field("tbl_institutiondetails.id")
                        .Validator(Validation.Numeric())
                        .SetFormatter(Format.IfEmpty(null))
                    )
                    .Field(new Field("tbl_institutiondetails.institution")
                        .Validator(Validation.NotEmpty())
                    )
                    .Field(new Field("tbl_institutiondetails.url"))
                    .Field(new Field("tbl_institutiondetails.city"))
                    .Field(new Field("tbl_institutiondetails.ctry_id")
                       .Options(new Options()
                            .Table("tbl_ctry")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_institutiondetails.postcode")
                        .Validator(Validation.MaxLen(20, new ValidationOpts { Message = "Maximum length is 20 characters..." }))
                    )
                    .Field(new Field("tbl_institutiondetails.adr_notes"))
                    .Field(new Field("tbl_institutiondetails.tel_no")
                         .Validator(Validation.MaxLen(20, new ValidationOpts { Message = "Maximum length is 20 characters..." }))
                    )
                    .Field(new Field("tbl_institutiondetails.activity_status_id")
                       .Options(new Options()
                            .Table("tbl_activitystatus")
                            .Value("id")
                            .Label("descr")
                        )
                    /*                        .Options("tbl_activitystatus", "id", "descr") */
                    )
                    .Field(new Field("tbl_institutiondetails.notes"))
                    .Field(new Field("tbl_institutiondetails.active").Validator(Validation.Boolean()))
                    .Field(new Field("tbl_institutiondetails.gcp_period")
                        .Validator(Validation.Numeric())
                        .SetFormatter(Format.IfEmpty(null))
                    )

                    .LeftJoin("tbl_ctry", "tbl_ctry.id", "=", "tbl_institutiondetails.ctry_id")
                    .LeftJoin("tbl_activitystatus", "tbl_activitystatus.id", "=", "tbl_institutiondetails.activity_status_id")

                    .Process(request)
                    .Data();

                return new JsonResult(response);
            }
        }
    }
}