namespace PlantillaApiSAADS.DTOs
{
    public class UserAuth
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string CargoNombre { get; set; } = string.Empty;
        public int CargoId { get; set; }
        public int SedeId { get; set; }
        public string SedeNombre { get; set; } = string.Empty;
        public int AplicacionId { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long Expiracion { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
