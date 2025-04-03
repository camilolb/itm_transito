using ITMFotomultas.Models;
using System.Threading.Tasks;

namespace ITMFotomultas.Services
{
    public interface IFotomultaService
    {
        Task<Fotomulta> CrearFotomulta(Fotomulta fotomulta);
        Task<Vehiculo> ObtenerPorPlaca(string placa);
        Task<Fotomulta> ObtenerPorId(int id);
    }
} 