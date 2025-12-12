using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Models;

namespace documents_service_api.src.Repository
{
    /// <summary>
    /// Interfaz para el repositorio de documentos.
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Crea un nuevo documento.
        /// </summary>
        /// <param name="document">Documento a crear.</param>
        /// <returns>Documento creado.</returns>
        public Task<Document> CreateDocument(Document document);
        /// <summary>
        /// Obtiene un documento por su ID.
        /// </summary>
        /// <param name="id">ID del documento.</param>
        /// <returns>Documento encontrado o null si no existe.</returns>
        public Task<Document?> GetDocumentById(Guid id);
        /// <summary>
        /// Actualiza un documento existente.
        /// </summary>
        /// <param name="document">Documento con los datos actualizados.</param>
        /// <param name="id">ID del documento a actualizar.</param>
        /// <returns>Documento actualizado o null si no existe.</returns>
        public Task<Document?> UpdateDocument(Document document, Guid id);
        /// <summary>
        /// Elimina lógicamente un documento.
        /// </summary>
        /// <param name="id">ID del documento a eliminar.</param>
        /// <returns>True si el documento fue eliminado, false si no existe.</returns>
        public Task<bool> SoftDeleteDocument(Guid id);
        /// <summary>
        /// Obtiene todos los documentos.
        /// </summary>
        /// <returns>Lista de documentos.</returns>
        public Task<List<Document>> GetAllDocuments();
    }
}