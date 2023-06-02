using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Fixture
    {
        public int fixture_id { get; set; }
        public string? cancha { get; set; }
        public string? descripcion { get; set; }
        public string? equipos_participantes { get; set; }
        public DateTime? hora { get; set; }
        public string? estado { get; set; }
        public int? estadioId { get; set; }
        public int? partidoId { get; set; }

        public virtual Estadio? estadio { get; set; }
        public virtual Partido? partido { get; set; }
    }
}
