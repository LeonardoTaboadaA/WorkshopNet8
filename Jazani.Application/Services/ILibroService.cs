using Jazani.Application.Dtos.Libros;
using Jazani.Domain.Models;

namespace Jazani.Application.Services
{
    public interface ILibroService
    {
        IQueryable<Libro> GetLibrosQueryable();
        Task<LibroDto> FindByIdAsync(int id);
        Task<IReadOnlyList<LibroMediumDto>> FindByEditorialIdAsync(int editorialId);
        Task<IReadOnlyList<LibroMediumDto>> FindByAutorAsync(string autor);

        Task<LibroSmallDto> CreateAsync(LibroBodyDto libroBody);
        Task<LibroSmallDto> UpdateAsync(int id, LibroBodyDto libroBody);
        Task DeleteAsync(int id);

        IReadOnlyList<LibroMediumDto> MapearLibros(IList<Libro> libros);

    }
}
