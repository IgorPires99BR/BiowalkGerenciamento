using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.UseCases.EquipamentosSetor.CriaEquipamentoSetor
{
    public class CriaEquipamentoSetorResult
    {
        public CriaEquipamentoSetorResult(string resposta)
        {
            Resposta = resposta;
        }
        public string Resposta;
    }
}
