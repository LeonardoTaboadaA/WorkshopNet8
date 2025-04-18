using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Models
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
    }
}
