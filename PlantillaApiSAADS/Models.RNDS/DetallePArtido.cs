using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class DetallePArtido
    {
        public int detallePArtido_id { get; set; }
        public TimeSpan? duracion { get; set; }
        public int? equipoId { get; set; }
        public string? observaciones { get; set; }
        public int? partidoId { get; set; }

        public virtual Equipo? equipo { get; set; }
        public virtual Partido? partido { get; set; }
    }
}
