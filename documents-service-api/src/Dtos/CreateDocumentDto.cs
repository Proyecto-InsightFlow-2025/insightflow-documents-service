using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la creación de un documento.
    /// </summary>
    public class CreateDocumentDto
    {
        /// <summary>
        /// Título del documento.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Icono del documento.
        /// </summary>
        public string? icon { get; set; }
        /// <summary>
        /// ID del espacio de trabajo asociado al documento.
        /// </summary>
        public Guid workspace_id { get; set; }
    }
}