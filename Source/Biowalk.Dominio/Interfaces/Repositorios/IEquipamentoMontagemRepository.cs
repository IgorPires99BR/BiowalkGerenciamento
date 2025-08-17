using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Entidades.QueryAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Interfaces.Repositorios
{
    public interface IEquipamentoMontagemRepository
    {
        Task<List<EquipamentoMontagemQueryAdapter>> ObterTodos();
        Task<int> ProcessaEtapa(string IdEquipamentoMontagem, int EtapaAtual,DateTime dataAtualizacao);
        Task<int> Adicionar(EquipamentoMontagem equipamentoMontagem);
    }
}
