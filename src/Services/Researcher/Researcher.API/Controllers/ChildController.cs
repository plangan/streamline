using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Researcher.API.Models.Responses.Child;
using StreamLineModels;
using System.Net;
using System.Threading.Tasks;

namespace Researcher.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ChildController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public ChildController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("parent/{parentId}/chkKids")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> ChkKids(string parentId)
        {
            return await _context.TblChild
                .AnyAsync(x => x.ParentId == parentId && x.Descr == "Awaiting Approval");
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ChildResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ChildResponse>> Get(string id)
        {
            var tblChild = await _context.TblChild.FirstOrDefaultAsync(x => x.Id == id);

            if (tblChild == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<ChildResponse>(tblChild);
            return response;
        }
    }
}