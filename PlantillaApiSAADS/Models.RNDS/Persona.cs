using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Persona
    {
        public Persona()
        {
            Arbitro = new HashSet<Arbitro>();
            Jugador = new HashSet<Jugador>();
        }

        public int persona_id { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? apellidoPaterno { get; set; }
        public int? documentoIdentidad { get; set; }
        public int? edad { get; set; }
        public string? nacionalidad { get; set; }
        public string? nombre { get; set; }
        public int? telefono { get; set; }

        public virtual ICollection<Arbitro> Arbitro { get; set; }
        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
