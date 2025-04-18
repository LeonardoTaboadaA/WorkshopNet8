using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Prestamos
{
    public class PrestamoBodyDto
    {
        public DateTime? FechaDevolucion { get; set; }
        public int IdSolicitante { get; set; }

    }
}
