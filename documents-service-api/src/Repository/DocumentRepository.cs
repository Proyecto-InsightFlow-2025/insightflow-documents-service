using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using documents_service_api.src.Models;

namespace documents_service_api.src.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly List<Document> _documents;
        public DocumentRepository()
        {
            _documents = new List<Document>();
        }
        
        public async Task<Document> CreateDocument(Document document)
        {
            _documents.Add(document);
            return await Task.FromResult(document);
        }
        public async Task<Document?> GetDocumentById(Guid id)
        {
            var document = _documents.FirstOrDefault(d => d.id == id && !d.soft_deleted);
            return await Task.FromResult(document);
        }
        public async Task<Document?> UpdateDocument(Document document, Guid id)
        {
            var existingDocument = _documents.FirstOrDefault(d => d.id == id && !d.soft_deleted);
            if (existingDocument == null)
            {
                return null;
            }
            existingDocument.title = document.title ?? existingDocument.title;
            existingDocument.icon = document.icon ?? existingDocument.icon;
            existingDocument.content = document.content ?? existingDocument.content;
            return await Task.FromResult(existingDocument);
        }
        public async Task<bool> SoftDeleteDocument(Guid id)
        {
            var document = _documents.FirstOrDefault(d => d.id == id && !d.soft_deleted);
            if (document != null)
            {
                document.soft_deleted = true;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        public async Task<List<Document>> GetAllDocuments()
        {
            var documents = _documents.ToList();
            return await Task.FromResult(documents);
        }
    }
}