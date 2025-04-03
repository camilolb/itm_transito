using ITMFotomultas.Models;
using System.Threading.Tasks;

namespace ITMFotomultas.Services
{
    public interface IImagenService
    {
        Task<Imagen> SubirImagen(Imagen imagen);
        Task<Imagen> ActualizarImagen(int id, Imagen imagen);
        Task EliminarImagen(int id);
        Task<Imagen> ObtenerImagen(int id);
    }
} 