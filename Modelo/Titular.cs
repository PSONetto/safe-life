using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Titular : PessoaFisica
    {
        public int CodTitular { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }
        public Contrato contrato = new Contrato();
        public String Plano { set; get; }
    }
}
