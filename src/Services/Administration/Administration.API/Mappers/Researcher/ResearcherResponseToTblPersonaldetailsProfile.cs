using Administration.API.Model.Responses.Researcher;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers.Researcher
{
    public class ResearcherResponseToTblPersonaldetailsProfile : Profile
    {
        public ResearcherResponseToTblPersonaldetailsProfile()
        {
            CreateMap<TblPersondetails, ResearcherResponse>()
                .ForMember(destination => destination.cv_date, opts => opts.MapFrom(source => source.ShortCvDate.HasValue ? source.ShortCvDate.Value.ToString("yyyy-MM-dd") : null))
                .ForMember(destination => destination.gcp_date, opts => opts.MapFrom(source => source.GcpDate.HasValue ? source.GcpDate.Value.ToString("yyyy-MM-dd") : null))
                .ForMember(destination => destination.gcp_start_date, opts => opts.MapFrom(source => source.GcpStartDate.HasValue ? source.GcpStartDate.Value.ToString("yyyy-MM-dd") : null))
                ;
        }
    }
}