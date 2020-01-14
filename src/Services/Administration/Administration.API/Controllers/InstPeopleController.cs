using Administration.API.Model;
using AutoMapper;
using Common.Extensions;
using DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StreamLineModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Administration.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class InstPeopleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IcecapContext _context;
        private readonly IMapper _mapper;

        public InstPeopleController(IConfiguration configuration, IcecapContext context, IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("NumAssignedSites")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> NumAssignedSites()
        {
            return await _context.TblInstpeople.CountAsync(x => x.PersonId == User.Claims.GetPersonId());
        }

        [HttpGet]
        [Route("LoginSelect")]
        [ProducesResponseType(typeof(DtResponse), (int)HttpStatusCode.OK)]
        public IActionResult LoginSelect()
        {
            var v_userIDStr = User.Claims.GetPersonId().ToString();

            var request = HttpContext.Request;
            using (var db = new Database(_configuration["DbType"], _configuration["ConnectionString"]))
            {
                var response = new Editor(db, "tbl_instpeople", new[] { "person_id", "inst_id" })
                    .TryCatch(false)
                    .Model<InstPeopleModel>()
                    .Field(new Field("tbl_instpeople.person_id")
                        .Options(new Options()
                            .Table("tbl_persondetails")
                            .Value("id")
                            .Label(new[] { "given_name", "family_name" })
                        )
                    )
                    .Field(new Field("tbl_instpeople.inst_id")
                        .Options(new Options()
                            .Table("tbl_institutiondetails")
                            .Value("id")
                            .Label("Institution")
                        )
                    )
                    .Field(new Field("tbl_instpeople.prime"))
                    .Field(new Field("tbl_instpeople.inst_role_id")
                       .Options(new Options()
                            .Table("tbl_jobtitle")
                            .Value("id")
                            .Label("descr")
                        )
                    )
                    .Field(new Field("tbl_institutiondetails.institution").Set(false))
                    .Field(new Field("tbl_persondetails.given_name").Set(false))
                    .Field(new Field("tbl_persondetails.family_name").Set(false))

                    .LeftJoin("tbl_persondetails", "tbl_persondetails.id", "=", "tbl_instpeople.person_id")
                    .LeftJoin("tbl_institutiondetails", "tbl_institutiondetails.id", "=", "tbl_instpeople.inst_id")
                    .LeftJoin("tbl_jobtitle", "tbl_jobtitle.id", "=", "tbl_instpeople.inst_role_id")
                    .Where("tbl_instpeople.person_id", v_userIDStr, "=")
                    .Validator((editor, type, args) =>
                    {
                        /*
                                                if (type == DtRequest.RequestTypes.EditorCreate)
                                                {
                                                }
                        */
                        if (type == DtRequest.RequestTypes.EditorEdit)
                        {
                            foreach (var d in args.Data)
                            {
                                var pkey = editor.PkeyToArray(d.Key);
                                var keyUserVisits = pkey["tbl_instpeople"] as Dictionary<string, object>;
                                var userVisits = d.Value as Dictionary<string, object>;
                                var submitUserVisits = userVisits["tbl_instpeople"] as Dictionary<string, object>;

                                if (keyUserVisits["person_id"] != submitUserVisits["person_id"] &&
                                    keyUserVisits["inst_id"] != submitUserVisits["inst_id"])
                                {
                                    var any = editor.Db().Any("tbl_instpeople", (q) =>
                                    {
                                        q.Where("person_id", submitUserVisits["person_id"]);
                                        q.Where("inst_id", submitUserVisits["inst_id"]);
                                    });

                                    if (!any)
                                    {
                                        return "Looks as if the researcher is not assigned to the Site";
                                    }
                                }
                            }
                        }

                        return null;
                    })
                    .Process(request)
                    .Data();

                return new JsonResult(response);
            }
        }
    }
}