using Biowalk.Dominio.Entidades;
using Biowalk.Dominio.Entidades.QueryAdapters;
using Biowalk.Dominio.Interfaces.Repositorios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Data.Repositorios
{
    public class EquipamentoMontagemRepository : IEquipamentoMontagemRepository
    {
        private readonly DbSession _session;

        public EquipamentoMontagemRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<List<EquipamentoMontagemQueryAdapter>> ObterTodos()
        {
            var sql = $@"
                    SELECT
                        em.{nameof(EquipamentoMontagem.IdEquipamentoMontagem)},
                        em.{nameof(Equipamento.IdEquipamento)},
                        e.{nameof(Equipamento.Nome)} AS {nameof(EquipamentoMontagemQueryAdapter.NomeEquipamento)},
                        em.{nameof(EquipamentoMontagem.DataLancamento)},
                        em.{nameof(EquipamentoMontagem.DataFechamentoCorte)},
                        em.{nameof(EquipamentoMontagem.DataFechamentoSolda)},
                        em.{nameof(EquipamentoMontagem.DataFechamentoMontagem)},
                        em.{nameof(EquipamentoMontagem.DataFechamentoPintura)},
                        em.{nameof(EquipamentoMontagem.Etapa)} AS {nameof(EquipamentoMontagemQueryAdapter.Etapa)},
                        em.{nameof(EquipamentoMontagem.Status)} AS {nameof(EquipamentoMontagemQueryAdapter.Status)}
                    FROM
                        {nameof(EquipamentoMontagem)} em
                    INNER JOIN
                        {nameof(Equipamento)} e ON em.{nameof(EquipamentoMontagem.IdEquipamento)} = e.{nameof(Equipamento.IdEquipamento)};
    ";

            var result = await _session._connection.QueryAsync<EquipamentoMontagemQueryAdapter>(sql, transaction: _session.Transaction);
            return result.ToList();
        }

        public async Task<int> Adicionar(EquipamentoMontagem equipamentoMontagem)
        {
            var sql = $@"
                        INSERT INTO {nameof(EquipamentoMontagem)}
                        (
                            {nameof(EquipamentoMontagem.IdEquipamentoMontagem)},
                            {nameof(EquipamentoMontagem.IdEquipamento)},
                            {nameof(EquipamentoMontagem.DataLancamento)},
                            {nameof(EquipamentoMontagem.DataFechamentoCorte)},
                            {nameof(EquipamentoMontagem.DataFechamentoSolda)},
                            {nameof(EquipamentoMontagem.DataFechamentoPintura)},
                            {nameof(EquipamentoMontagem.DataFechamentoMontagem)},
                            {nameof(EquipamentoMontagem.Status)},
                            {nameof(EquipamentoMontagem.Etapa)}
                        )
                        VALUES
                        (
                            @{nameof(EquipamentoMontagem.IdEquipamentoMontagem)},
                            @{nameof(EquipamentoMontagem.IdEquipamento)},
                            @{nameof(EquipamentoMontagem.DataLancamento)},
                            @{nameof(EquipamentoMontagem.DataFechamentoCorte)},
                            @{nameof(EquipamentoMontagem.DataFechamentoSolda)},
                            @{nameof(EquipamentoMontagem.DataFechamentoPintura)},
                            @{nameof(EquipamentoMontagem.DataFechamentoMontagem)},
                            @{nameof(EquipamentoMontagem.Status)},
                            @{nameof(EquipamentoMontagem.Etapa)}
                        );
                    ";

            DynamicParameters parametros = new DynamicParameters();

            parametros.Add($"@{nameof(EquipamentoMontagem.IdEquipamentoMontagem)}", equipamentoMontagem.IdEquipamentoMontagem);
            parametros.Add($"@{nameof(EquipamentoMontagem.IdEquipamento)}", equipamentoMontagem.IdEquipamento);
            parametros.Add($"@{nameof(EquipamentoMontagem.DataLancamento)}", equipamentoMontagem.DataLancamento);
            parametros.Add($"@{nameof(EquipamentoMontagem.DataFechamentoCorte)}", equipamentoMontagem.DataFechamentoCorte);
            parametros.Add($"@{nameof(EquipamentoMontagem.DataFechamentoSolda)}", equipamentoMontagem.DataFechamentoSolda);
            parametros.Add($"@{nameof(EquipamentoMontagem.DataFechamentoPintura)}", equipamentoMontagem.DataFechamentoPintura);
            parametros.Add($"@{nameof(EquipamentoMontagem.DataFechamentoMontagem)}", equipamentoMontagem.DataFechamentoMontagem);
            parametros.Add($"@{nameof(EquipamentoMontagem.Status)}", equipamentoMontagem.Status);
            parametros.Add($"@{nameof(EquipamentoMontagem.Etapa)}", equipamentoMontagem.Etapa);


            var result = await _session._connection.ExecuteAsync(sql, parametros, transaction: _session.Transaction);

            return result;
        }

        public async Task<int> ProcessaEtapa(string IdEquipamentoMontagem, int EtapaAtual, DateTime dataAtualizacao)
        {
            var proximaEtapa = EtapaAtual + 1;
            string colunaData = null;

            if (EtapaAtual == 1)
            {
                colunaData = nameof(EquipamentoMontagem.DataFechamentoCorte);
            }
            else if (EtapaAtual == 2)
            {
                colunaData = nameof(EquipamentoMontagem.DataFechamentoSolda);
            }
            else if (EtapaAtual == 3)
            {
                colunaData = nameof(EquipamentoMontagem.DataFechamentoPintura);
            }
            else if (EtapaAtual == 4)
            {
                colunaData = nameof(EquipamentoMontagem.DataFechamentoMontagem);
            }

            var sql = $@"
                    UPDATE {nameof(EquipamentoMontagem)} 
                    SET {nameof(EquipamentoMontagem.Etapa)} = @{nameof(EquipamentoMontagem.Etapa)},
                    {(colunaData != null ? $"{colunaData} = @{colunaData}" : "")}
                    WHERE {nameof(EquipamentoMontagem.IdEquipamentoMontagem)} = @{nameof(EquipamentoMontagem.IdEquipamentoMontagem)};
                    ";

            DynamicParameters parametros = new DynamicParameters();

            parametros.Add($"@{nameof(EquipamentoMontagem.Etapa)}", proximaEtapa);
            parametros.Add($"@{nameof(EquipamentoMontagem.IdEquipamentoMontagem)}", IdEquipamentoMontagem);

            if (colunaData != null)
            {
                parametros.Add($"@{colunaData}", dataAtualizacao);
            }

            var result = await _session._connection.ExecuteAsync(sql, parametros,transaction: _session.Transaction);

            return result;
        }
    }
}
