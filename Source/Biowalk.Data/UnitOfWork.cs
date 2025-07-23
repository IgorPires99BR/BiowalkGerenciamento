using Biowalk.Data.Repositorios;
using Biowalk.Dominio.Interfaces;
using Biowalk.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;

         public IClienteRepository ClienteRepository { get; set; }
         public IEquipamentoRepository EquipamentoRepository { get; set; }

        public UnitOfWork(DbSession session,
            IClienteRepository clienteRepository,
            IEquipamentoRepository equipamentoRepository)
        {
            _session = session;
            ClienteRepository = clienteRepository;
            EquipamentoRepository = equipamentoRepository;
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session._connection.BeginTransaction();
        }

        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }
    }
}
