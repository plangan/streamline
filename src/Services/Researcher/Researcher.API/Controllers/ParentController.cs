using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models.Responses.Child;
using Researcher.API.Models.Responses.GrandChild;
using Researcher.API.Models.Responses.Parent;
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
    public class ParentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public ParentController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ParentResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ParentResponse>>> Get()
        {
            return await _context.TblParent
                .Where(x => x.Active == 1)
                .Select(s => _mapper.Map<ParentResponse>(s))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ParentResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ParentResponse>> Get(string id)
        {
            var tblParent = await _context.TblParent.FindAsync(id);

            if (tblParent == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<ParentResponse>(tblParent);
            return response;
        }

        [HttpGet("{id}/kids")]
        [ProducesResponseType(typeof(IEnumerable<ChildResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ChildResponse>>> GetKids(string id)
        {
            var query = from a in _context.TblParent
                        join b in _context.TblChild on a.Id equals b.ParentId
                        where a.Id == id && b.Active == 1
                        select new ChildResponse
                        {
                            parentID = a.Id,
                            childID = b.Id,
                            childDescr = b.Descr,
                            childColour = a.Colour,
                            parentDescr = a.Descr
                        };

            return await query.ToListAsync();
        }

        [HttpGet("{id}/child/{childId}/grandkids")]
        [ProducesResponseType(typeof(IEnumerable<GrandChildResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GrandChildResponse>>> GetGrandKids(string id, string childId)
        {
            var query = from a in _context.TblParent
                        join b in _context.TblGrandchild on a.Id equals b.ParentId
                        where a.Id == id && b.ChildId == childId && b.Active == 1
                        select new GrandChildResponse
                        {
                            parentID = a.Id,
                            childID = b.ChildId,
                            grandChildID = b.Id,
                            grandChildDescr = b.Descr,
                            grandChildColour = a.Colour
                        };

            return await query.ToListAsync();
        }
    }
}