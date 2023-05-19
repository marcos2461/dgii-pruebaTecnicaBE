using DGII_PruebaTecnica.Core.Entities;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DGII_PruebaTecnica.Infrastructure.Data
{
    public class ComprobantesFiscalesRepository : BaseRepository<comprobantesFiscales>, IComprobantesFiscalesRepository
    {
        private readonly AppDbContext _dbContext;
        public ComprobantesFiscalesRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<comprobantesFiscales>> getAllComprobanteSFiscalesByContribuyente(string numeroIdentificacion)
        {
            return await _dbContext.comprobantesFiscales
                .Include(j=>j.contribuyente).Where(x=>x.contribuyente.numeroIdentificacion.Equals(numeroIdentificacion)).ToListAsync();
        }

    }
}
