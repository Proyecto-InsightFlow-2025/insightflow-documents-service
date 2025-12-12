using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Dtos;
using documents_service_api.src.Helpers;
namespace documents_service_api.src.Services
{
    /// <summary>
    /// Servicio para la gestión de documentos.
    /// </summary>
    public class DocumentService
    {
        /// <summary>
        /// Repositorio de documentos.
        /// </summary>
        private readonly Repository.IDocumentRepository _documentRepository;
        /// <summary>
        /// Constructor del servicio de documentos.
        /// </summary>
        /// <param name="documentRepository">Repositorio de documentos.</param>
        public DocumentService(Repository.IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        /// <summary>
        /// Crea un nuevo documento.
        /// </summary>
        /// <param name="createDocumentDto">Datos para crear un nuevo documento.</param>
        /// <returns>Documento creado.</returns>
        public async Task<DocumentVisualizerDto> CreateDocument(CreateDocumentDto createDocumentDto)
        {
            var document = DocumentMapper.ToDocument(createDocumentDto);
            var createdDocument = await _documentRepository.CreateDocument(document);
            return DocumentMapper.ToDocumentVisualizerDto(createdDocument);
        }
        /// <summary>
        /// Obtiene un documento por su ID.
        /// </summary>
        /// <param name="id">Identificador del documento.</param>
        /// <returns>Visualizador del documento encontrado.</returns>
        public async Task<DocumentVisualizerDto?> GetDocumentById(Guid id)
        {
            var document = await _documentRepository.GetDocumentById(id);
            if (document == null)
            {
                return null;
            }
            return DocumentMapper.ToDocumentVisualizerDto(document);
        }
        /// <summary>
        /// Actualiza un documento existente.
        /// </summary>
        /// <param name="updateDocumentDto">Datos para actualizar el documento.</param>
        /// <param name="id">Identificador del documento a actualizar.</param>
        /// <returns>Visualizador del documento actualizado.</returns>
        public async Task<DocumentVisualizerDto?> UpdateDocument(UpdateDocumentDto updateDocumentDto, Guid id)
        {
            var document = DocumentMapper.editionToDocument(updateDocumentDto);
            var updatedDocument = await _documentRepository.UpdateDocument(document, id);
            return updatedDocument == null ? null : DocumentMapper.ToDocumentVisualizerDto(updatedDocument);
        }
        /// <summary>
        /// Elimina lógicamente un documento.
        /// </summary>
        /// <param name="id">Identificador del documento a eliminar.</param>
        /// <returns>Indica si la eliminación fue exitosa.</returns>
        public async Task<bool> SoftDeleteDocument(Guid id)
        {
            return await _documentRepository.SoftDeleteDocument(id);
        }
        /// <summary>
        /// Obtiene todos los documentos.
        /// </summary>
        /// <returns>Lista de visualizadores de documentos.</returns>
        public async Task<List<DocumentVisualizerDto>> GetAllDocuments()
        {
            var documents = await _documentRepository.GetAllDocuments();
            return documents.Select(DocumentMapper.ToDocumentVisualizerDto).ToList();
        }
    }
}