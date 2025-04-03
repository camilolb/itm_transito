using System;
using System.Text.Json.Serialization;

namespace ITMFotomultas.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Ruta { get; set; }
        public int? FotomultaId { get; set; }
        
        [JsonIgnore]
        public Fotomulta? Fotomulta { get; set; }
    }
} 