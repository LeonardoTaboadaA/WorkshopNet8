using Jazani.Application.Dtos.Libros;

namespace Jazani.Application.Services
{
    public interface ILibroService
    {
        Task<IReadOnlyList<LibroMediumDto>> FindAllAsync();
        Task<LibroDto> FindByIdAsync(int id);
        Task<IReadOnlyList<LibroMediumDto>> FindByEditorialIdAsync(int editorialId);
        Task<IReadOnlyList<LibroMediumDto>> FindByAutorAsync(string autor);

        Task<LibroSmallDto> CreateAsync(LibroBodyDto libroBody);
        Task<LibroSmallDto> UpdateAsync(int id, LibroBodyDto libroBody);
        Task DeleteAsync(int id);

    }
}
