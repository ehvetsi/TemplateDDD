using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDDD.Application.Dtos
{
    public class ClienteEnderecoDto
    {
        public ClienteDto Cliente { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
