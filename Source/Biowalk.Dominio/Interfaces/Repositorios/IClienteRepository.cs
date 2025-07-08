using Biowalk.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biowalk.Dominio.Interfaces.Repositorios
{
    public interface IClienteRepository
    {
        Task<int> Incluir(Cliente cliente);

        Task<int> Atualizar(Cliente cliente);
        Task<int> Deletar(Guid idCliente);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorId(Guid idCliente);
    }
}
