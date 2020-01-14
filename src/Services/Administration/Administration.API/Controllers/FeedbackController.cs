using Administration.API.Model;
using AutoMapper;
using DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StreamLineModels;
using System.Net;

namespace Administration.API.Controllers
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

        [HttpGet]
        [Route("GetDatatable")]
        [ProducesResponseType(typeof(DtResponse), (int)HttpStatusCode.OK)]
        public IActionResult GetDatatable()
        {
            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                var response = new Editor(db, "tbl_feedback", new[] { "ecrf_no", "seq" })
                    .Model<FeedbackResultsModel>()
                    .Field(new Field("tbl_feedback.ecrf_no"))
                    .Field(new Field("tbl_feedback.seq"))
                    .Field(new Field("tbl_feedback.datim")
                        .Validator(Validation.DateFormat(
                            "d MMM yyyy HH:mm",
                            new ValidationOpts { Message = "Please enter a date and time in the format d MMMM yyyy HH:mm" }
                            ))
                        .GetFormatter(Format.DateTime("yyyy-MM-dd HH:mm", "d MMM yyyy HH:mm"))
                        .SetFormatter(Format.DateTime("d MMM yyyy HH:mm", "yyyy-MM-dd HH:mm"))
                     )

                    .Field(new Field("tbl_feedback.negative_comments").Validator(Validation.Boolean()))
                    .Field(new Field("tbl_feedback.send_to_nurse").Validator(Validation.Boolean()))
                    .Field(new Field("tbl_feedback.feedback"))

                    .Process(request)
                    .Data();

                return new JsonResult(response);
            }
        }
    }
}