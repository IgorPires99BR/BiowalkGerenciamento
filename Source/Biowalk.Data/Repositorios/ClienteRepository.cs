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
            var sql = @"
                INSERT INTO Clientes (RazaoSocial, NomeFantasia, UF, Logradouro, Estado, DataCadastro)
                VALUES (@RazaoSocial, @NomeFantasia, @UF, @Logradouro, @Estado, @DataCadastro);
                SELECT CAST(SCOPE_IDENTITY() as int);"; // Retorna o ID gerado (SQL Server)

            var id = await _session._connection.ExecuteScalarAsync<int>(sql, cliente, _session.Transaction);
            return id;
        }
    }
}
