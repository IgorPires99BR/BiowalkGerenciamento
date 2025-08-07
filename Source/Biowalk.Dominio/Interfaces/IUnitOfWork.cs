using Biowalk.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IEquipamentoRepository EquipamentoRepository { get; }
        IEquipamentoSetorRepository EquipamentoSetorRepository { get; }
        void Commit();
        void BeginTransaction();
        void Rollback();
        
    }
}
