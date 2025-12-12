using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace documents_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la visualización de un documento.
    /// </summary>
    public class DocumentVisualizerDto
    {
        /// <summary>
        /// ID del documento.
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// Título del documento.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Icono del documento.
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// Contenido del documento.
        /// </summary>
        public List<object> content { get; set; }
        /// <summary>
        /// ID del espacio de trabajo asociado al documento.
        /// </summary>
        public bool soft_deleted { get; set; }
    }
}