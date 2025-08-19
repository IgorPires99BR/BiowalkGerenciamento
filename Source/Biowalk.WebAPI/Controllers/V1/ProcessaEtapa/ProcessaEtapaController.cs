using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.ObterEquipamentoMontagem;
using Biowalk.Dominio.UseCases.ProcessaEtapa;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1.ProcessaEtapa
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessaEtapaController : Controller
    {
        public IMediator _mediator;

        public ProcessaEtapaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProcessaEtapaCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
