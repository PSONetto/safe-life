using SafeLife.DAL;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void cadastrarTitular(List<String> listaTitular)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaTitular);

            if (validacao.Mensagem.Equals(""))
            {
                Titular titular = new Titular();
                titular.Nome = listaTitular[1];
                titular.DatNasc = DateTime.Parse(listaTitular[2]);
                titular.Cpf = listaTitular[3];
                titular.Rg = listaTitular[4];
                titular.NomeMae = listaTitular[5];
                titular.NomePai = listaTitular[6];
                titular.Telefone = listaTitular[7];
                titular.Celular = listaTitular[8];
                titular.Email = listaTitular[9];
                titular.endereco.Cep = listaTitular[10];
                titular.endereco.Rua = listaTitular[11];
                titular.endereco.Numero = listaTitular[12];
                titular.endereco.Bairro = listaTitular[13];
                titular.endereco.Complemento = listaTitular[14];
                titular.endereco.Estado = listaTitular[15];
                titular.endereco.Cidade = listaTitular[16];
                titular.Plano = listaTitular[17];
                titular.historico.Cardiaco = listaTitular[18] == "1" ? true : false;
                titular.historico.Asma = listaTitular[19] == "1" ? true : false;
                titular.historico.Genetico = listaTitular[20] == "1" ? true : false;
                titular.historico.Mental = listaTitular[21] == "1" ? true : false;
                titular.historico.Cancer = listaTitular[22] == "1" ? true : false;
                titular.historico.Alzheimer = listaTitular[23] == "1" ? true : false;
                titular.historico.Deficiente = listaTitular[24] == "1" ? true : false;
                titular.contrato.DatContrato = DateTime.Parse(listaTitular[25]);

                TitularDAO titularDAO = new TitularDAO();
                titularDAO.cadastrarTitular(titular);
                this.Mensagem = titularDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public Titular pesquisarTitular(String id)
        {
            Validacao validacao = new Validacao();
            Titular titular = new Titular();
            TitularDAO titularDAO = new TitularDAO();


            if (validacao.validaCPF(id) == true)
            {
                titular = titularDAO.pesquisarTitular(id);
                this.Mensagem = titularDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CPF inválido";
            }

            return titular;
        }

        public void editarTitular(List<String> listaTitular)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaTitular);

            if (validacao.Mensagem.Equals(""))
            {
                Titular titular = new Titular();
                titular.Nome = listaTitular[1];
                titular.DatNasc = DateTime.Parse(listaTitular[2]);
                titular.Cpf = listaTitular[3];
                titular.Rg = listaTitular[4];
                titular.NomeMae = listaTitular[5];
                titular.NomePai = listaTitular[6];
                titular.Telefone = listaTitular[7];
                titular.Celular = listaTitular[8];
                titular.Email = listaTitular[9];
                titular.endereco.Cep = listaTitular[10];
                titular.endereco.Rua = listaTitular[11];
                titular.endereco.Numero = listaTitular[12];
                titular.endereco.Bairro = listaTitular[13];
                titular.endereco.Complemento = listaTitular[14];
                titular.endereco.Estado = listaTitular[15];
                titular.endereco.Cidade = listaTitular[16];
                titular.Plano = listaTitular[17];
                titular.historico.Cardiaco = listaTitular[18] == "1" ? true : false;
                titular.historico.Asma = listaTitular[19] == "1" ? true : false;
                titular.historico.Genetico = listaTitular[20] == "1" ? true : false;
                titular.historico.Mental = listaTitular[21] == "1" ? true : false;
                titular.historico.Cancer = listaTitular[22] == "1" ? true : false;
                titular.historico.Alzheimer = listaTitular[23] == "1" ? true : false;
                titular.historico.Deficiente = listaTitular[24] == "1" ? true : false;
                titular.contrato.DatContrato = DateTime.Parse(listaTitular[25]);

                TitularDAO titularDAO = new TitularDAO();
                titularDAO.excluirTitular(titular.Cpf.ToString());
                titularDAO.cadastrarTitular(titular);

                this.Mensagem = titularDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void cadastrarEmpresa(List<String> listaEmpresa)
        {
            this.Mensagem = "";

            validacao.validarEmpresa(listaEmpresa);

            if (validacao.Mensagem.Equals(""))
            {
                Empresa empresa = new Empresa();
                empresa.Nome = listaEmpresa[1];
                empresa.CNPJ = listaEmpresa[2];
                empresa.Telefone = listaEmpresa[3];
                empresa.Email = listaEmpresa[4];
                empresa.endereco.Cep = listaEmpresa[5];
                empresa.endereco.Rua = listaEmpresa[6];
                empresa.endereco.Numero = listaEmpresa[7];
                empresa.endereco.Bairro = listaEmpresa[8];
                empresa.endereco.Complemento = listaEmpresa[9];
                empresa.endereco.Estado = listaEmpresa[10];
                empresa.endereco.Cidade = listaEmpresa[11];

                EmpresaDAO empresaDAO = new EmpresaDAO();
                empresaDAO.cadastrarEmpresa(empresa);
                this.Mensagem = "Empresa cadastrada.";
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void editarEmpresa(List<String> listaEmpresa)
        {
            this.Mensagem = "";

            validacao.validarEmpresa(listaEmpresa);

            if (validacao.Mensagem.Equals(""))
            {
                Empresa empresa = new Empresa();
                empresa.Nome = listaEmpresa[1];
                empresa.CNPJ = listaEmpresa[2];
                empresa.Telefone = listaEmpresa[3];
                empresa.Email = listaEmpresa[4];
                empresa.endereco.Cep = listaEmpresa[5];
                empresa.endereco.Rua = listaEmpresa[6];
                empresa.endereco.Numero = listaEmpresa[7];
                empresa.endereco.Bairro = listaEmpresa[8];
                empresa.endereco.Complemento = listaEmpresa[9];
                empresa.endereco.Estado = listaEmpresa[10];
                empresa.endereco.Cidade = listaEmpresa[11];

                EmpresaDAO empresaDAO = new EmpresaDAO();
                empresaDAO.excluirEmpresa(empresa.CNPJ.ToString());
                empresaDAO.cadastrarEmpresa(empresa);
                this.Mensagem = "Empresa editada.";
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void excluirTitular(String cpf)
        {
            Validacao validacao = new Validacao();
            TitularDAO titularDAO = new TitularDAO();


            if (validacao.validaCPF(cpf) == true)
            {
                titularDAO.excluirTitular(cpf);
                this.Mensagem = titularDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CPF inválido";
            }
        }

        public void cadastrarUsuario(List<String> listaUsuario)
        {
            this.Mensagem = "";

            validacao.validarUsuario(listaUsuario);

            if (validacao.Mensagem.Equals(""))
            {
                Usuario usuario = new Usuario();
                usuario.Nome = listaUsuario[1];
                usuario.Email = listaUsuario[2];
                usuario.Senha = listaUsuario[3];


                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.cadastrarUsuario(usuario);
                this.Mensagem = "Empresa cadastrada.";
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void cadastrarBeneficiario(List<String> listaBeneficiario, String cpf)
        {
            this.Mensagem = "";

            validacao.validarBeneficiario(listaBeneficiario);

            if (validacao.Mensagem.Equals(""))
            {
                Beneficiario beneficiario = new Beneficiario();
                beneficiario.Nome = listaBeneficiario[1];
                beneficiario.DatNasc = DateTime.Parse(listaBeneficiario[2]);
                beneficiario.Cpf = listaBeneficiario[3];
                beneficiario.Rg = listaBeneficiario[4];
                beneficiario.NomeMae = listaBeneficiario[5];
                beneficiario.NomePai = listaBeneficiario[6];
                beneficiario.Telefone = listaBeneficiario[7];
                beneficiario.Celular = listaBeneficiario[8];
                beneficiario.Email = listaBeneficiario[9];
                beneficiario.endereco.Cep = listaBeneficiario[10];
                beneficiario.endereco.Rua = listaBeneficiario[11];
                beneficiario.endereco.Numero = listaBeneficiario[12];
                beneficiario.endereco.Bairro = listaBeneficiario[13];
                beneficiario.endereco.Complemento = listaBeneficiario[14];
                beneficiario.endereco.Estado = listaBeneficiario[15];
                beneficiario.endereco.Cidade = listaBeneficiario[16];
                beneficiario.Relacao = listaBeneficiario[17];

                BeneficiarioDAO beneficiarioDAO = new BeneficiarioDAO();
                beneficiarioDAO.cadastrarBeneficiario(beneficiario, cpf);
                this.Mensagem = beneficiarioDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void editarBeneficiario(List<String> listaBeneficiario, String cpf)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaBeneficiario);

            if (validacao.Mensagem.Equals(""))
            {
                Beneficiario beneficiario = new Beneficiario();
                beneficiario.Nome = listaBeneficiario[1];
                beneficiario.DatNasc = DateTime.Parse(listaBeneficiario[2]);
                beneficiario.Cpf = listaBeneficiario[3];
                beneficiario.Rg = listaBeneficiario[4];
                beneficiario.NomeMae = listaBeneficiario[5];
                beneficiario.NomePai = listaBeneficiario[6];
                beneficiario.Telefone = listaBeneficiario[7];
                beneficiario.Celular = listaBeneficiario[8];
                beneficiario.Email = listaBeneficiario[9];
                beneficiario.endereco.Cep = listaBeneficiario[10];
                beneficiario.endereco.Rua = listaBeneficiario[11];
                beneficiario.endereco.Numero = listaBeneficiario[12];
                beneficiario.endereco.Bairro = listaBeneficiario[13];
                beneficiario.endereco.Complemento = listaBeneficiario[14];
                beneficiario.endereco.Estado = listaBeneficiario[15];
                beneficiario.endereco.Cidade = listaBeneficiario[16];
                beneficiario.Relacao = listaBeneficiario[17];

                BeneficiarioDAO beneficiarioDAO = new BeneficiarioDAO();
                beneficiarioDAO.excluirBeneficiario(beneficiario.Cpf.ToString());
                beneficiarioDAO.cadastrarBeneficiario(beneficiario, cpf);
                this.Mensagem = beneficiarioDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public Beneficiario pesquisarBeneficiario(String id)
        {
            Validacao validacao = new Validacao();
            Beneficiario beneficiario = new Beneficiario();
            BeneficiarioDAO beneficiarioDAO = new BeneficiarioDAO();


            if (validacao.validaCPF(id) == true)
            {
                beneficiario = beneficiarioDAO.pesquisarBeneficiario(id);
                this.Mensagem = beneficiarioDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CPF inválido";
            }

            return beneficiario;
        }

        public void excluirBeneficiario(String cpf)
        {
            Validacao validacao = new Validacao();
            BeneficiarioDAO beneficiarioDAO = new BeneficiarioDAO();


            if (validacao.validaCPF(cpf) == true)
            {
                beneficiarioDAO.excluirBeneficiario(cpf);
                this.Mensagem = beneficiarioDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CPF inválido";
            }
        }

        public Empresa pesquisarEmpresa(String id)
        {
            Validacao validacao = new Validacao();
            Empresa empresa = new Empresa();
            EmpresaDAO empresaDAO = new EmpresaDAO();


            if (validacao.validaCNPJ(id) == true)
            {
                empresa = empresaDAO.pesquisarEmpresa(id);
                this.Mensagem = empresaDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CNPJ inválido";
            }

            return empresa;
        }

        public void excluirEmpresa(String cnpj)
        {
            Validacao validacao = new Validacao();
            EmpresaDAO empresaDAO = new EmpresaDAO();


            if (validacao.validaCNPJ(cnpj) == true)
            {
                empresaDAO.excluirEmpresa(cnpj);
                this.Mensagem = empresaDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CNPJ inválido";
            }
        }

        public void cadastrarFunc(List<String> listaTitular)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaTitular);

            if (validacao.Mensagem.Equals(""))
            {
                Titular titular = new Titular();
                titular.Nome = listaTitular[1];
                titular.DatNasc = DateTime.Parse(listaTitular[2]);
                titular.Cpf = listaTitular[3];
                titular.Rg = listaTitular[4];
                titular.NomeMae = listaTitular[5];
                titular.NomePai = listaTitular[6];
                titular.Telefone = listaTitular[7];
                titular.Celular = listaTitular[8];
                titular.Email = listaTitular[9];
                titular.endereco.Cep = listaTitular[10];
                titular.endereco.Rua = listaTitular[11];
                titular.endereco.Numero = listaTitular[12];
                titular.endereco.Bairro = listaTitular[13];
                titular.endereco.Complemento = listaTitular[14];
                titular.endereco.Estado = listaTitular[15];
                titular.endereco.Cidade = listaTitular[16];
                titular.Plano = listaTitular[17];
                titular.historico.Cardiaco = listaTitular[18] == "1" ? true : false;
                titular.historico.Asma = listaTitular[19] == "1" ? true : false;
                titular.historico.Genetico = listaTitular[20] == "1" ? true : false;
                titular.historico.Mental = listaTitular[21] == "1" ? true : false;
                titular.historico.Cancer = listaTitular[22] == "1" ? true : false;
                titular.historico.Alzheimer = listaTitular[23] == "1" ? true : false;
                titular.historico.Deficiente = listaTitular[24] == "1" ? true : false;
                titular.contrato.DatContrato = DateTime.Parse(listaTitular[25]);
                titular.CodEmpresa = listaTitular[26];

                FuncDAO funcDAO = new FuncDAO();
                funcDAO.cadastrarFunc(titular);
                this.Mensagem = funcDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

        public void excluirFunc(String cpf)
        {
            Validacao validacao = new Validacao();
            TitularDAO titularDAO = new TitularDAO();


            if (validacao.validaCPF(cpf) == true)
            {
                titularDAO.excluirTitular(cpf);
                this.Mensagem = titularDAO.Mensagem;
            }
            else
            {
                this.Mensagem = "CPF inválido";
            }
        }

        public void editarFunc(List<String> listaTitular)
        {
            this.Mensagem = "";

            validacao.validarTitular(listaTitular);

            if (validacao.Mensagem.Equals(""))
            {
                Titular titular = new Titular();
                titular.Nome = listaTitular[1];
                titular.DatNasc = DateTime.Parse(listaTitular[2]);
                titular.Cpf = listaTitular[3];
                titular.Rg = listaTitular[4];
                titular.NomeMae = listaTitular[5];
                titular.NomePai = listaTitular[6];
                titular.Telefone = listaTitular[7];
                titular.Celular = listaTitular[8];
                titular.Email = listaTitular[9];
                titular.endereco.Cep = listaTitular[10];
                titular.endereco.Rua = listaTitular[11];
                titular.endereco.Numero = listaTitular[12];
                titular.endereco.Bairro = listaTitular[13];
                titular.endereco.Complemento = listaTitular[14];
                titular.endereco.Estado = listaTitular[15];
                titular.endereco.Cidade = listaTitular[16];
                titular.Plano = listaTitular[17];
                titular.historico.Cardiaco = listaTitular[18] == "1" ? true : false;
                titular.historico.Asma = listaTitular[19] == "1" ? true : false;
                titular.historico.Genetico = listaTitular[20] == "1" ? true : false;
                titular.historico.Mental = listaTitular[21] == "1" ? true : false;
                titular.historico.Cancer = listaTitular[22] == "1" ? true : false;
                titular.historico.Alzheimer = listaTitular[23] == "1" ? true : false;
                titular.historico.Deficiente = listaTitular[24] == "1" ? true : false;
                titular.contrato.DatContrato = DateTime.Parse(listaTitular[25]);
                titular.CodEmpresa = listaTitular[26];

                FuncDAO funcDAO = new FuncDAO();
                funcDAO.excluirFunc(titular.Cpf);
                funcDAO.cadastrarFunc(titular);
                this.Mensagem = funcDAO.Mensagem;
            }
            else
            {
                this.Mensagem = validacao.Mensagem;
            }
        }

    }
}
