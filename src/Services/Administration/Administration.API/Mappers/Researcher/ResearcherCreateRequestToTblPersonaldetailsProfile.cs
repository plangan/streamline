using Administration.API.Model.Requests.Researcher;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Researcher
{
    public class ResearcherCreateRequestToTblPersonaldetailsProfile : Profile
    {
        public ResearcherCreateRequestToTblPersonaldetailsProfile()
        {
            CreateMap<ResearcherCreateRequest, TblPersondetails>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}