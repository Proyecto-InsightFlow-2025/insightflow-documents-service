using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace documents_service_api.src.Models
{
    /// <summary>
    /// Modelo que representa un documento.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// ID del documento.
        /// </summary>
        public Guid id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Título del documento.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Icono del documento.
        /// </summary>
        public string icon { get; set; } = "📄";
        /// <summary>
        /// ID del espacio de trabajo asociado al documento.
        /// </summary>
        public Guid workspace_id { get; set; }
        /// <summary>
        /// Contenido del documento.
        /// </summary>
        public object content { get; set; } = new List<object>();
        /// <summary>
        /// Indica si el documento ha sido eliminado lógicamente.
        /// </summary>
        public bool soft_deleted { get; set; } = false;

    }
}