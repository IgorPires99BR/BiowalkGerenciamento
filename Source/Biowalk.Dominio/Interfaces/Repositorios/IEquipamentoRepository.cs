using Biowalk.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Interfaces.Repositorios
{
    public interface IEquipamentoRepository
    {
        Task<int> Incluir(Equipamento equipamento);

        Task<int> Atualizar(Equipamento equipamento);
        Task<int> Deletar(Guid idEquipamento);
        Task<IEnumerable<Equipamento>> ObterTodos();
        Task<Equipamento> ObterPorId(Guid equipamento);
    }
}
