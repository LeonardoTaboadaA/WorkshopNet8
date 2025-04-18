using Jazani.Application.Dtos.Prestamos;

namespace Jazani.Application.Services
{
    public interface IPrestamoService
    {
        Task<IReadOnlyList<PrestamoMediumDto>> FindAllAsync();
        Task<PrestamoDto> FindByIdAsync(int id);
        Task<IReadOnlyList<PrestamoMediumDto>> FindActivosAsync();
        Task<IReadOnlyList<PrestamoMediumDto>> FindVencidosAsync();
        Task<PrestamoSmallDto> CreateAsync(PrestamoBodyDto prestamoBody);
        Task<IReadOnlyList<PrestamoMediumDto>> FindBySolicitanteIdAsync(int solicitanteId);
        Task<PrestamoSmallDto> DevolverAsync(int id);
        Task<PrestamoSmallDto> ExtenderFechaDevolucionAsync(int id, ExtenderPrestamoDto extenderPrestamoDto);



    }
}
