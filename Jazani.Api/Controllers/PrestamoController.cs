using Jazani.Application.Dtos.Prestamos;
using Jazani.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers
{
    [Route("api/prestamos")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prestamos = await _prestamoService.FindAllAsync();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prestamo = await _prestamoService.FindByIdAsync(id);
            return Ok(prestamo);
        }

        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
        {
            var prestamos = await _prestamoService.FindActivosAsync();
            return Ok(prestamos);
        }

        [HttpGet("vencidos")]
        public async Task<IActionResult> GetVencidos()
        {
            var prestamos = await _prestamoService.FindVencidosAsync();
            return Ok(prestamos);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PrestamoBodyDto prestamoBody)
        {
            var prestamo = await _prestamoService.CreateAsync(prestamoBody);
            return CreatedAtAction(nameof(GetById), new { id = prestamo.Id }, prestamo);
        }

        [HttpPut("{id}/devolver")]
        public async Task<IActionResult> Devolver(int id)
        {
            var prestamo = await _prestamoService.DevolverAsync(id);
            return Ok(prestamo);
        }

        [HttpPut("{id}/extender")]
        public async Task<IActionResult> Extender(int id, [FromBody] ExtenderPrestamoDto extenderPrestamoDto)
        {
            var prestamo = await _prestamoService.ExtenderFechaDevolucionAsync(id, extenderPrestamoDto);
            return Ok(prestamo);
        }

    }

}
