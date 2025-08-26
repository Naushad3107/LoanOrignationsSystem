using LOSApplicationApi.DTO;

namespace LOSApplicationApi.Repository
{
    public interface IDocumentType
    {
        void AddDocumentType(AddDocumentTypeDTO documentType);
        List<FetchDocumentTypeDTO> FetchDocumentTypes();
        FetchDocumentTypeDTO FetchDocumentTypeById(int id);
        void UpdateDocumentType(UpdateDocumentTypeDTO documentType);
        void DeleteDocumentType(int id);
    }
}
