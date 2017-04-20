using System;
using System.Linq;
using TemplateDDD.Domain.Entities;
using TemplateDDD.Domain.Interfaces.Repository;

namespace TemplateDDD.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf) => DB.Clientes.FirstOrDefault(c => c.CPF == cpf);

        public Cliente ObterPorEmail(string email) => DB.Clientes.FirstOrDefault(c => c.Email == email);

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }
    }
}
