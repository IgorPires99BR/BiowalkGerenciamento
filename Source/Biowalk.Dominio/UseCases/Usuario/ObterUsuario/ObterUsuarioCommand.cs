using Biowalk.Dominio.Common;
using Biowalk.Dominio.Interfaces.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Usuario.ObterUsuario
{
    public class ObterUsuarioCommand : IRequest<Response<ObterUsuarioResult>>
    {
        public string LoginUsuario{ get; set; }
        public string SenhaUsuario{ get; set; }
    }
}
