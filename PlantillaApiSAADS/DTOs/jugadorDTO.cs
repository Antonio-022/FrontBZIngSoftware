namespace PlantillaApiSAADS.DTOs
{
    public class jugadorDTO
    {
        public int jugadorid { get; set; }
        public int? altura { get; set; }
        public int? equipoId { get; set; }
        public string? estadisticas { get; set; }
        public string? habilidades { get; set; }
        public string? lesiones { get; set; }
        public int? numero_camiseta { get; set; }
        public int? peso { get; set; }
        public int? posicion { get; set; }
        public int? personaId { get; set; }
       
    }
    public class PerosnaWithJugador : jugadorDTO
    {
        public virtual personaDTO persona { get; set; }
        public virtual EquipoDTO? equipo { get; set; } = null;
    }
    public class personaADD : jugadorDTO
    {
        public virtual personaDTO persona { get; set; }
    }

}
