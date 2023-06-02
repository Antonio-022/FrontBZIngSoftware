using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Estadio
    {
        public Estadio()
        {
            Fixture = new HashSet<Fixture>();
            Partido = new HashSet<Partido>();
        }

        public int estadio_id { get; set; }
        public int? capacidad { get; set; }
        public string? descripcion { get; set; }
        public string? nombre { get; set; }
        public string? ubicacion { get; set; }

        public virtual ICollection<Fixture> Fixture { get; set; }
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
