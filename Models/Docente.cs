namespace docentes.Models
{
    public class Docente
    {
        public long Id { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
        public required string Contrato { get; set; }
        public string? Ciudad { get; set; }
        public EscalafonTecnico EscalafonTecnico { get; set; }
        public EscalafonExtension EscalafonExtension { get; set; }
    }
}
