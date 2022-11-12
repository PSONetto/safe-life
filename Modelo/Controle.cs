using SafeLife.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Controle
    {
        public String Mensagem { get; set; }
        Validacao validacao = new Validacao();
        public Usuario buscarUsuario(String login, String senha)
        {
            Usuario usuario = new Usuario();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            validacao.validarUsuario(login, senha);
            if (validacao.Mensagem.Equals(""))
            {
                usuarioDAO.login(login, senha);
                this.Mensagem = usuarioDAO.mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
            return usuario;
        }

        public void CadastrarTitular(List<String> listaTitular)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaTitular);

            if (validacao.Mensagem.Equals(""))
            {
                Titular titular = new Titular();
                titular.nome = listaTitular[1];
                titular.datNasc = DateTime.Parse(listaTitular[2]);
                titular.cpf = listaTitular[3];
                titular.rg = listaTitular[4];
                titular.nomeMae = listaTitular[5];
                titular.nomePai = listaTitular[6];
                titular.telefone = listaTitular[7];
                titular.celular = listaTitular[8];
                titular.email = listaTitular[9];
                titular.endereco.cep = listaTitular[10];
                titular.endereco.rua = listaTitular[11];
                if (listaTitular[12] == "")
                {
                    titular.endereco.numero = 0;
                }
                else
                {
                    titular.endereco.numero = int.Parse(listaTitular[12]);
                }
                titular.endereco.bairro = listaTitular[13];
                titular.endereco.complemento = listaTitular[14];
                titular.endereco.estado = listaTitular[15];
                titular.endereco.cidade = listaTitular[16];

                TitularDAO titularDAO = new TitularDAO();
                titularDAO.cadastrarTitular(titular);
                this.Mensagem = "Titular cadastrado com sucesso.";
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }
    }
}
