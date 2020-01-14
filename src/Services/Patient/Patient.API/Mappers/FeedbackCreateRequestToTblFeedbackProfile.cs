using AutoMapper;
using Patient.API.Models.Requests;
using StreamLineModels.Models;

namespace Patient.API.Mappers
{
    public class FeedbackCreateRequestToTblFeedbackProfile : Profile
    {
        public FeedbackCreateRequestToTblFeedbackProfile()
        {
            CreateMap<FeedbackCreateRequest, TblFeedback>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}