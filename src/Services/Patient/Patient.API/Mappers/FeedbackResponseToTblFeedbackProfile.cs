using AutoMapper;
using Patient.API.Models.Responses;
using StreamLineModels.Models;

namespace Patient.API.Mappers
{
    public class FeedbackResponseToTblFeedbackProfile : Profile
    {
        public FeedbackResponseToTblFeedbackProfile()
        {
            CreateMap<TblFeedback, FeedbackResponse>();
        }
    }
}