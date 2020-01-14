using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models.Responses.StudyPeople;
using StreamLineModels;
using StreamLineModels.Models;
using System.Net;
using System.Threading.Tasks;

namespace Researcher.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class StudyPeopleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public StudyPeopleController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("study/{studyId}/institute/{instId}/person/{personId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StudypeopleResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StudypeopleResponse>> Get(int studyId, int instId, int personId)
        {
            var tblStudypeople = await _context.TblStudypeople
                .FirstOrDefaultAsync(x => x.StudyId == studyId && x.InstId == instId && x.PersonId == personId);

            var response = _mapper.Map<StudypeopleResponse>(tblStudypeople);
            return response;
        }
    }
}