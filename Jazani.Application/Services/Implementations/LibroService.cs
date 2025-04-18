using AutoMapper;
using Jazani.Application.Dtos.Libros;
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
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(
            ILibroRepository libroRepository,
            IMapper mapper
        )
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<LibroMediumDto>> FindAllAsync()
        {
            Expression<Func<Libro, bool>> predicate = x => x.Estado == 1;

            var includes = new List<Expression<Func<Libro, object>>>()
            {
                x => x.Editorial
            };

            var libros = await _libroRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<LibroMediumDto>>(libros);
        }

        public async Task<LibroDto> FindByIdAsync(int id)
        {
            Expression<Func<Libro, bool>> predicate = x => x.Id == id;

            var includes = new List<Expression<Func<Libro, object>>>()
            {
                x => x.Editorial
            };

            var libro = await _libroRepository.FindFirstOrDefaultAsync(
                predicate: predicate,
                includes: includes
            );


            if (libro is null) throw new Exception("Libro not found");

            return _mapper.Map<LibroDto>(libro);
        }

        public async Task<IReadOnlyList<LibroMediumDto>> FindByEditorialIdAsync(int editorialId)
        {
            Expression<Func<Libro, bool>> predicate = x => x.Estado == 1 && x.IdEditorial == editorialId;

            var includes = new List<Expression<Func<Libro, object>>>
            {
                x => x.Editorial
            };

            var libros = await _libroRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<LibroMediumDto>>(libros);
        }

        public async Task<IReadOnlyList<LibroMediumDto>> FindByAutorAsync(string autor)
        {
            Expression<Func<Libro, bool>> predicate = x =>
                x.Estado == 1 && x.Autores != null && x.Autores.Contains(autor);

            var includes = new List<Expression<Func<Libro, object>>>()
            {
                x => x.Editorial
            };

            var libros = await _libroRepository.FindAllAsync(
                predicate: predicate,
                includes: includes
            );

            return _mapper.Map<IReadOnlyList<LibroMediumDto>>(libros);
        }

        public async Task<LibroSmallDto> CreateAsync(LibroBodyDto libroBody)
        {
            var libro = _mapper.Map<Libro>(libroBody);

            libro.FechaRegistro = DateTime.Now;
            libro.Estado = 1;

            await _libroRepository.SaveAsync(libro);

            return _mapper.Map<LibroSmallDto>(libro);
        }

        public async Task<LibroSmallDto> UpdateAsync(int id, LibroBodyDto libroBody)
        {
            var libro = await _libroRepository.FindByIdAsync(id);
            if (libro == null) throw new Exception("Libro not found");

            _mapper.Map(libroBody, libro);


            await _libroRepository.SaveAsync(libro);

            return _mapper.Map<LibroSmallDto>(libro);
        }

        public async Task DeleteAsync(int id)
        {
            var libro = await _libroRepository.FindByIdAsync(id);
            if (libro == null) throw new Exception("Libro not found");

            libro.Estado = 0;
            await _libroRepository.SaveAsync(libro);
        }
    }
}
