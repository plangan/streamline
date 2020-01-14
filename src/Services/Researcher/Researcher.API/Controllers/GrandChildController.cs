using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models.Responses.GrandChild;
using StreamLineModels;
using System.Net;
using System.Threading.Tasks;

namespace Researcher.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class GrandChildController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public GrandChildController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("parent/{parentId}/child/{childId}/chkGrandKids")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> chkGrandKids(string parentId, string childId)
        {
            return await _context.TblGrandchild
                .AnyAsync(x => x.ParentId == parentId && x.ChildId == childId && x.Descr == "Awaiting Approval");
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GrandChildResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GrandChildResponse>> Get(string id)
        {
            var tblGrandchild = await _context.TblGrandchild.FirstOrDefaultAsync(x => x.Id == id);

            if (tblGrandchild == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<GrandChildResponse>(tblGrandchild);
            return response;
        }
    }
}