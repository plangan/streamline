using Administration.API.Model;
using Administration.API.Model.Requests.Researcher;
using Administration.API.Model.Responses.Researcher;
using AutoMapper;
using DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class ResearcherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public ResearcherController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        // POST: api/v1/Researcher
        [HttpPost]
        [ProducesResponseType(typeof(ResearcherResponse), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ResearcherResponse>> PostResearcher(ResearcherCreateRequest request)
        {
            var tblPersondetails = _mapper.Map<TblPersondetails>(request);
            tblPersondetails.Active = 1;
            _context.TblPersondetails.Add(tblPersondetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearcher", new { id = tblPersondetails.Id }, tblPersondetails);
        }

        // PUT: api/v1/Researcher/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutResearcher(int id, ResearcherUpdateRequest request)
        {
            var tblPersondetails = _mapper.Map<TblPersondetails>(request);
            tblPersondetails.Id = id;

            _context.Entry(tblPersondetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TblPersondetails.Any(e => e.Id == id))
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

        // GET: api/v1/Researcher/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResearcherResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResearcherResponse>> GetResearcher(int id)
        {
            var tblPersondetails = await _context.TblPersondetails.FindAsync(id);

            if (tblPersondetails == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<ResearcherResponse>(tblPersondetails);
            return response;
        }

        [HttpGet]
        [Route("GetIndividual")]
        [ProducesResponseType(typeof(DtResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetIndividual()
        {
            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                var response = new Editor(db, "tbl_persondetails")
                    .Model<IndividualModel>()
                    .Field(new Field("tbl_persondetails.id")
                        .Validator(Validation.Numeric())
                        .SetFormatter(Format.IfEmpty(null))
                    )
                    .Field(new Field("tbl_persondetails.title_id")
                        .Options(new Options()
                            .Table("tbl_title")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_persondetails.given_name")
                        .Validator(Validation.NotEmpty())
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.middle_name")
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                    )

                    .Field(new Field("tbl_persondetails.family_name")
                        .Validator(Validation.NotEmpty())
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                    )

                    .Field(new Field("tbl_persondetails.preferred_name")
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.previous_name")
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.tel_no")
                        .Validator(Validation.MaxLen(20, new ValidationOpts { Message = "Maximum length is 20 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.main_job_title_id")
                        .Options(new Options()
                            .Table("tbl_jobtitle")
                            .Value("id")
                            .Label("descr")
                        )
                    )

                    .Field(new Field("tbl_persondetails.cv_received_id")
                        .Options(new Options()
                            .Table("tbl_receivedstatus")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                   .Field(new Field("tbl_persondetails.short_cv_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                    )
                   .Field(new Field("tbl_persondetails.gcp_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                    )
                   .Field(new Field("tbl_persondetails.gcp_start_date")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd", "d MMM yyyy"))
                        .SetFormatter(Format.DateTime("d MMM yyyy", "yyyy-MM-dd"))
                    )
                    .Field(new Field("tbl_persondetails.email")
                       .Validator(Validation.MaxLen(100, new ValidationOpts { Message = "Maximum length is 100 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.secretary_name")
                       .Validator(Validation.MaxLen(100, new ValidationOpts { Message = "Maximum length is 100 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.secretary_tel")
                       .Validator(Validation.MaxLen(20, new ValidationOpts { Message = "Maximum length is 20 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.secretary_email")
                        .Validator(Validation.MaxLen(100, new ValidationOpts { Message = "Maximum length is 100 characters..." }))
                    )
                    .Field(new Field("tbl_persondetails.active").Validator(Validation.Boolean()))
                    .Field(new Field("tbl_persondetails.priv_id")
                        .Options(new Options()
                            .Table("tbl_privileges")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_persondetails.username")
                        .Validator(Validation.NotEmpty())
                        .Validator(Validation.MaxLen(30, new ValidationOpts { Message = "Maximum length is 30 characters..." }))
                        .Validator(Validation.Unique(
                            new ValidationOpts { Message = "Username already exists..." }
                            ))
                    )
                    .Field(new Field("tbl_persondetails.pwd")
                        .Validator(Validation.NotEmpty())
                        .Validator(Validation.MaxLen(50, new ValidationOpts { Message = "Maximum length is 50 characters..." }))

                    )

                    .LeftJoin("tbl_title", "tbl_title.id", "=", "tbl_persondetails.title_id")
                    .LeftJoin("tbl_receivedstatus", "tbl_receivedstatus.id", "=", "tbl_persondetails.cv_received_id")
                    .LeftJoin("tbl_privileges", "tbl_privileges.id", "=", "tbl_persondetails.priv_id")
                    .LeftJoin("tbl_jobtitle", "tbl_jobtitle.id", "=", "tbl_persondetails.main_job_title_id")

                    .Process(request)
                    .Data();

                return new JsonResult(response);
            }
        }
    }
}