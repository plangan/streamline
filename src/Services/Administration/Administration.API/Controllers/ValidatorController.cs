using Microsoft.AspNetCore.Mvc;
using StreamLineModels;
using System.Linq;
using System.Net;

namespace Administration.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValidatorController : ControllerBase
    {
        private readonly IcecapContext _context;

        public ValidatorController(IcecapContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("IsUserExists")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public JsonResult IsUserExists(string UserName)
        {
            return new JsonResult(!_context.TblPersondetails.Any(x => x.Username == UserName));
        }
    }
}