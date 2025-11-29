using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Dtos;
using documents_service_api.src.Models;
namespace documents_service_api.src.Helpers
{
    public class DocumentMapper
    {
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
        public static Document editionToDocument(UpdateDocumentDto dto)
        {
            return new Document
            {
                title = dto.title ?? null,
                icon = dto.icon ?? null,
                content = dto.content ?? null
            };
        }
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