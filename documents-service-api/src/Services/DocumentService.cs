using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Services
{
    public class DocumentService
    {
        private readonly Repository.IDocumentRepository _documentRepository;
        public DocumentService(Repository.IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        
    }
}