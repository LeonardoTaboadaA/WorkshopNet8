using AutoMapper;
using Jazani.Application.Dtos.Prestamos;
using Jazani.Domain.Models;
using Jazani.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Services.Implementations
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMapper _mapper;

        public PrestamoService(
            IPrestamoRepository prestamoRepository,
            IMapper mapper
        )
        {
            _prestamoRepository = prestamoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PrestamoMediumDto>> FindAllAsync()
        {
            Expression<Func<Prestamo, bool>> predicate = x => x.Estado == 1;

            var includes = new List<Expression<Func<Prestamo, object>>>()
            {
                x => x.Solicitante
            };

            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<PrestamoMediumDto>>(prestamos);
        }

        public async Task<PrestamoDto> FindByIdAsync(int id)
        {
            Expression<Func<Prestamo, bool>> predicate = x => x.Id == id;

            var includes = new List<Expression<Func<Prestamo, object>>>()
            {
                x => x.Solicitante
            };

            var prestamo = await _prestamoRepository.FindFirstOrDefaultAsync(
                predicate: predicate,
                includes: includes
            );

            if (prestamo is null) throw new Exception("Prestamo not found");

            return _mapper.Map<PrestamoDto>(prestamo);
        }

        public async Task<IReadOnlyList<PrestamoMediumDto>> FindActivosAsync()
        {
            Expression<Func<Prestamo, bool>> predicate = x => x.Estado == 1 && x.EstadoPrestamo == 0;


            var includes = new List<Expression<Func<Prestamo, object>>>
            {
                x => x.Solicitante
            };

            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<PrestamoMediumDto>>(prestamos);
        }

        public async Task<IReadOnlyList<PrestamoMediumDto>> FindVencidosAsync()
        {
            Expression<Func<Prestamo, bool>> predicate = x =>
                x.Estado == 1 &&
                x.EstadoPrestamo == 0 &&
                x.FechaDevolucion < DateTime.Now;

            var includes = new List<Expression<Func<Prestamo, object>>>
            {
                x => x.Solicitante
            };

            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<PrestamoMediumDto>>(prestamos);
        }

        public async Task<PrestamoSmallDto> CreateAsync(PrestamoBodyDto prestamoBody)
        {
            var prestamo = _mapper.Map<Prestamo>(prestamoBody);

            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.FechaRegistro = DateTime.Now;
            prestamo.Estado = 1;
            prestamo.EstadoPrestamo = 0;

            await _prestamoRepository.SaveAsync(prestamo);

            return _mapper.Map<PrestamoSmallDto>(prestamo);
        }

        public async Task<IReadOnlyList<PrestamoMediumDto>> FindBySolicitanteIdAsync(int solicitanteId)
        {
            Expression<Func<Prestamo, bool>> predicate = x => x.Estado == 1 && x.IdSolicitante == solicitanteId;

            var includes = new List<Expression<Func<Prestamo, object>>>
            {
                x => x.Solicitante
            };

            var prestamos = await _prestamoRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<PrestamoMediumDto>>(prestamos);
        }

        public async Task<PrestamoSmallDto> DevolverAsync(int id)
        {
            var prestamo = await _prestamoRepository.FindByIdAsync(id);
            if (prestamo is null) throw new Exception("Prestamo not found");

            prestamo.EstadoPrestamo = 1;
            prestamo.FechaDevolucion = DateTime.Now;

            await _prestamoRepository.SaveAsync(prestamo);

            return _mapper.Map<PrestamoSmallDto>(prestamo);
        }

        public async Task<PrestamoSmallDto> ExtenderFechaDevolucionAsync(int id, ExtenderPrestamoDto extenderPrestamoDto)
        {
            var prestamo = await _prestamoRepository.FindByIdAsync(id);
            if (prestamo == null) throw new Exception("Prestamo not found");

            prestamo.FechaDevolucion = extenderPrestamoDto.FechaDevolucion;

            await _prestamoRepository.SaveAsync(prestamo);

            return _mapper.Map<PrestamoSmallDto>(prestamo);
        }
    }
}
