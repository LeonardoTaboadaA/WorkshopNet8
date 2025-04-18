using AutoMapper;
using Jazani.Application.Dtos.Solicitantes;
using Jazani.Domain.Models;
using Jazani.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Services.Implementations
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _solicitanteRepository;
        private readonly IMapper _mapper;

        public SolicitanteService(
            ISolicitanteRepository solicitanteRepository,
            IMapper mapper
        )
        {
            _solicitanteRepository = solicitanteRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SolicitanteSmallDto>> FindAllAsync()
        {
            var solicitantes = await _solicitanteRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<SolicitanteSmallDto>>(solicitantes);
        }

        public async Task<SolicitanteDto> FindByIdAsync(int id)
        {
            var solicitante = await _solicitanteRepository.FindByIdAsync(id);

            if (solicitante is null)
                throw new Exception("Solicitante not found");

            return _mapper.Map<SolicitanteDto>(solicitante);
        }

        public async Task<SolicitanteSmallDto> CreateAsync(SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = _mapper.Map<Solicitante>(solicitanteBody);

            solicitante.FechaRegistro = DateTime.UtcNow;
            solicitante.Estado = 1;

            await _solicitanteRepository.SaveAsync(solicitante);

            return _mapper.Map<SolicitanteSmallDto>(solicitante);
        }

        public async Task<SolicitanteSmallDto> UpdateAsync(int id, SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = await _solicitanteRepository.FindByIdAsync(id);

            if (solicitante is null)
                throw new Exception("Solicitante not found");

            _mapper.Map(solicitanteBody, solicitante);

            await _solicitanteRepository.SaveAsync(solicitante);

            return _mapper.Map<SolicitanteSmallDto>(solicitante);
        }
    }
}
