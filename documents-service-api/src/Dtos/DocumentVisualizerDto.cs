using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Dtos
{
    public class DocumentVisualizerDto
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public List<object> content { get; set; }
        public bool soft_deleted { get; set; }
    }
}