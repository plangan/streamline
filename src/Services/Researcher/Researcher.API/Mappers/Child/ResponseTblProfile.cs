using AutoMapper;
using Researcher.API.Models.Responses.Child;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.Child
{
    public class ResponseTblProfile : Profile
    {
        public ResponseTblProfile()
        {
            CreateMap<TblChild, ChildResponse>()
                .ForMember(destination => destination.childID, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.childDescr, opts => opts.MapFrom(source => source.Descr))
                .ForMember(destination => destination.parentID, opts => opts.MapFrom(source => source.ParentId))
                ;
        }
    }
}