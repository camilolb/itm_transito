using ITMFotomultas.Data;
using ITMFotomultas.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ITMFotomultas.Services
{
    public class FotomultaService : IFotomultaService
    {
        private readonly ApplicationDbContext _context;

        public FotomultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fotomulta> CrearFotomulta(Fotomulta fotomulta)
        {
            // Check if Vehiculo is provided
   
                var vehiculo = await _context.Vehiculos
                    .FirstOrDefaultAsync(v => v.Placa == fotomulta.Vehiculo.Placa);

                if (vehiculo == null)
                {
                    vehiculo = fotomulta.Vehiculo;
                    _context.Vehiculos.Add(vehiculo);
                    await _context.SaveChangesAsync();
                }

                fotomulta.VehiculoId = vehiculo.Id;
            

            _context.Fotomultas.Add(fotomulta);
            await _context.SaveChangesAsync();

            return fotomulta;
        }

        public async Task<Vehiculo> ObtenerPorPlaca(string placa)
        {
            return await _context.Vehiculos
                .Include(v => v.Fotomultas)
                .ThenInclude(f => f.Imagenes)
                .FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public async Task<Fotomulta> ObtenerPorId(int id)
        {
            return await _context.Fotomultas
                .Include(f => f.Imagenes)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
} 