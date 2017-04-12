using System;
using System.Collections;
using System.Collections.Generic;

namespace TemplateDDD.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public bool Ativo { get; set; }

        public Guid ClienteId { get; set; }

        public string CPF { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
