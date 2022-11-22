using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class PessoaFisica
    {
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public String Nome { get; set; }
        public String NomeMae { get; set; }
        public String NomePai { set; get; }
        public DateTime DatNasc { set; get; }
        public Endereco endereco = new Endereco();
        public String Email { set; get; }
        public String Telefone { set; get; }
        public String Celular { set; get; }
        public Historico historico = new Historico();
    }
}
