using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Services;
using documents_service_api.src.Dtos;
using Microsoft.AspNetCore.Mvc;
using documents_service_api.src.Models;
using documents_service_api.src.Helpers;
namespace documents_service_api.src.Controllers
{
    /// <summary>
    /// Controlador para la gestión de documentos.
    /// </summary>
    [ApiController]
    [Route("documents")]
    public class DocumentController : ControllerBase
    {
        /// <summary>
        /// Servicio de documentos.
        /// </summary>
        private readonly DocumentService _documentService;
        /// <summary>
        /// Constructor del controlador de documentos.
        /// </summary>
        /// <param name="documentService"></param>
        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }
        /// <summary>
        /// Obtiene un documento por su ID.
        /// </summary>
        /// <param name="id">ID del documento</param>
        /// <returns>Documento encontrado o error</returns>
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
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request."});
            }
        }
        /// <summary>
        /// Crea un nuevo documento.
        /// </summary>
        /// <param name="request">Datos del documento a crear</param>
        /// <returns>Documento creado</returns>
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
            var document = await _documentService.CreateDocument(request);
            return CreatedAtAction(nameof(GetDocumentById), new { id = document.id }, document);
        }
        /// <summary>
        /// Actualiza un documento existente.
        /// </summary>
        /// <param name="id">ID del documento a actualizar</param>
        /// <param name="request">Datos del documento a actualizar</param>
        /// <returns>Documento actualizado</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] UpdateDocumentDto request)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()) || string.IsNullOrWhiteSpace(request.title) || string.IsNullOrWhiteSpace(request.icon) || request.content == null){
                return BadRequest(new { Message = "All fields are required" });
            }
            var updated = await _documentService.UpdateDocument(request, id);
            if (updated == null)
            {
                return NotFound(new { Message = "Document not found" });
            }
            return Ok(updated);
        }
        /// <summary>
        /// Elimina un documento por su ID (soft delete).
        /// </summary>
        /// <param name="id">ID del documento a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            var deleted = await _documentService.SoftDeleteDocument(id);
            if (deleted == false)
            {
                return NotFound(new { Message = "Document not found" });
            }
            return Ok(new { Message = "Document deleted successfully" });
        }
        /// <summary>
        /// Obtiene todos los documentos.
        /// </summary>
        /// <returns>Lista de documentos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocuments();
            return Ok(documents);
        }
    }
}