using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class InscripcionesCampeonato
    {
        public int inscripciones_id { get; set; }
        public int? campeonatoId { get; set; }
        public int? equipoId { get; set; }
        public bool? estado { get; set; }

        public virtual Campeonato? campeonato { get; set; }
        public virtual Equipo? equipo { get; set; }
    }
}
