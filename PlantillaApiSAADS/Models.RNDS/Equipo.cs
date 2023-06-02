using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Equipo
    {
        public Equipo()
        {
            DetallePArtido = new HashSet<DetallePArtido>();
            InscripcionesCampeonato = new HashSet<InscripcionesCampeonato>();
            Jugador = new HashSet<Jugador>();
        }

        public int equipo_id { get; set; }
        public int? cantidadIntegrantes { get; set; }
        public string? nombre { get; set; }
        public string? representantes { get; set; }

        public virtual ICollection<DetallePArtido> DetallePArtido { get; set; }
        public virtual ICollection<InscripcionesCampeonato> InscripcionesCampeonato { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
