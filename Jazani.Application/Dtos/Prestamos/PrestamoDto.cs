using Jazani.Application.Dtos.Solicitantes;
using Jazani.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Prestamos
{
    public class PrestamoDto
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int EstadoPrestamo { get; set; }
        public int IdSolicitante { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }

        public virtual SolicitanteSmallDto? Solicitante { get; set; }
    }
}
