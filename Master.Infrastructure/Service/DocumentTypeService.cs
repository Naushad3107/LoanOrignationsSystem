using AutoMapper;
using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;

namespace LOSApplicationApi.Service
{
    public class DocumentTypeService : IDocumentType
    {
        ApplicationDbContext db;
        IMapper mapper;
        public DocumentTypeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddDocumentType(AddDocumentTypeDTO documentType)
        {
            var details = mapper.Map<Model.DocumentType>(documentType);
            db.DocumentTypes.Add(details);
            db.SaveChanges();
        }

        public List<DTO.FetchDocumentTypeDTO> FetchDocumentTypes()
        {
            var details = db.DocumentTypes.Where(x => x.IsActive == 1 && x.IsDeleted == 0).ToList();
            var mappedDetails = mapper.Map<List<DTO.FetchDocumentTypeDTO>>(details);
            return mappedDetails;
        }

        public DTO.FetchDocumentTypeDTO FetchDocumentTypeById(int id)
        {
            var data = db.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == id && x.IsActive == 1 && x.IsDeleted == 0);
            if (data != null)
            {
                var mappedData = mapper.Map<DTO.FetchDocumentTypeDTO>(data);
                return mappedData;
            }
            return null; // or throw an exception if preferred
        }
        public void UpdateDocumentType(UpdateDocumentTypeDTO documentType)
        {
            var data = db.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == documentType.DocumentTypeId && x.IsActive == 1 && x.IsDeleted == 0);
            if (data != null)
            {
                var updatedData = mapper.Map(documentType, data);
                db.DocumentTypes.Update(updatedData);
                db.SaveChanges();
            }
        }
        public void DeleteDocumentType(int id)
        {
            var data = db.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == id && x.IsActive == 1 && x.IsDeleted == 0);
            if (data != null)
            {
                data.IsDeleted = 1; // Assuming IsDeleted is a flag to mark deletion
                db.SaveChanges();
            }
        }
    }
}
