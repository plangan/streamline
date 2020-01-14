using Administration.API.Model.Requests.Researcher;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Researcher
{
    public class ResearcherUpdateRequestToTblPersonaldetailsProfile : Profile
    {
        public ResearcherUpdateRequestToTblPersonaldetailsProfile()
        {
            CreateMap<ResearcherUpdateRequest, TblPersondetails>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}