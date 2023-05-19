using DGII_PruebaTecnica.Infrastructure.DTO;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DGII_PruebaTecnica_BACKEND.Endpoints.contribuyente
{
    public class List : ControllerBase
    {
        private readonly IContribuyenteRepository _contribuyenteRepository;

        public List(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }

        [HttpGet("/api/contribuyente")]
        [SwaggerOperation(
            Summary = "Get list of all Contribuyentes",
            Description = "Get list of all contribuyentes",
            OperationId = "Contribuyente.List",
            Tags = new[] { "ContribuyenteEndPoints" })
            ]
        public async Task<ActionResult<List<contribuyenteResponseDto>>> HandleAsync(CancellationToken cancellationToken)
        {
            try
            {
                var allContribuyentes = await _contribuyenteRepository.getAllContribuyentes();

                List<contribuyenteResponseDto> response = new List<contribuyenteResponseDto>();
                foreach (var contribuyente in allContribuyentes)
                {
                    response.Add(new contribuyenteResponseDto
                    {
                        Id = contribuyente.id,
                        estatus = contribuyente.estatus ? " Activo" : "Inactivo",
                        nombre = contribuyente.nombre + " " + contribuyente.apellido,
                        rncCedula = contribuyente.numeroIdentificacion, 
                        tipo = contribuyente.tipoContribuyente.descripcion
                    });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
