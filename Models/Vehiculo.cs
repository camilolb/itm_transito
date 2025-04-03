using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ITMFotomultas.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        public required string Tipo { get; set; }
        public required string Marca { get; set; }
        public required string Color { get; set; }
        
        [JsonIgnore]
        public List<Fotomulta> Fotomultas { get; set; } = new();
    }
} 