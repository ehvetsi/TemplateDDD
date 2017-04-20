using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Entities;

namespace TemplateDDD.Domain.Interfaces.Repository
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
