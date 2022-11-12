using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Titular : PessoaFisica
    {
        public int codTitular { get; set; }
        public List<Beneficiario> beneficiarios { get; set; }
    }
}
