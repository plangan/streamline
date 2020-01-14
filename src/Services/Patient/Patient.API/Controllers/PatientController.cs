using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Patient.API.Models.Responses;
using StreamLineModels;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Patient.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public PatientController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{ecrfNo}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PatientResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PatientResponse>> Get(string ecrfNo)
        {
            var wh = ecrfNo.Substring(0, 2);

            var task1 = (from a in _context.TblTrialdetails
                         join b in _context.TblImages on a.LogoId equals b.Id into ab
                         from b in ab.DefaultIfEmpty()
                         where a.TrialRef == wh
                         select new
                         {
                             study_id = a.Id,
                             shortname = a.Shortname,
                             web_path = b.WebPath
                         })
                        .FirstOrDefaultAsync();

            wh = ecrfNo.Substring(2, 3);

            var task2 = _context.TblInstitutiondetails
                            .FirstOrDefaultAsync(x => x.InstRef == wh);

            await Task.WhenAll(task1, task2);

            if (task1.Result != null && task2.Result != null)
            {
                var result = new PatientResponse
                {
                    ecrf_no = ecrfNo,
                    study_id = task1.Result.study_id,
                    shortname = task1.Result.shortname,
                    web_path = task1.Result.web_path,
                    inst_id = task2.Result.Id,
                    site = task2.Result.Institution
                };
                return result;
            }

            return null;
        }
    }
}