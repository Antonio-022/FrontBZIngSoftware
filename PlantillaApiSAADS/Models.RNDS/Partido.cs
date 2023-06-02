using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Partido
    {
        public Partido()
        {
            Arbitro = new HashSet<Arbitro>();
            DetallePArtido = new HashSet<DetallePArtido>();
            Fixture = new HashSet<Fixture>();
        }

        public int partido_id { get; set; }
        public string? arbitro { get; set; }
        public int? duracion { get; set; }
        public string? equipoLocal { get; set; }
        public string? equipoVisitante { get; set; }
        public int? estadioId { get; set; }
        public bool? estado_partido { get; set; }
        public DateTime? fecha { get; set; }
        public string? observaciones { get; set; }
        public string? reglas_especificas { get; set; }
        public string? resultado { get; set; }

        public virtual Estadio? estadio { get; set; }
        public virtual ICollection<Arbitro> Arbitro { get; set; }
        public virtual ICollection<DetallePArtido> DetallePArtido { get; set; }
        public virtual ICollection<Fixture> Fixture { get; set; }
    }
}
