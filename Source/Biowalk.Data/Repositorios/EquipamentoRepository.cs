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
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly DbSession _session;

        public EquipamentoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> Incluir(Equipamento equipamento)
        {
            var sql = $@"
        INSERT INTO {nameof(Equipamento)}
        (
            {nameof(Equipamento.IdEquipamento)},
            {nameof(Equipamento.Nome)}
        )
        VALUES
        (
            @{nameof(Equipamento.IdEquipamento)},
            @{nameof(Equipamento.Nome)}
        );";

            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, equipamento, _session.Transaction);
            return linhasAfetadas;
        }

        public async Task<int> Atualizar(Equipamento equipamento)
        {
            var sql = $@"
        UPDATE {nameof(Equipamento)}
        SET
            {nameof(Equipamento.Nome)} = @{nameof(Equipamento.Nome)}
        WHERE
            {nameof(Equipamento.IdEquipamento)} = @{nameof(Equipamento.IdEquipamento)};";

            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, equipamento, _session.Transaction);
            return linhasAfetadas;
        }

        public async Task<int> Deletar(Guid idEquipamento)
        {
            var sql = $@"
        DELETE FROM {nameof(Equipamento)}
        WHERE
            {nameof(Equipamento.IdEquipamento)} = @IdEquipamento;";

            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, new { IdEquipamento = idEquipamento }, _session.Transaction);
            return linhasAfetadas;
        }

        public async Task<IEnumerable<Equipamento>> ObterTodos()
        {
            var sql = $@"
        SELECT
            {nameof(Equipamento.IdEquipamento)},
            {nameof(Equipamento.Nome)}
        FROM
            {nameof(Equipamento)};";

            var equipamentos = await _session._connection.QueryAsync<Equipamento>(sql, transaction: _session.Transaction);
            return equipamentos;
        }

        public async Task<Equipamento> ObterPorId(Guid idEquipamento)
        {
            var sql = $@"
        SELECT
            {nameof(Equipamento.IdEquipamento)},
            {nameof(Equipamento.Nome)}
        FROM
            {nameof(Equipamento)}
        WHERE
            {nameof(Equipamento.IdEquipamento)} = @IdEquipamento;";

            var equipamento = await _session._connection.QuerySingleOrDefaultAsync<Equipamento>(sql, new { IdEquipamento = idEquipamento }, _session.Transaction);
            return equipamento;
        }
    }
}
