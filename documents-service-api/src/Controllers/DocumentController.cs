using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Services;
using documents_service_api.src.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace documents_service_api.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController
    {
        private readonly DocumentService _documentService;
        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(Guid id)
        {
            try{
            var document = await _documentService.GetDocumentById(id);
            if (document == null)
            {
                return NotFound(new { Message = "Document not found" });
            }
            return Ok(document);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentDto request)
        {
            if (request == null)
            {
                return BadRequest(new { Message = "Invalid document data" });
            }
            if (string.IsNullOrWhiteSpace(request.workspace_id.ToString())){
                return BadRequest(new { Message = "Workspace ID is required" });
            }
            var documentId = await _documentService.CreateDocument(request);
            return CreatedAtAction(nameof(GetDocumentById), new { id = documentId }, null);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] DocumentUpdateRequest request)
        {
            var updated = await _documentService.UpdateDocument(id, request);
            if (updated == null)
            {
                return NotFound(new { Message = "Document not found" });
            }
            return Ok(updated, new { Message = "Document updated successfully" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            var deleted = await _documentService.DeleteDocument(id);
            if (deleted == false)
            {
                return NotFound(new { Message = "Document not found or already deleted" });
            }
            return Ok(new { Message = "Document deleted successfully" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocuments();
            return Ok(documents);
        }
    }
}