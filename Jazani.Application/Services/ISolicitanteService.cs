using Jazani.Application.Dtos.Editoriales;
using Jazani.Application.Dtos.Solicitantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Services
{
    public interface ISolicitanteService
    {
        Task<IReadOnlyList<SolicitanteSmallDto>> FindAllAsync();
        Task<SolicitanteDto> FindByIdAsync(int id);
        Task<SolicitanteSmallDto> CreateAsync(SolicitanteBodyDto solicitanteBody);
        Task<SolicitanteSmallDto> UpdateAsync(int id, SolicitanteBodyDto solicitanteBody);
    }
}
