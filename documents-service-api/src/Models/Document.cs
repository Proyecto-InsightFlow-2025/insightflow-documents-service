using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.models
{
    public class Document
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string title { get; set; }
        public string icon { get; set; } = "📄";
        public Guid workspace_id { get; set; }
        public object content { get; set; } = new List<object>();
        public bool soft_deleted { get; set; } = false;

    }
}