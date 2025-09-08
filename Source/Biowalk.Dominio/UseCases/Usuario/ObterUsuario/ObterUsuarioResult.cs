using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.Usuario.ObterUsuario
{
    public class ObterUsuarioResult
    {
        public ObterUsuarioResult(string mensagem)
        {
            IdSetor = mensagem;
        }

        public string IdSetor { get; set; }
    }
}
