using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Dtos
{
    public class CreateDocumentDto
    {
        public string title { get; set; }
        public string? icon { get; set; }
        public List<object>? content { get; set; }
        public Guid workspace_id { get; set; }
    }
}