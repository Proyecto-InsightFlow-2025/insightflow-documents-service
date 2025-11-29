using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Dtos;
using documents_service_api.src.Models;
using documents_service_api.src.Helpers;
namespace documents_service_api.src.Services
{
    public class DocumentService
    {
        private readonly Repository.IDocumentRepository _documentRepository;
        public DocumentService(Repository.IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task<DocumentVisualizerDto> CreateDocument(CreateDocumentDto createDocumentDto)
        {
            var document = DocumentMapper.ToDocument(createDocumentDto);
            return await DocumentMapper.ToDocumentVisualizerDto(await _documentRepository.CreateDocument(document));
        }
        public async Task<DocumentVisualizerDto?> GetDocumentById(Guid id)
        {
            var document = await _documentRepository.GetDocumentById(id);
            return DocumentMapper.ToDocumentVisualizerDto(document);
        }
        public async Task<DocumentVisualizerDto?> UpdateDocument(UpdateDocumentDto updateDocumentDto, Guid id)
        {
            var document = DocumentMapper.editionToDocument(updateDocumentDto);
            var updatedDocument = await _documentRepository.UpdateDocument(document, id);
            return updatedDocument == null ? null : DocumentMapper.ToDocumentVisualizerDto(updatedDocument);
        }
        public async Task<bool> SoftDeleteDocument(Guid id)
        {
            return await _documentRepository.SoftDeleteDocument(id);
        }
        public async Task<List<DocumentVisualizerDto>> GetAllDocumentsInWorkspace(Guid workspace_id)
        {
            var documents = await _documentRepository.GetAllDocumentsInWorkspace(workspace_id);
            return documents.Select(d => DocumentMapper.ToDocumentVisualizerDto(d)).ToList();
        }
    }
}