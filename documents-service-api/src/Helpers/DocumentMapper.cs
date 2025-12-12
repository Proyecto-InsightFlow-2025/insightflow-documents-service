using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Dtos;
using documents_service_api.src.Models;
namespace documents_service_api.src.Helpers
{
    /// <summary>
    /// Clase para mapear entre Document y sus DTOs.
    /// </summary>
    public class DocumentMapper
    {
        /// <summary>
        /// Convierte un CreateDocumentDto a un Document.
        /// </summary>
        /// <param name="dto">CreateDocumentDto con los datos del documento a crear.</param>
        /// <returns>Documento creado a partir del DTO.</returns>
        public static Document ToDocument(CreateDocumentDto dto)
        {
            return new Document
            {
                id = Guid.NewGuid(),
                title = dto.title,
                icon = dto.icon ?? "📄",
                workspace_id = dto.workspace_id,
                content = new List<object>(),
                soft_deleted = false
            };
        }
        /// <summary>
        /// Convierte un UpdateDocumentDto a un Document.
        /// </summary>
        /// <param name="dto">UpdateDocumentDto con los datos del documento a actualizar.</param>
        /// <returns>Documento actualizado a partir del DTO.</returns>
        public static Document editionToDocument(UpdateDocumentDto dto)
        {
            return new Document
            {
                title = dto.title ?? null,
                icon = dto.icon ?? null,
                content = dto.content ?? null
            };
        }
        /// <summary>
        /// Convierte un Document a un DocumentVisualizerDto.
        /// </summary>
        /// <param name="document">Documento a convertir.</param>
        /// <returns>DocumentVisualizerDto resultante de la conversión.</returns>
        public static DocumentVisualizerDto ToDocumentVisualizerDto(Document document)
        {
            return new DocumentVisualizerDto
            {
                id = document.id,
                title = document.title,
                icon = document.icon,
                content = (List<object>)document.content,
                soft_deleted = document.soft_deleted
            };
        }
    }
}