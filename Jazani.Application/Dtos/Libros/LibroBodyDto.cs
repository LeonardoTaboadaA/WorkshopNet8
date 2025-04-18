using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Libros
{
    public class LibroBodyDto
    {
        public string? Isbn { get; set; }
        public string? Titulo { get; set; }
        public string? Autores { get; set; }
        public string? Edicion { get; set; }
        public int Anio { get; set; }
        public int IdEditorial { get; set; }
    }
}
