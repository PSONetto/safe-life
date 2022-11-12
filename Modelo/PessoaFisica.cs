using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class PessoaFisica
    {
        public String cpf { get; set; }
        public String rg { get; set; }
        public String nome { get; set; }
        public String nomeMae { get; set; }
        public String nomePai { set; get; }
        public DateTime datNasc { set; get; }
        public Endereco endereco = new Endereco();
        public String email { set; get; }
        public String telefone { set; get; }
        public String celular { set; get; }
    }
}
