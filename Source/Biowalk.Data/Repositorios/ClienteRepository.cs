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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSession _session; 

        public ClienteRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> Incluir(Cliente cliente)
        {
            var sql = $@"
        INSERT INTO {nameof(Cliente)}
        (
            {nameof(Cliente.IdCliente)},
            {nameof(Cliente.RazaoSocial)},
            {nameof(Cliente.NomeFantasia)},
            {nameof(Cliente.NomeSocio)},
            {nameof(Cliente.DataCriacao)},
            {nameof(Cliente.DataAlteracao)},
            {nameof(Cliente.Logradouro)},
            {nameof(Cliente.CEP)},
            {nameof(Cliente.Bairro)},
            {nameof(Cliente.Cidade)},
            {nameof(Cliente.UF)}
        )
        VALUES
        (
            @{nameof(Cliente.IdCliente)},
            @{nameof(Cliente.RazaoSocial)},
            @{nameof(Cliente.NomeFantasia)},
            @{nameof(Cliente.NomeSocio)},
            @{nameof(Cliente.DataCriacao)},
            @{nameof(Cliente.DataAlteracao)},
            @{nameof(Cliente.Logradouro)},
            @{nameof(Cliente.CEP)},
            @{nameof(Cliente.Bairro)},
            @{nameof(Cliente.Cidade)},
            @{nameof(Cliente.UF)}
        );";


            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, cliente, _session.Transaction);
            return linhasAfetadas;

        }

        public async Task<int> Atualizar(Cliente cliente)
        {
            var sql = $@"
        UPDATE {nameof(Cliente)}
        SET
            {nameof(Cliente.RazaoSocial)} = @{nameof(Cliente.RazaoSocial)},
            {nameof(Cliente.NomeFantasia)} = @{nameof(Cliente.NomeFantasia)},
            {nameof(Cliente.NomeSocio)} = @{nameof(Cliente.NomeSocio)},
            {nameof(Cliente.DataAlteracao)} = @{nameof(Cliente.DataAlteracao)},
            {nameof(Cliente.Logradouro)} = @{nameof(Cliente.Logradouro)},
            {nameof(Cliente.CEP)} = @{nameof(Cliente.CEP)},
            {nameof(Cliente.Bairro)} = @{nameof(Cliente.Bairro)},
            {nameof(Cliente.Cidade)} = @{nameof(Cliente.Cidade)},
            {nameof(Cliente.UF)} = @{nameof(Cliente.UF)}
        WHERE
            {nameof(Cliente.IdCliente)} = @{nameof(Cliente.IdCliente)};";

            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, cliente, _session.Transaction);
            return linhasAfetadas;
        }

        public async Task<int> Deletar(Guid idCliente)
        {
            var sql = $@"
        DELETE FROM {nameof(Cliente)}
        WHERE
            {nameof(Cliente.IdCliente)} = @IdCliente;"; // Using a named parameter for clarity

            var linhasAfetadas = await _session._connection.ExecuteAsync(sql, new { IdCliente = idCliente }, _session.Transaction);
            return linhasAfetadas;
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            var sql = $@"
        SELECT
            {nameof(Cliente.IdCliente)},
            {nameof(Cliente.RazaoSocial)},
            {nameof(Cliente.NomeFantasia)},
            {nameof(Cliente.NomeSocio)},
            {nameof(Cliente.DataCriacao)},
            {nameof(Cliente.DataAlteracao)},
            {nameof(Cliente.Logradouro)},
            {nameof(Cliente.CEP)},
            {nameof(Cliente.Bairro)},
            {nameof(Cliente.Cidade)},
            {nameof(Cliente.UF)}
        FROM
            {nameof(Cliente)};";

            var clientes = await _session._connection.QueryAsync<Cliente>(sql, transaction: _session.Transaction);
            return clientes;
        }

        public async Task<Cliente> ObterPorId(Guid idCliente)
        {
            var sql = $@"
        SELECT
            {nameof(Cliente.IdCliente)},
            {nameof(Cliente.RazaoSocial)},
            {nameof(Cliente.NomeFantasia)},
            {nameof(Cliente.NomeSocio)},
            {nameof(Cliente.DataCriacao)},
            {nameof(Cliente.DataAlteracao)},
            {nameof(Cliente.Logradouro)},
            {nameof(Cliente.CEP)},
            {nameof(Cliente.Bairro)},
            {nameof(Cliente.Cidade)},
            {nameof(Cliente.UF)}
        FROM
            {nameof(Cliente)}
        WHERE
            {nameof(Cliente.IdCliente)} = @IdCliente;"; // Using a named parameter for clarity

            var cliente = await _session._connection.QuerySingleOrDefaultAsync<Cliente>(sql, new { IdCliente = idCliente }, _session.Transaction);
            return cliente;
        }

    }
}
