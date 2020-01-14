using AutoMapper;
using Researcher.API.Models.Responses.StudyPeople;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.StudyPeople
{
    public class ResponseTblProfile : Profile
    {
        public ResponseTblProfile()
        {
            CreateMap<TblStudypeople, StudypeopleResponse>();
        }
    }
}