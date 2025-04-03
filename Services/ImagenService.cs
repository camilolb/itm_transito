using ITMFotomultas.Data;
using ITMFotomultas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ITMFotomultas.Services
{
    public class ImagenService : IImagenService
    {
        private readonly ApplicationDbContext _context;

        public ImagenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Imagen> SubirImagen(Imagen imagen)
        {
            _context.Imagenes.Add(imagen);
            await _context.SaveChangesAsync();
            return imagen;
        }

        public async Task<Imagen> ActualizarImagen(int id, Imagen imagen)
        {
            var imagenExistente = await _context.Imagenes.FindAsync(id);
            if (imagenExistente == null)
                return null;

            imagenExistente.NombreArchivo = imagen.NombreArchivo;
            imagenExistente.Ruta = imagen.Ruta;

            await _context.SaveChangesAsync();
            return imagenExistente;
        }

        public async Task EliminarImagen(int id)
        {
            var imagen = await _context.Imagenes.FindAsync(id);
            if (imagen != null)
            {
                _context.Imagenes.Remove(imagen);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Imagen> ObtenerImagen(int id)
        {
            return await _context.Imagenes.FindAsync(id);
        }
    }
} 