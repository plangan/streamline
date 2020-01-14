using Administration.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamLineModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Administration.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class LookupStatusController : ControllerBase
    {
        private readonly IcecapContext _context;

        public LookupStatusController(IcecapContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetResponseStatus")]
        [ProducesResponseType(typeof(IEnumerable<ResponseStatus>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ResponseStatus>>> GetResponseStatus()
        {
            return await _context.TblResponsestatus
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new ResponseStatus()
                    {
                        response_status_id = x.Id,
                        status = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetStudyStatus")]
        [ProducesResponseType(typeof(IEnumerable<StudyStatus>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudyStatus>>> GetStudyStatus()
        {
            return await _context.TblStudystatus
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new StudyStatus()
                    {
                        study_status_id = x.Id,
                        status = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetStudy")]
        [ProducesResponseType(typeof(IEnumerable<StudyDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudyDD>>> GetStudy()
        {
            return await _context.TblTrialdetails
                    .Where(x => x.Id > 0)
                    .Select(x => new StudyDD()
                    {
                        study_id = x.Id,
                        studyname = x.Shortname
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetSite")]
        [ProducesResponseType(typeof(IEnumerable<InstDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InstDD>>> GetSite()
        {
            return await _context.TblInstitutiondetails
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .OrderBy(x => x.Institution)
                    .Select(x => new InstDD()
                    {
                        inst_id = x.Id,
                        site = x.Institution
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetStudyRole")]
        [ProducesResponseType(typeof(IEnumerable<StudyRoleDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudyRoleDD>>> GetStudyRole()
        {
            return await _context.TblStudyrole
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new StudyRoleDD()
                    {
                        study_role_id = x.Id,
                        role = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetResearcher")]
        [ProducesResponseType(typeof(IEnumerable<ResearcherDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ResearcherDD>>> GetResearcher()
        {
            return await _context.TblPersondetails
                    .Where(x => x.Active == 1)
                    .OrderBy(x => $"{x.GivenName} {x.FamilyName}")
                    .Select(x => new ResearcherDD()
                    {
                        person_id = x.Id,
                        fullname = $"{x.GivenName} {x.FamilyName}"
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetSiteReviewStatus")]
        [ProducesResponseType(typeof(IEnumerable<SiteReviewDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SiteReviewDD>>> GetSiteReviewStatus()
        {
            return await _context.TblLocalStatus
                    .Select(x => new SiteReviewDD()
                    {
                        site_status_id = x.Id,
                        descr = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetCTUReviewStatus")]
        [ProducesResponseType(typeof(IEnumerable<CTUReviewDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CTUReviewDD>>> GetCTUReviewStatus()
        {
            return await _context.TblCtuStatus
                    .Select(x => new CTUReviewDD()
                    {
                        ctu_status_id = x.Id,
                        descr = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetPrivilege")]
        [ProducesResponseType(typeof(IEnumerable<PrivilegeDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PrivilegeDD>>> GetPrivilege()
        {
            return await _context.TblPrivileges
                    .Where(x => x.Active == 1)
                    .Select(x => new PrivilegeDD()
                    {
                        priv_id = x.Id,
                        descr = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetJobTitle")]
        [ProducesResponseType(typeof(IEnumerable<MainJobTitleDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MainJobTitleDD>>> GetJobTitle()
        {
            return await _context.TblJobtitle
                    .Where(x => x.Id > 0)
                    .Select(x => new MainJobTitleDD()
                    {
                        main_job_title_id = x.Id,
                        job_title = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("Get2JobTitle")]
        [ProducesResponseType(typeof(IEnumerable<SecondaryJobTitleDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SecondaryJobTitleDD>>> Get2JobTitle()
        {
            return await _context.TblJobtitle
                    .Where(x => x.Id > 0)
                    .Select(x => new SecondaryJobTitleDD()
                    {
                        secondary_job_title_id = x.Id,
                        job_title = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetCVReceived")]
        [ProducesResponseType(typeof(IEnumerable<CVReceivedDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CVReceivedDD>>> GetCVReceived()
        {
            return await _context.TblReceivedstatus
                    .Where(x => x.Id > 0)
                    .Select(x => new CVReceivedDD()
                    {
                        cv_received_id = x.Id,
                        receivedname = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetGCPReceived")]
        [ProducesResponseType(typeof(IEnumerable<GCPReceivedDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GCPReceivedDD>>> GetGCPReceived()
        {
            return await _context.TblReceivedstatus
                    .Where(x => x.Id > 0)
                    .Select(x => new GCPReceivedDD()
                    {
                        gcp_received_id = x.Id,
                        receivedname = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetTitle")]
        [ProducesResponseType(typeof(IEnumerable<PersonTitleDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PersonTitleDD>>> GetTitle()
        {
            return await _context.TblTitle
                    .Where(x => x.Id > 0)
                    .Select(x => new PersonTitleDD()
                    {
                        title_id = x.Id,
                        title = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetStudyInst/{studyId:int?}")]
        [ProducesResponseType(typeof(IEnumerable<StudyInstDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudyInstDD>>> GetStudyInst(int? studyId)
        {
            IEnumerable<StudyInstDD> list = new List<StudyInstDD>();

            if (studyId.HasValue)
            {
                list = await (from a in _context.TblStudyinst
                              join b in _context.TblInstitutiondetails on a.InstId equals b.Id
                              where a.StudyId == studyId
                              select new StudyInstDD
                              {
                                  inst_id = a.InstId,
                                  institution = b.Institution
                              })
                        .Distinct()
                        .ToListAsync();
            }
            else
            {
                list = await _context.TblInstitutiondetails
                        .Where(x => x.Id > 0)
                        .Select(x => new StudyInstDD()
                        {
                            inst_id = x.Id,
                            institution = x.Institution
                        })
                        .ToListAsync();
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("GetInstRole")]
        [ProducesResponseType(typeof(IEnumerable<InstRoleDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InstRoleDD>>> GetInstRole()
        {
            return await _context.TblJobtitle
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new InstRoleDD()
                    {
                        inst_role_id = x.Id,
                        rolename = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetCtry")]
        [ProducesResponseType(typeof(IEnumerable<CtryDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CtryDD>>> GetCtry()
        {
            return await _context.TblCtry
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new CtryDD()
                    {
                        ctry_id = x.Id,
                        ctry = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetInstActivityStatus")]
        [ProducesResponseType(typeof(IEnumerable<InstActivityDD>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<InstActivityDD>>> GetInstActivityStatus()
        {
            return await _context.TblActivitystatus
                    .Where(x => x.Id > 0 && x.Active == 1)
                    .Select(x => new InstActivityDD()
                    {
                        activity_status_id = x.Id,
                        activity = x.Descr
                    })
                    .ToListAsync();
        }

        [HttpGet]
        [Route("GetActive")]
        [ProducesResponseType(typeof(IEnumerable<ActiveDD>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<ActiveDD>> GetActive()
        {
            var list = new List<ActiveDD>
            {
                new ActiveDD { active = "Active", active_id = 1 },
                new ActiveDD { active = "Inactive", active_id = 0 }
            };
            return Ok(list);
        }
    }
}