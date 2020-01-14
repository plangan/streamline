using Administration.API.Model.Responses.Site;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Site
{
    public class SiteResponseToTblInstitutiondetailsProfile : Profile
    {
        public SiteResponseToTblInstitutiondetailsProfile()
        {
            CreateMap<TblInstitutiondetails, SiteResponse>();
        }
    }
}