using AutoMapper;
using Jazani.Application.Dtos.Editoriales;
using Jazani.Domain.Models;
using Jazani.Domain.Repositories;


namespace Jazani.Application.Services.Implementations
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public EditorialService(
            IEditorialRepository editorialRepository,
            ILibroRepository libroRepository,
            IMapper mapper
        )
        {
            _editorialRepository = editorialRepository;
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EditorialSmallDto>> FindAllAsync()
        {
            var editoriales = await _editorialRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<EditorialSmallDto>>(editoriales);
        }

        public async Task<EditorialDto> FindByIdAsync(int id)
        {
            var editorial = await _editorialRepository.FindByIdAsync(id);

            if (editorial is null) throw new Exception("Editorial not found");

            return _mapper.Map<EditorialDto>(editorial);
        }

        public async Task<EditorialSmallDto> CreateAsync(EditorialBodyDto editorialBody)
        {
            var editorial = _mapper.Map<Editorial>(editorialBody);

            editorial.FechaRegistro = DateTime.UtcNow;
            editorial.Estado = 1;

            await _editorialRepository.SaveAsync(editorial);

            return _mapper.Map<EditorialSmallDto>(editorial);
        }

        public async Task<EditorialSmallDto> UpdateAsync(int id, EditorialBodyDto editorialBody)
        {
            var editorial = await _editorialRepository.FindByIdAsync(id);

            if (editorial is null) throw new Exception("Editorial not found");

            _mapper.Map(editorialBody, editorial);

            await _editorialRepository.SaveAsync(editorial);

            return _mapper.Map<EditorialSmallDto>(editorial);
        }

        public async Task DeleteAsync(int id)
        {
            var libros = await _libroRepository.FindAllAsync(x => x.IdEditorial == id && x.Estado == 1);
            if (libros.Any())
            {
                throw new InvalidOperationException("No se puede eliminar la editorial porque tiene libros asociados");
            }

            var editorial = await _editorialRepository.FindByIdAsync(id);

            if (editorial is null) throw new Exception("Editorial not found");


            editorial.Estado = 0;
            await _editorialRepository.SaveAsync(editorial);
        }

    }
}
