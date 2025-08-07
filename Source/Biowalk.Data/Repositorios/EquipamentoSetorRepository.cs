using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Interfaces.Repositorios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Data.Repositorios
{
    public class EquipamentoSetorRepository : IEquipamentoSetorRepository
    {
        private readonly DbSession _session;

        public EquipamentoSetorRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> Adicionar(EquipamentoSetor equipamentoSetor)
        {
            var sql = $@"
        INSERT INTO {nameof(EquipamentoSetor)}
        (
            {nameof(EquipamentoSetor.IdEquipamentoSetor)},
            {nameof(EquipamentoSetor.IdSetor)},
            {nameof(EquipamentoSetor.IdEquipamento)},
            {nameof(EquipamentoSetor.Ordem)}
        )
        VALUES
        (
            @{nameof(EquipamentoSetor.IdEquipamentoSetor)},
            @{nameof(EquipamentoSetor.IdSetor)},
            @{nameof(EquipamentoSetor.IdEquipamento)},
            @{nameof(EquipamentoSetor.Ordem)}
        );";


            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, equipamentoSetor, _session.Transaction);
            return linhasAfetadas;
        }
    }
}
