using Jazani.Domain.Models;
using Jazani.Domain.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Persistences
{
    public class LibroRepository : CrudRepository<Libro, int>, ILibroRepository
    {
        public LibroRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
