using DGII_PruebaTecnica.Infrastructure.DTO;
using DGII_PruebaTecnica.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DGII_PruebaTecnica_BACKEND.Endpoints.ComprobanteFiscales
{
    public class ListByContribuyente : ControllerBase
    {
        private readonly IComprobantesFiscalesRepository _comprobantesFiscalesRepository;

        public ListByContribuyente(IComprobantesFiscalesRepository comprobantesFiscalesRepository)
        {
            _comprobantesFiscalesRepository = comprobantesFiscalesRepository;
        }

        [HttpGet("/api/ComprobanteFiscal")]
        [SwaggerOperation(
            Summary = "Get list of all comprobantes Fiscales by Contribuyente",
            Description = "Get list of all comprobantes Fiscales by Contribuyente",
            OperationId = "comprobantesFiscales.ListByContribuyente",
            Tags = new[] { "ComprobanteFiscalEndPoints" })
            ]
        public async Task<ActionResult<List<comprobanteFiscalesResponseDto>>> HandleAsync(string identificacionNumber,CancellationToken cancellationToken)
        {
            try
            {
                var allComprobantesFiscales = await _comprobantesFiscalesRepository.getAllComprobanteSFiscalesByContribuyente(identificacionNumber);

                if (!allComprobantesFiscales.Any())
                     return NotFound("no existen NCF para el documento ingresado");
                


                List<comprobanteFiscalesResponseDto> response = new List<comprobanteFiscalesResponseDto>();

                foreach (var comprobanteFiscal in allComprobantesFiscales)
                {
                    response.Add(new comprobanteFiscalesResponseDto
                    {
                        rncCedula = comprobanteFiscal.contribuyente.numeroIdentificacion,
                        NCF = comprobanteFiscal.NCF,
                        monto = comprobanteFiscal.monto,
                        itbis18 = comprobanteFiscal.itebis18

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