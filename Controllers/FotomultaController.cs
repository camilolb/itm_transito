using ITMFotomultas.Models;
using ITMFotomultas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITMFotomultas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FotomultaController : ControllerBase
    {
        private readonly IFotomultaService _service;

        public FotomultaController(IFotomultaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearFotomulta(Fotomulta fotomulta)
        {
            var resultado = await _service.CrearFotomulta(fotomulta);
            
            // Handle null Vehiculo
            if (resultado.Vehiculo != null)
            {
                return CreatedAtAction(nameof(ObtenerPorPlaca), new { placa = resultado.Vehiculo.Placa }, resultado);
            }
            else
            {
                return CreatedAtAction(nameof(ObtenerFotomulta), new { id = resultado.Id }, resultado);
            }
        }

        [HttpGet("{placa}")]
        public async Task<IActionResult> ObtenerPorPlaca(string placa)
        {
            var vehiculo = await _service.ObtenerPorPlaca(placa);
            return vehiculo == null ? NotFound() : Ok(vehiculo);
        }
        
        [HttpGet("id/{id}")]
        public async Task<IActionResult> ObtenerFotomulta(int id)
        {
            var fotomulta = await _service.ObtenerPorId(id);
            return fotomulta == null ? NotFound() : Ok(fotomulta);
        }
    }
} 