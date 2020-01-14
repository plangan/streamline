using Administration.API.Model.Requests.Site;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Site
{
    public class SiteUpdateRequestToTblInstitutiondetailsProfile : Profile
    {
        public SiteUpdateRequestToTblInstitutiondetailsProfile()
        {
            CreateMap<SiteUpdateRequest, TblInstitutiondetails>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}