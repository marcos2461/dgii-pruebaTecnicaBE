using DGII_PruebaTecnica.Core.Entities;

namespace DGII_PruebaTecnica.Infrastructure.Interfaces
{
    public interface IContribuyenteRepository : IRepository<contribuyente>
    {
        Task<List<tipoIdentificacion>> getTipoIdentificaciones();
        Task<IEnumerable<contribuyente>> getAllContribuyentes();
    }
}
