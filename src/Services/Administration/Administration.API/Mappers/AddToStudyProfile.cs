using Administration.API.Model;
using AutoMapper;
using StreamLineModels.Models;

namespace Administration.API.Mappers
{
    public class AddToStudyProfile : Profile
    {
        public AddToStudyProfile()
        {
            CreateMap<TblPersondetails, AddToStudy>();
        }
    }
}