using AutoMapper;
using Researcher.API.Models.Requests.Document;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.Document
{
    public class DocumentCreateRequestToTblDocumentsProfile : Profile
    {
        public DocumentCreateRequestToTblDocumentsProfile()
        {
            CreateMap<DocumentCreateRequest, TblDocuments>();
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        }
    }
}