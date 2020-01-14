using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models.Responses;
using StreamLineModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Researcher.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignedStudiesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public AssignedStudiesController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/v1/AssignedStudies/institute/1/person/1
        [HttpGet("institute/{instId}/person/{personId}")]
        [ProducesResponseType(typeof(IEnumerable<AssignedStudiesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssignedStudiesResponse>>> Get(int instId, int personId)
        {
            var query = from a in _context.TblStudypeople
                        join b in _context.TblPersondetails on a.PersonId equals b.Id into ab
                        from b in ab.DefaultIfEmpty()
                        join c in _context.TblTrialdetails on a.StudyId equals c.Id into ac
                        from c in ac.DefaultIfEmpty()
                        join d in _context.TblImages on c.LogoId equals d.Id into cd
                        from d in cd.DefaultIfEmpty()
                        where a.InstId == instId && a.PersonId == personId
                        select new AssignedStudiesResponse
                        {
                            study_id = a.StudyId,
                            inst_id = a.InstId,
                            person_id = a.PersonId,
                            name = $"{b.GivenName} {b.FamilyName}",
                            shortname = c.Shortname,
                            descr = c.Descr,
                            logo_id = c.LogoId,
                            image_name = d.ImageName,
                            web_path = d.WebPath,
                            system_path = d.SystemPath
                        };

            return await query.ToListAsync();
        }
    }
}