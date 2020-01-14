using AutoMapper;
using Researcher.API.Models.Responses.Document;
using StreamLineModels.Models;

namespace Researcher.API.Mappers.Document
{
    public class DocumentResponseToTblDocumentsProfile : Profile
    {
        public DocumentResponseToTblDocumentsProfile()
        {
            CreateMap<TblDocuments, DocumentResponse>();
        }
    }
}