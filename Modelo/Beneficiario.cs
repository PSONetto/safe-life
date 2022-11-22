using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Beneficiario : PessoaFisica
    {
        public String Relacao { get; set; }
        public int CodTitular { get; set; }
        public String CPFTitular { get; set; }
        public String NomeTitular { get; set; }
    }
}
