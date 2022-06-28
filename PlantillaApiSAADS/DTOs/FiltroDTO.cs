using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantillaApiSAADS.DTOs
{
    public class FiltroDTO
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistrosPorPagina { get; set; } = 20;
        public PaginacionDTO Paginacion
        {
            get { return new PaginacionDTO() { Pagina = Pagina, CantidadRegistrosPorPagina = CantidadRegistrosPorPagina }; }
        }

        public long UserId { get; set; }
        public string Texto { get; set; } = "";
        public string Estado { get; set; } = "";
    }

    public class FiltroFecha : FiltroDTO
    {
        [Required]
        public DateTime Fecha { get; set; }
        public bool ConFechaFin { get; set; } = false;
        public DateTime FechaFin { get; set; }
        public string ZonaHoraira { get; set; } = "";



    }

}
