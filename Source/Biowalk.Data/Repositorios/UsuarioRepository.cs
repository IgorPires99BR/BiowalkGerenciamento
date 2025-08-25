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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSession _session;

        public UsuarioRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<Usuario> ObterPorLoginSenha(string login, string senha)
        {
            var sql = $@"
                SELECT
                    {nameof(Usuario.IdUsuario)},
                    {nameof(Usuario.IdSetor)},
                    {nameof(Usuario.Nome)},
                    {nameof(Usuario.Login)},
                    {nameof(Usuario.Senha)}
                FROM
                    {nameof(Usuario)}
                WHERE
                    {nameof(Usuario.Login)} = @{nameof(Usuario.Login)} AND {nameof(Usuario.Senha)} = @{nameof(Usuario.Senha)};
                    ";

            // DynamicParameters é uma classe do Dapper que permite adicionar
            // parâmetros de forma segura para evitar ataques de injeção de SQL.
            DynamicParameters parametros = new DynamicParameters();

            // O uso de 'nameof(Propriedade)' garante que o nome do parâmetro
            // corresponda exatamente à propriedade, mesmo que você a renomeie.
            parametros.Add($"@{nameof(Usuario.Login)}", login);
            parametros.Add($"@{nameof(Usuario.Senha)}", senha);

            // O método QueryFirstOrDefaultAsync retorna o primeiro resultado da consulta
            // ou null se nenhum registro for encontrado. Isso é ideal para um login único.
            var usuario = await _session._connection.QueryFirstOrDefaultAsync<Usuario>(
                sql,
                parametros,
                transaction: _session.Transaction
            );

            return usuario;
        }
    }
}
