using AutoMapper;
using Researcher.API.Models.Responses.Parent;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.Parent
{
    public class ResponseTblProfile : Profile
    {
        public ResponseTblProfile()
        {
            CreateMap<TblParent, ParentResponse>()
                .ForMember(destination => destination.parentID, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.parentDescr, opts => opts.MapFrom(source => source.Descr))
                .ForMember(destination => destination.parentColour, opts => opts.MapFrom(source => source.Colour))
                ;
        }
    }
}