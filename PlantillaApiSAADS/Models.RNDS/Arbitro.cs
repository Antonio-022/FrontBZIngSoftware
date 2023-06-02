using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Arbitro
    {
        public int arbitroId { get; set; }
        public string? certificaciones { get; set; }
        public string? especialidad { get; set; }
        public int? experiencias { get; set; }
        public int? historialdepartidos { get; set; }
        public int? identificacion { get; set; }
        public string? nombre { get; set; }
        public int? puntuacion { get; set; }
        public int? partido { get; set; }
        public int? personaId { get; set; }

        public virtual Partido? partidoNavigation { get; set; }
        public virtual Persona? persona { get; set; }
    }
}
