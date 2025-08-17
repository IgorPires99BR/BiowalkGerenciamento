using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.ProcessaEtapa
{
    public class ProcessaEtapaResult
    {
        public ProcessaEtapaResult(string mensagem)
        {
            Resposta = mensagem;
        }
        public string Resposta { get; set; }
    }
}
