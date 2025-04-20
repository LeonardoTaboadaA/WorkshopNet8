using Jazani.Application.Dtos.Libros;
using Jazani.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Jazani.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Jazani.Api.Extensions;
using Jazani.Shared.Extensions;

namespace Jazani.Api.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = _libroService.GetLibrosQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var libros = await queryable
            .Paginar(paginacionDTO)
            .ToListAsync();

            var librosMapeados = _libroService.MapearLibros(libros);
            return Ok(librosMapeados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _libroService.FindByIdAsync(id);

            return Ok(libro);
        }

        [HttpGet("editorial/{editorialId}")]
        public async Task<IActionResult> GetByEditorialId(int editorialId)
        {
            var libros = await _libroService.FindByEditorialIdAsync(editorialId);
            return Ok(libros);
        }

        [HttpGet("autor/{autor}")]
        public async Task<IActionResult> GetByAutor(string autor)
        {
            var libros = await _libroService.FindByAutorAsync(autor);
            return Ok(libros);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LibroBodyDto libroBody)
        {
            var libro = await _libroService.CreateAsync(libroBody);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibroBodyDto libroBody)
        {
            var libro = await _libroService.UpdateAsync(id, libroBody);
            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _libroService.DeleteAsync(id);
            return NoContent(); 
        }


    }
}
