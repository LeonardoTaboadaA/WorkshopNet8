using Jazani.Application.Dtos.Solicitantes;
using Jazani.Application.Services;
using Jazani.Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers
{
    [Route("api/solicitantes")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;
        private readonly IPrestamoService _prestamoService;

        public SolicitanteController(ISolicitanteService solicitanteService, IPrestamoService prestamoService)
        {
            _solicitanteService = solicitanteService;
            _prestamoService = prestamoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var solicitantes = await _solicitanteService.FindAllAsync();
            return Ok(solicitantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var solicitante = await _solicitanteService.FindByIdAsync(id);
            return Ok(solicitante);
        }

        [HttpGet("{id}/prestamos")]
        public async Task<IActionResult> GetPrestamosBySolicitanteId(int id)
        {
            var prestamos = await _prestamoService.FindBySolicitanteIdAsync(id);
            return Ok(prestamos);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = await _solicitanteService.CreateAsync(solicitanteBody);
            return CreatedAtAction(nameof(GetById), new { id = solicitante.Id }, solicitante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = await _solicitanteService.UpdateAsync(id, solicitanteBody);
            return Ok(solicitante);
        }

    }
}
