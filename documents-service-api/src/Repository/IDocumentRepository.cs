using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Repository
{
    public interface IDocumentRepository
    {
        public Task<Document> CreateDocument(Document document);
        public Task<Document?> GetDocumentById(Guid id);
        public Task<Document?> UpdateDocument(Document document, Guid id);
        public Task<bool> SoftDeleteDocument(Guid id);
        public Task<List<Document>> GetAllDocuments();
    }
}