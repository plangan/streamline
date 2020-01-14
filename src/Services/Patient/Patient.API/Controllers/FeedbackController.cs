using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Patient.API.Models.Requests;
using Patient.API.Models.Responses;
using StreamLineModels;
using StreamLineModels.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Patient.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public FeedbackController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        // POST: api/v1/Feedback
        [HttpPost]
        [ProducesResponseType(typeof(FeedbackResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<FeedbackResponse>> PostFeedback(FeedbackCreateRequest request)
        {
            var tblFeedback = _mapper.Map<TblFeedback>(request);
            var seq = _context.TblFeedback.Where(x => x.EcrfNo == request.ecrf_no).Max(x => x.Seq);
            tblFeedback.Seq = seq + 1;
            tblFeedback.Datim = DateTime.Now;
            _context.TblFeedback.Add(tblFeedback);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<FeedbackResponse>(tblFeedback);
            return response;
        }
    }
}