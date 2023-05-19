using DGII_PruebaTecnica.Core.Entities;

namespace DGII_PruebaTecnica.Infrastructure.Interfaces
{
    public interface IComprobantesFiscalesRepository : IRepository<comprobantesFiscales>
    {
        Task<List<comprobantesFiscales>> getAllComprobanteSFiscalesByContribuyente(string numeroIdentificacion);
    }
}
