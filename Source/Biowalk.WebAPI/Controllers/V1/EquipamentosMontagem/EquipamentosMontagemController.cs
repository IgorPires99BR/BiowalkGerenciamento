using Biowalk.Dominio.Interfaces.Mediator;
using Biowalk.Dominio.UseCases.CriaEquipamentoMontagem;
using Biowalk.Dominio.UseCases.EquipamentoMontagem.ObterEquipamentoMontagem;
using Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor;
using Biowalk.Dominio.UseCases.ObterEquipamentoMontagem;
using Biowalk.Dominio.UseCases.ProcessaEtapa;
using Biowalk.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biowalk.WebAPI.Controllers.V1.EquipamentosMontagem
{
    [ApiController]
    [Route("[controller]")]
    public class EquipamentosMontagemController : Controller
    {
        public IMediator _mediator;

        public EquipamentosMontagemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ObterEquipamentoMontagemQuery());
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CriaEquipamentoMontagemCommand request)
        {
            var response = await _mediator.Send(request);
            return this.ValidateResponse((int)HttpStatusCode.Created, response);
        }
    }
}
