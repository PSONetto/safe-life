using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Endereco
    {
        public String cidade { get; set; }
        public String estado { get; set; }
        public String cep { get; set; }
        public String rua { get; set; }
        public int numero { get; set; }
        public String bairro { get; set; }
        public String complemento { get; set; }
    }
}
