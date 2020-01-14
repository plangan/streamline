using AutoMapper;
using Researcher.API.Models.Responses.GrandChild;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.GrandChild
{
    public class ResponseTblProfile : Profile
    {
        public ResponseTblProfile()
        {
            CreateMap<TblGrandchild, GrandChildResponse>()
                .ForMember(destination => destination.grandChildID, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.grandChildDescr, opts => opts.MapFrom(source => source.Descr))
                .ForMember(destination => destination.parentID, opts => opts.MapFrom(source => source.ParentId))
                .ForMember(destination => destination.childID, opts => opts.MapFrom(source => source.ChildId))
                ;
        }
    }
}