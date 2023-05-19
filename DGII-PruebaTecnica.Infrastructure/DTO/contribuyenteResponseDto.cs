using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DGII_PruebaTecnica.Infrastructure.DTO
{
    public class contribuyenteResponseDto : BaseResponseDto
    {
        public string rncCedula { get; set; }
        public string nombre { get; set; }  
        public string tipo { get; set; }
        public string estatus { get; set; }
    }
}
