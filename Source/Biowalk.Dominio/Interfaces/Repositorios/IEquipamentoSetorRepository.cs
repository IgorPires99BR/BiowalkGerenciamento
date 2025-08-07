using Biowalk.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Interfaces.Repositorios
{
    public interface IEquipamentoSetorRepository
    {
        Task<int> Adicionar(EquipamentoSetor equipamentoSetor);
    }
}
