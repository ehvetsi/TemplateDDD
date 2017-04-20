using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Entities;

namespace TemplateDDD.Application.Interfaces
{
    public interface IClienteAppService:IDisposable
    {
        Cliente Adicionar(Cliente obj);

        Cliente Atualizar(Cliente obj);

        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        Cliente ObterPorId(Guid id);

        IEnumerable<Cliente> ObterTodos();

        void Remover(Guid id);

        int SaveChanges();
    }
}
