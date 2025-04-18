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
    public class SolicitanteRepository : CrudRepository<Solicitante, int>, ISolicitanteRepository
    {
        public SolicitanteRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
