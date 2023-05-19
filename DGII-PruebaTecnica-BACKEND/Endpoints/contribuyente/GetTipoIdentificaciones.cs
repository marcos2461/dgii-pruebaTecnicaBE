
using DGII_PruebaTecnica.Infrastructure.DTO;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DGII_PruebaTecnica_BACKEND.Endpoints.contribuyente
{

    public class GetTipoIdentificaciones : ControllerBase
    {
        private readonly IContribuyenteRepository _contribuyenteRepository;

        public GetTipoIdentificaciones(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }


        [HttpGet("/api/GetTipoIdentificaciones")]
        [SwaggerOperation(
            Summary = "Get list of all tipo identificacion",
            Description = "Get list of all tipo identificacion",
            OperationId = "Contribuyente.GetTipoIdentificacion",
            Tags = new[] { "ContribuyenteEndPoints" })
            ]
        public async Task<ActionResult<List<tipoIdentificacionResponseDto>>> HandleAsync(CancellationToken cancellationToken)
        {
            try
            {
                var allTipoIdentificacion = await _contribuyenteRepository.getTipoIdentificaciones();
                List<tipoIdentificacionResponseDto> response = new List<tipoIdentificacionResponseDto>();
                foreach (var tipoIndentificacion in allTipoIdentificacion)
                {
                    response.Add(new tipoIdentificacionResponseDto { Id = tipoIndentificacion.id, descripcion = tipoIndentificacion.descripcion });
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
