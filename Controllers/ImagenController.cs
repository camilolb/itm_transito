using ITMFotomultas.Models;
using ITMFotomultas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITMFotomultas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenService _service;

        public ImagenController(IImagenService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SubirImagen(Imagen imagen)
        {
            var resultado = await _service.SubirImagen(imagen);
            return CreatedAtAction(nameof(ObtenerImagen), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarImagen(int id, Imagen imagen)
        {
            var resultado = await _service.ActualizarImagen(id, imagen);
            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarImagen(int id)
        {
            await _service.EliminarImagen(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerImagen(int id)
        {
            var imagen = await _service.ObtenerImagen(id);
            return imagen == null ? NotFound() : Ok(imagen);
        }
    }
} 