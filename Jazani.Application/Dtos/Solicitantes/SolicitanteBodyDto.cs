using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Solicitantes
{
    public class SolicitanteBodyDto
    {
        public string? NombreCompleto { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}
