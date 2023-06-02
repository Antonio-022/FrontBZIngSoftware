using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Jugador
    {
        public int jugadorid { get; set; }
        public string? altura { get; set; }
        public int? equipoId { get; set; }
        public string? estadisticas { get; set; }
        public string? habilidades { get; set; }
        public string? lesiones { get; set; }
        public int? numero_camiseta { get; set; }
        public int? peso { get; set; }
        public int? posicion { get; set; }
        public int? personaId { get; set; }

        public virtual Equipo? equipo { get; set; }
        public virtual Persona? persona { get; set; }
    }
}
