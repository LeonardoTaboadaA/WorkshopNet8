using Jazani.Application.Dtos.Editoriales;
using Jazani.Application.Services;
using Jazani.Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers
{
    [Route("api/editoriales")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        private readonly ILibroService _libroService;

        public EditorialController(IEditorialService editorialService, ILibroService libroService)
        {
            _editorialService = editorialService;
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var editoriales = await _editorialService.FindAllAsync();

            return Ok(editoriales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var editorial = await _editorialService.FindByIdAsync(id);
            return Ok(editorial);
        }

        [HttpGet("{id}/libros")]
        public async Task<IActionResult> GetLibrosByEditorialId(int id)
        {
            var libros = await _libroService.FindByEditorialIdAsync(id);
            return Ok(libros);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EditorialBodyDto editorialBody)
        {
            var editorial = await _editorialService.CreateAsync(editorialBody);
            return CreatedAtAction(nameof(GetById), new { id = editorial.Id }, editorial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EditorialBodyDto editorialBody)
        {
            var editorial = await _editorialService.UpdateAsync(id, editorialBody);
            return Ok(editorial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _editorialService.DeleteAsync(id);
            return NoContent();
        }

    }


}
