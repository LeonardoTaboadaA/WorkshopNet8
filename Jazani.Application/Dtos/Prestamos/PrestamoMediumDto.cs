using Jazani.Application.Dtos.Solicitantes;
using Jazani.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Prestamos
{
    public class PrestamoMediumDto
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public int EstadoPrestamo { get; set; }
        public virtual SolicitanteSmallDto? Solicitante { get; set; }

    }
}
