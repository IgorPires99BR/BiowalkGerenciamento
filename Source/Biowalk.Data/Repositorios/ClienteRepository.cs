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

        //public async Task<int> ObterTodos(Cliente cliente)
        //{
        //    var sql = $@"
        //        INSERT INTO {nameof(Cliente)}
        //        (RazaoSocial, 
        //        NomeFantasia,
        //        UF, 
        //        Logradouro, 
        //        Estado, 
        //        DataCadastro)
        //        VALUES 
        //        (@RazaoSocial, 
        //        @NomeFantasia, 
        //        @UF, 
        //        @Logradouro, 
        //        @Estado, 
        //        @DataCadastro);
        //        SELECT CAST(SCOPE_IDENTITY() as int);"; // Retorna o ID gerado (SQL Server)

        //    var id = await _session._connection.ExecuteScalarAsync<int>(sql, cliente, _session.Transaction);
        //    return id;
        //}
    }
}
