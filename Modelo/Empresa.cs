using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Empresa
    {
        public String CNPJ;
        public String Nome;
        public String Email;
        public String Telefone;
        public Endereco endereco = new Endereco();
    }
}
