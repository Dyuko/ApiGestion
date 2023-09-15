using MediatR;

namespace ApiGestion.ApplicationCore.Features.Clientes.Commands
{
    public class UpdateClienteCommand : IRequest
    {
        public string Nombre { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string Identificacion { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string Contrasena { get; set; } = null!;
        public bool Estado { get; set; }
    }
}