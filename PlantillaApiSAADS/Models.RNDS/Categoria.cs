using System;
using System.Collections.Generic;

namespace PlantillaApiSAADS.Models.RNDS
{
    public partial class Categoria
    {
        public Categoria()
        {
            Campeonato = new HashSet<Campeonato>();
        }

        public int categoriaId { get; set; }
        public string? descripcion { get; set; }
        public bool? estado { get; set; }
        public string? nombre { get; set; }

        public virtual ICollection<Campeonato> Campeonato { get; set; }
    }
}
