using Administration.API.Model.Requests.Site;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Site
{
    public class SiteCreateRequestToTblInstitutiondetailsProfile : Profile
    {
        public SiteCreateRequestToTblInstitutiondetailsProfile()
        {
            CreateMap<SiteCreateRequest, TblInstitutiondetails>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}