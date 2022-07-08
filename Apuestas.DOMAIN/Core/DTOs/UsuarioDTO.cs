using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Correo { get; set; }
        public int? RolId { get; set; }
        public string? Clave { get; set; }
    }
    public class UsuarioPostDTO
    {
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Correo { get; set; }
        //public int? RolId { get; set; }
        public string? Clave { get; set; }
    }
}
