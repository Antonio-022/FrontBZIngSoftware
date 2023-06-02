using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Campeonato
    {
        public Campeonato()
        {
            InscripcionesCampeonato = new HashSet<InscripcionesCampeonato>();
        }

        public int campeonatoid { get; set; }
        public int? categoriaId { get; set; }
        public string? descripcion { get; set; }
        public bool? estadodelcampeonato { get; set; }
        public DateTime? fechaFin { get; set; }
        public DateTime? fechaInicio { get; set; }
        public string? nombreCampeonato { get; set; }
        public string? organizador { get; set; }
        public string? reglas { get; set; }

        public virtual Categoria? categoria { get; set; }
        public virtual ICollection<InscripcionesCampeonato> InscripcionesCampeonato { get; set; }
    }
}
