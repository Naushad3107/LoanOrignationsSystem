using LOSApplicationApi.Data;
using LOSApplicationApi.DTO;
using LOSApplicationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LOSApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        ApplicationDbContext db;
        IDocumentType documentTypeService;
        public DocumentTypeController(ApplicationDbContext db, IDocumentType documentTypeService)
        {
            this.db = db;
            this.documentTypeService = documentTypeService;
        }

        [HttpGet]
        [Route("FetchDocumentTypes")]
        public IActionResult FetchDocumentTypes()
        {
            var data = documentTypeService.FetchDocumentTypes();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddDocumentType")]
        public IActionResult AddDocumentTypes(AddDocumentTypeDTO document)
        {
            documentTypeService.AddDocumentType(document);
            return Ok("Document type added successfully");
        }

        [HttpPut]
        [Route("UpdateDocumentType")]
        public IActionResult UpdateDocumentType(UpdateDocumentTypeDTO document)
        {
            documentTypeService.UpdateDocumentType(document);
            return Ok("Document type updated successfully");
        }

        [HttpDelete]
        [Route("DeleteDocumentType/{id}")]
        public IActionResult DeleteDocumentType(int id)
        {
            documentTypeService.DeleteDocumentType(id);
            return Ok("Document type deleted successfully");
        }

        [HttpGet]
        [Route("FetchDocumentTypeById/{id}")]
        public IActionResult FetchDocumentTypeById(int id)
        {
            var data = documentTypeService.FetchDocumentTypeById(id);
            if (data == null)
            {
                return NotFound("Document type not found");
            }
            return Ok(data);
        }
    }
}
