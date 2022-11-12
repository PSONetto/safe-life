using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Beneficiario : PessoaFisica
    {
        public String relacao { get; set; }
        public int porcentagem { get; set; }
    }
}
