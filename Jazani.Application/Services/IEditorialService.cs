using Jazani.Application.Dtos.Editoriales;


namespace Jazani.Application.Services
{
    public interface IEditorialService
    {
        Task<IReadOnlyList<EditorialSmallDto>> FindAllAsync();
        Task<EditorialDto> FindByIdAsync(int id);
        Task<EditorialSmallDto> CreateAsync(EditorialBodyDto editorialBody);
        Task<EditorialSmallDto> UpdateAsync(int id, EditorialBodyDto editorialBody);
        Task DeleteAsync(int id);

    }
}
