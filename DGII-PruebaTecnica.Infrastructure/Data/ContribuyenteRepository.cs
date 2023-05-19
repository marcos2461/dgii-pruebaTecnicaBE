using DGII_PruebaTecnica.Core.Entities;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DGII_PruebaTecnica.Infrastructure.Data
{
     
    public class contribuyenteRepository : BaseRepository<contribuyente> , IContribuyenteRepository
    {
        private readonly AppDbContext _dbContext;
        public contribuyenteRepository(AppDbContext dbContext) : base(dbContext)
        {
           _dbContext= dbContext;
        }

        public async Task<List<tipoIdentificacion>>  getTipoIdentificaciones()
        {
            return _dbContext.tipoIdentificacion.ToList();
        }

        public async Task<IEnumerable<contribuyente>> getAllContribuyentes()
        {
            return await _dbContext.contribuyente.Include(x=>x.tipoIdentificacion).Include(c=>c.tipoContribuyente).ToListAsync();
        }
    }
}
